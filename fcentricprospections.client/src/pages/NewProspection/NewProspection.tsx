// react utilities
import { useContext, useEffect, useRef, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
// styles
import styles from "./NewProspection.module.css";
// types
import { IBrand, ICompetitorBrand, IContactInfo, IProspectionBrand, IProspectionBrandInterest, IProspectionCompetitorBrand, IProspectionDetail, IProspectionToDo, IToDo, OptionType } from '../../types';
// components
import BrandInput from '../../components/NewProspection/BrandInput/BrandInput';
import BrandInterestCard from '../../components/NewProspection/BrandInterestInput/BrandInterestInput';
import { ShopDetailCard } from '../../components/ShopDetailCard/ShopDetailCard';
import ToDoModule from '../../components/NewProspection/ToDoModule/ToDoModule';
import CustomLoader from '../../components/LoaderSpinner/CustomLoader';
// contexts
import { ShopDetailContext } from '../../contexts/ShopDetailContext';
import { UserContext } from '../../contexts/UserContext';
import { NewProspectionContext } from '../../contexts/NewProspectionContext';
// react-select
import Select, { createFilter, MultiValue } from 'react-select';
import MenuList from "../../components/ReactSelect/MenuList/MenuList"; // Custom MenuList
import Option, { customTheme } from "../../components/ReactSelect/Option/Option"; // Custom Option
// form-wizard
import FormWizard from "react-form-wizard-component";
import "react-form-wizard-component/dist/style.css";
// icons
import { AiOutlineCheck } from "react-icons/ai";
// uuid
import { v4 as uuidv4 } from 'uuid';
// custom hook
import { useLeaveWarning } from '../../hooks/useLeaveWarning';

export const NewProspection = () => {

  const { shopId } = useParams<{ shopId: string }>();
  const navigate = useNavigate();
  
  // Warning before leaving page that form data will be lost ------------------------------------------------------------------

  const [preventLeaving, setPreventLeaving] = useState<boolean>(true);
  useLeaveWarning(preventLeaving, "Niet-opgeslagen wijzigingen zullen verloren gaan. Toch verdergaan?")

  // CONTEXTS --------------------------------------------------------------------------------------------------------------------

  const { user, employee } = useContext(UserContext);

  const {
    setShopId,
    shopDetail,
    shopBrands,
    loadShopProspections
  } = useContext(ShopDetailContext);

  // Set shop id
  useEffect(() => {
    if (shopId) {
      if (Number.isNaN(parseInt(shopId))) {
        // If shopId cannot be set (e.g. undefined), navigate to NotFound page
        navigate("/404");
      }
      else {
        if (!shopDetail) {
          setShopId(parseInt(shopId));
        }
      }
    }
  }, [])

  const {
    allBrands,
    competitorBrands,
    loadContactInfo,
    prospectionBrands,
    setProspectionBrands,
    prospectionCompetitorBrands,
    setProspectionCompetitorBrands,
    prospectionBrandInterests,
    setProspectionBrandInterests,
    toDos,
    setToDos,
    addToDo,
    addProspection,
    updateProspectionBrands,
    updateProspectionCompetitorBrands,
    updateProspectionBrandInterests,
    updateProspectionToDos,
    updateToDoEmployees,
  } = useContext(NewProspectionContext);


  // INPUT FIELDS --------------------------------------------------------------------------------------------------------------------

  const [visitDate, setVisitDate] = useState<Date>(new Date());
  const [contactType, setContactType] = useState<number>(4);
  const [contactName, setContactName] = useState<string>("");
  const [contactEmail, setContactEmail] = useState<string>("");
  const [contactPhone, setContactPhone] = useState<string>("");
  const [visitType, setVisitType] = useState<number>(4);
  const [visitContext, setVisitContext] = useState<string>("");
  const [newBrands, setNewBrands] = useState<string>("");
  const [bestBrands, setBestBrands] = useState<string>("");
  const [worstBrands, setWorstBrands] = useState<string>("");
  const [terminatedBrands, setTerminatedBrands] = useState<string>("");
  const [trends, setTrends] = useState<string>("");
  const [feedback, setFeedback] = useState<string>("");


  // CONTACT INFO -----------------------------------------------------------------------------------------------------------

  const [contactInfo, setContactInfo] = useState<IContactInfo>();

  // checkmark validation states
  const [nameChecked, setNameChecked] = useState<boolean>(true);
  const [emailChecked, setEmailChecked] = useState<boolean>(true);
  const [phoneChecked, setPhoneChecked] = useState<boolean>(true);

  async function loadContactInfoFromDb(shopId: number, contactTypeId: number) {
    const loadedContactInfo = await loadContactInfo(shopId, contactTypeId);
    setContactInfo(loadedContactInfo);
  }

  useEffect(() => {
    let contactTypeCast: number = 0;

    // 1) Set contact type
    // 2) Automatic checkmark validation for salesperson/other
    switch (contactType) {
      case 1:
        contactTypeCast = 5; // Owner
        setNameChecked(false); setEmailChecked(false); setPhoneChecked(false);
        break;
      case 2:
        contactTypeCast = 6; // Buyer
        setNameChecked(false); setEmailChecked(false); setPhoneChecked(false);
        break;
      case 3:
        contactTypeCast = 7; // SalesPerson / ShopManager
        setNameChecked(true); setEmailChecked(true); setPhoneChecked(true);
        break;
      default:
        setNameChecked(true); setEmailChecked(true); setPhoneChecked(true);
        setContactInfo(undefined);
        break;
    }

    // Load specific contact info from db depending on selected contact type
    if (shopId && contactTypeCast != 0) {
      loadContactInfoFromDb(+shopId, contactTypeCast);
    }
  }, [contactType])


  // TODOS --------------------------------------------------------------------------------------------------------------------

  // CONTACT INFO TODOS 

  useEffect(() => {
    const newContactName = `${contactName.length > 1 ? `Contact naam: ${contactName}` : ""}`
    const newContactEmail = `${contactEmail.length > 1 ? `Contact email: ${contactEmail}` : ""}`
    const newContactPhone = `${contactPhone.length > 1 ? `Contact telefoon: ${contactPhone}` : ""}`
    const newContactInfo = `${newContactName.trim() != "" ? `${newContactName}\n` : ""}${newContactEmail.trim() != "" ? `${newContactEmail}\n` : ""}${newContactPhone.trim() != "" ? `${newContactPhone}` : ""}`;

    // Create todo for each interest
    let contactInfoToDo = {
      id: uuidv4(), // generate temporary unique id
      name: "Nieuwe contact info",
      remarks: newContactInfo,
      employees: [], // Initialize as empty until query assigns group of employees
      toDoStatusId: 1, // HARDCODED = "Ongoing"
      toDoTypeId: 1, // HARDCODED = "New contact info"
    };

    // Filter out contact info, as to only replace that todo item
    const toDosWithoutContact = toDos.filter(x => x.toDoTypeId !== 1);

    // Only add contact info, if there are new contact info values
    let newToDos = [...toDosWithoutContact];
    if (contactName.trim() != "" || contactEmail.trim() != "" || contactPhone.trim() != "") {
      newToDos = [...toDosWithoutContact, contactInfoToDo];
    }

    setToDos(newToDos);
  }, [contactName, contactEmail, contactPhone, contactType])

  // NEW BRANDS TODOS

  useEffect(() => {
    // Update newBrands toDo item
    let newBrandsToDo = {
      id: uuidv4(), // generate temporary unique id
      name: "Nieuwe brands",
      remarks: newBrands,
      employees: [], // Initialize as empty until query assigns group of employees
      toDoStatusId: 1, // HARDCODED = "Ongoing"
      toDoTypeId: 2, // HARDCODED = "New brands"
    };

    // Filter out newBrands, as to only replace that todo item
    const toDosWithoutNewBrands = toDos.filter(x => x.toDoTypeId !== 2);

    // Only add newBrandsToDo if newBrands is not empty
    let newToDos = [...toDosWithoutNewBrands];
    if (newBrands && newBrands.trim() != "") {
      newToDos = [...toDosWithoutNewBrands, newBrandsToDo]
    }

    setToDos(newToDos);
  }, [newBrands])

  // PROSPECTION BRAND INTEREST TODOS 

  useEffect(() => {
    let brandInterestsNames = prospectionBrandInterests.map(i => `Merk: ${i.brandName}${i.remark ? `\nOpmerking: ${i.remark}` : ""}\n`).join('\n');

    // Create one todo for all brand interests
    let brandInterestToDo = {
      id: uuidv4(), // generate temporary unique id
      name: "FC70 brand interesses",
      remarks: brandInterestsNames,
      employees: [], // Initialize as empty until query assigns group of employees
      toDoStatusId: 1, // HARDCODED = "Ongoing"
      toDoTypeId: 3, // HARDCODED = "Brand interests"
    };

    // Filter out brand interests, as to only replace that todo item
    const toDosWithoutBrandInterests = toDos.filter(x => x.toDoTypeId !== 3);

    // Only add brand interests, if there are any
    let newToDos = [...toDosWithoutBrandInterests];
    if (prospectionBrandInterests.length > 0) {
      newToDos = [...toDosWithoutBrandInterests, brandInterestToDo];
    }

    setToDos(newToDos);
  }, [prospectionBrandInterests])


  // REACT-SELECT -------------------------------------------------------------------------------------------------------------------

  // Competitor brand options for react-select

  const [competitorBrandsOptions, setCompetitorBrandsOptions] = useState<OptionType[]>([]);
  const [selectedCompetitorBrands, setSelectedCompetitorBrands] = useState<OptionType[]>([]);

  useEffect(() => {
    const isValidCompetitorBrand = (competitorBrand: ICompetitorBrand) =>
      !!competitorBrand && !!competitorBrand.id && !!competitorBrand.name;

    let competitorBrandOptions: OptionType[] = competitorBrands
      .filter(isValidCompetitorBrand)
      .map((competitorBrand) => ({
        value: competitorBrand.id.toString(),
        label: competitorBrand.name
      }));
    setCompetitorBrandsOptions(competitorBrandOptions);
  }, [competitorBrands])

  // Brand interest options for react-select

  const [brandInterestOptions, setBrandInterestOptions] = useState<OptionType[]>([]);
  const [selectedBrandInterests, setSelectedBrandInterests] = useState<OptionType[]>([]);

  useEffect(() => {
    const isValidBrand = (brand: IBrand) =>
      !!brand && !!brand.id && !!brand.name;

    let brandOptions: OptionType[] = allBrands
      .filter(isValidBrand)
      .map((brand) => ({
        value: brand.id.toString(),
        label: brand.name
      }));
    setBrandInterestOptions(brandOptions);
  }, [allBrands])


  // PROSPECTION BRANDS --------------------------------------------------------------------------------------------------------------------

  // ShopBrands are set as default prospection brands, before sellout/remark is added through the form
  useEffect(() => {
    console.log("Setting default prospection brands")
    const defaultProspectionBrands: IProspectionBrand[] = shopBrands.map(x => ({ brandId: x.id, brandName: x.name }));
    setProspectionBrands(defaultProspectionBrands);
    console.log("Set default prospection brands")
    console.log(defaultProspectionBrands)
  }, [shopBrands])


  // FORM WIZARD VALIDATION ------------------------------------------------------------------------------------------------------------------------------------

  const [contactErrorMsg, setContactErrorMsg] = useState<string>();
  const contactErrorRef = useRef<HTMLDivElement | null>(null);
  const showNameBorder = contactErrorMsg && !nameChecked && contactName.trim().length < 1;
  const showEmailBorder = contactErrorMsg && !emailChecked && contactEmail.trim().length < 1;
  const showPhoneBorder = contactErrorMsg && !phoneChecked && contactPhone.trim().length < 1;
  const validContact = (contactType === 3 || contactType === 4) ||
    (nameChecked && emailChecked && phoneChecked);

  const checkValidateContactTab = () => {
    if (!nameChecked || !emailChecked || !phoneChecked) {
      return false;
    }
    return true;
  };

  const contactTabError = () => {
    setContactErrorMsg("Gelieve de nodige contact informatie af te vinken.");
  };

  // Trends & feedback validation

  const [feedbackErrorMsg, setFeedbackErrorMsg] = useState<string>();
  const feedbackErrorRef = useRef<HTMLDivElement | null>(null);
  const showTrendsBorder = feedbackErrorMsg && trends.trim().length < 1;
  const showFeedbackBorder = feedbackErrorMsg && feedback.trim().length < 1;

  const checkValidateFeedbackTab = () => {
    if (trends.trim() === "" || feedback.trim() === "") {
      return false;
    }
    return true;
  };

  const feedbackError = () => {
    setFeedbackErrorMsg("Gelieve de verplichte velden in te vullen.");
  };


  // SUBMIT / ADD PROSPECTION TO DB ------------------------------------------------------------------------------------------------------------------------------------

  const [loading, setLoading] = useState<boolean>(false);
  const [isButtonDisabled, setIsButtonDisabled] = useState(false);
  const [submitErrorMsg, setSubmitErrorMsg] = useState<string>();
  const submitErrorRef = useRef<HTMLDivElement | null>(null);

  async function handleComplete() {
    // Allow form to be submitted & navigation afterwards
    setPreventLeaving(false);

    try {
      console.log("Start newProspection handleComplete");
      setLoading(true);
      setIsButtonDisabled(true);
      setSubmitErrorMsg(undefined);

      if (!user?.id || !employee?.id) {
        throw Error("Geen geldige gebruiker. Probeer opnieuw in te loggen.");
      }

      if (!shopId) {
        throw Error;
      }

      const newProspection: IProspectionDetail = {
        shopId: Number(shopId),
        userCreatedId: Number(user.id),
        employeeId: Number(employee.id),
        visitDate: visitDate,
        dateCreated: new Date(),
        dateLastUpdated: new Date(),
        contactTypeId: contactType,
        contactName: contactName,
        contactEmail: contactEmail,
        contactPhone: contactPhone,
        visitTypeId: visitType,
        visitContext: visitContext,
        newBrands: newBrands,
        bestBrands: bestBrands,
        worstBrands: worstBrands,
        terminatedBrands: terminatedBrands,
        trends: trends,
        extra: feedback
      }

      // Add new todos, save in new array to get toDos with id, and await response
      const addedToDos: IToDo[] = [];
      for (let toDo of toDos) {

        const addedToDo = await addToDo({
          remarks: toDo.remarks,
          toDoStatusId: toDo.toDoStatusId,
          toDoTypeId: toDo.toDoTypeId,
          name: toDo.name,
          dateCreated: new Date(),
          userCreatedId: user.id,
        });

        // If new toDo is successfully added, proceed
        if (addedToDo) {
          addedToDos.push(addedToDo);

          // Update todo-employees relationship 
          if (toDo.employees && addedToDo.id) {
            await updateToDoEmployees(+addedToDo.id, toDo.employees);
          }
        }
      }
      console.log("Todos added to db", addedToDos);

      // Add new prospection and await response
      const createdProspection = await addProspection(newProspection);
      console.log("New prospection added")

      // If prospection was successfully added, proceed
      if (createdProspection && createdProspection.id) {

        // Get id from new prospection
        const prospectionId = createdProspection.id;

        // Update the brand relationships
        await updateProspectionBrands(prospectionId, prospectionBrands);
        await updateProspectionBrandInterests(prospectionId, prospectionBrandInterests);
        await updateProspectionCompetitorBrands(prospectionId, prospectionCompetitorBrands);
        console.log("Prospection/brand updates completed successfully.");

        // Update the todo relationship
        let newProspectionToDos: IProspectionToDo[] = [];
        for (let toDo of addedToDos) {
          if (toDo.id) {
            newProspectionToDos.push({
              prospectionId: prospectionId,
              toDoId: +toDo.id,
            })
          }
        };
        await updateProspectionToDos(prospectionId, newProspectionToDos);
        console.log("Prospection todos updates completed successfully.");

        // Reload shopProspections for newly added prospection
        await loadShopProspections(Number(shopId));

        console.log("End newProspection handleComplete");

        navigate(`/shop/${shopId}`);

      } else {
        console.error("Failed to add new prospection. Updates aborted.");
      }

    } catch (error) {
      console.log(error);
      let message = "Er ging iets mis bij het verzenden. Probeer het later opnieuw."
      if (error instanceof Error) {
        if (error.message.includes("gebruiker")) message = error.message
      }
      setSubmitErrorMsg(message);
    } finally {
      setLoading(false);
      setIsButtonDisabled(false);
    }
  };

  return (
    <main className={styles.main}>

      <FormWizard
        color="black"
        title="Nieuwe prospectie"
        nextButtonText="Volgende"
        backButtonText="Vorige"
        finishButtonTemplate={(handleComplete) => (
          <button
            className="wizard-footer-right"
            onClick={handleComplete}
            disabled={isButtonDisabled}
          >
            <div className={styles.loading}>
              {loading ? <span>Verzenden...</span> : <span>Verzenden</span>} {/* Show "Verzenden" when not loading */}
              {loading && <CustomLoader />} {/* Show spinner if loading */}
            </div>
          </button>
        )}
        layout="horizontal"
        stepSize="sm"
        onComplete={handleComplete}>


        {/* CONTACT INFO ------------------------------------------------------------------------------------------------------------------------- */}

        <FormWizard.TabContent
          title={"Info"}
          icon={<AiOutlineCheck color="lightgrey" />}   >

          {/* SHOP DETAIL INFO */}
          {shopDetail && <ShopDetailCard shop={shopDetail} />}

          {/* VISIT DATE */}
          <fieldset>
            <legend>Datum van prospectie</legend>
            <input
              type="date"
              value={visitDate ? visitDate.toISOString().substring(0, 10) : ''}
              onChange={(e) => setVisitDate(new Date(e.target.value))}
              onClick={(e) => e.currentTarget.showPicker()}
            />
          </fieldset>

          <h3 className={styles.h3}>Contact</h3>

          {/* CONTACT TYPE */}
          <fieldset className={styles.radioContainer}>
            <legend>Contact type</legend>
            <label>
              <input type="radio" name="role" value="1"
                onChange={(e) => setContactType(+e.target.value)} checked={contactType === 1} />
              Eigenaar
            </label>
            <label>
              <input type="radio" name="role" value="2"
                onChange={(e) => setContactType(+e.target.value)} checked={contactType === 2} />
              Koper
            </label>
            <label>
              <input type="radio" name="role" value="3"
                onChange={(e) => setContactType(+e.target.value)} checked={contactType === 3} />
              Verkoper
            </label>
            <label>
              <input type="radio" name="role" value="4"
                onChange={(e) => setContactType(+e.target.value)} checked={contactType === 4} />
              Overig
            </label>
          </fieldset>

          {/* CONTACT NAME */}
          <fieldset className={showNameBorder ? styles.errorBorder : ""}>
            <legend>Contact naam
              {/* Required if owner or buyer */}
              {(contactType == 1 || contactType == 2) && <span className={styles.required}> *</span>}
            </legend>
            <p>Naam: {contactInfo?.name ?? "N/A"}</p>
            <input
              type='text'
              placeholder='Update naam...'
              value={contactName}
              onChange={(e) => {
                setContactName(e.target.value);
                // If contact name has any value, consider automatically checked
                if (e.target.value.trim() != "") setNameChecked(true);
                else setNameChecked(false);
              }} />
            {/* Checkbox validation (only if contact type is owner or buyer) */}
            {(contactType == 1 || contactType == 2) &&
              <div className={styles.checkbox}>
                <label htmlFor="nameValidation">
                  {/* If new name is set, checkbox will be automatically validated */}
                  {contactName.trim() != "" ? "Nieuwe" : "Huidige"} informatie is correct&nbsp;
                  <input
                    type="checkbox"
                    name="nameValidation"
                    onChange={(e) => setNameChecked(e.target.checked)}
                    checked={nameChecked}
                  />
                </label>
              </div>
            }
          </fieldset>

          {/* Only show email and phone if contact type is owener or buyer */}
          {(contactType == 1 || contactType == 2) &&
            <>
              {/* CONTACT EMAIL */}
              <fieldset className={showEmailBorder ? styles.errorBorder : ""}>
                <legend>Contact email
                  {/* Required if owner or buyer */}
                  {(contactType == 1 || contactType == 2) && <span className={styles.required}> *</span>}
                </legend>
                <p>Email: {contactInfo?.email ?? "N/A"}</p>
                <input
                  type='text'
                  placeholder='Update email...'
                  value={contactEmail}
                  onChange={(e) => {
                    setContactEmail(e.target.value);
                    // If contact email has any value, consider automatically checked
                    if (e.target.value.trim() != "") setEmailChecked(true);
                    else setEmailChecked(false);
                  }}>
                </input>
                {/* Checkbox validation */}
                <div className={styles.checkbox}>
                  <label htmlFor="emailValidation">
                    {/* If new email is set, checkbox will be automatically validated */}
                    {contactEmail.trim() != "" ? "Nieuwe" : "Huidige"} informatie is correct&nbsp;
                    <input
                      type="checkbox"
                      name="emailValidation"
                      onChange={(e) => setEmailChecked(e.target.checked)}
                      checked={emailChecked}
                    />
                  </label>
                </div>
              </fieldset>

              {/* CONTACT PHONE */}
              <fieldset className={showPhoneBorder ? styles.errorBorder : ""}>
                <legend>Contact phone
                  {/* Required if owner or buyer */}
                  {(contactType == 1 || contactType == 2) && <span className={styles.required}> *</span>}
                </legend>
                <p>Telefoonnummer: {contactInfo?.phoneNumber ?? "N/A"}</p>
                <input
                  type='text'
                  placeholder='Update telefoonnummer...'
                  value={contactPhone}
                  onChange={(e) => {
                    setContactPhone(e.target.value);
                    // If contact phone has any value, consider automatically checked
                    if (e.target.value.trim() != "") setPhoneChecked(true);
                    else setPhoneChecked(false);
                  }} />
                {/* Checkbox validation */}
                <div className={styles.checkbox}>
                  <label htmlFor="phoneValidation">
                    {/* If new phone number is set, checkbox will be automatically validated */}
                    {contactPhone.trim() != "" ? "Nieuwe" : "Huidige"} informatie is correct&nbsp;
                    <input
                      type="checkbox"
                      name="phoneValidation"
                      onChange={(e) => setPhoneChecked(e.target.checked)}
                      checked={phoneChecked}
                    />
                  </label>
                </div>
              </fieldset>
            </>
          }

          <h3 className={styles.h3}>Bezoek</h3>

          {/* VISIT TYPE */}
          <fieldset className={styles.radioContainer}>
            <legend>Bezoek type</legend>
            <label>
              <input type="radio" name="visit" value="1"
                onChange={(e) => setVisitType(+e.target.value)}
                checked={visitType === 1} />
              Prospectie
            </label>
            <label>
              <input type="radio" name="visit" value="2"
                onChange={(e) => setVisitType(+e.target.value)}
                checked={visitType === 2} />
              Swap
            </label>
            <label>
              <input type="radio" name="visit" value="3"
                onChange={(e) => setVisitType(+e.target.value)}
                checked={visitType === 3} />
              Key account meeting
            </label>
            <label>
              <input type="radio" name="visit" value="4"
                onChange={(e) => setVisitType(+e.target.value)}
                checked={visitType === 4} />
              Overig
            </label>
          </fieldset>

          {/* VISIT CONTEXT */}
          <fieldset>
            <legend>Reden van bezoek</legend>
            <textarea
              maxLength={500}
              rows={3}
              value={visitContext}
              placeholder='Dit bezoek werd gepland ter gelegenheid van...'
              onChange={(e) => setVisitContext(e.target.value)} />
          </fieldset>

          {/* ERROR MESSAGE */}
          {contactErrorMsg && (!validContact) &&
            <div
              ref={contactErrorRef}
              className={styles.error}
            >
              <p>{contactErrorMsg}</p>
              <button
                className={styles.close}
                onClick={() => setContactErrorMsg(undefined)} >
                X
              </button>
            </div>}

        </FormWizard.TabContent>


        {/* BRANDMIX --------------------------------------------------------------------------------------------------------------------------- */}

        <FormWizard.TabContent
          title={"Brandmix"}
          icon={<AiOutlineCheck color="lightgrey" />}
          isValid={checkValidateContactTab()}
          validationError={contactTabError}>

          <h3 className={styles.h3}>Brandmix</h3>

          <fieldset className={styles.brandList}>
            {/* FC70 BRANDS */}
            <h4 className={styles.h4}>FC70 Brands</h4>
            {prospectionBrands.length > 0
              ? <ul className={styles.bulletPoints}>
                {prospectionBrands.map((brand, i) => (
                  <li key={i}>
                    {brand.brandName}
                  </li>
                ))
                }
              </ul>
              : <p>Geen Fashion Club 70 brands beschikbaar.</p>
            }
          </fieldset>

          <fieldset>
            {/* COMPETITOR BRANDS */}
            <h4 className={styles.h4}>Referentiemerken</h4>
            <p className={styles.normalLineHeight}>Niet-FC70 merken die de winkel momenteel aanbiedt:</p>

            {competitorBrands && <Select<OptionType, true>
              theme={customTheme}
              className="basic-multi-select"
              classNamePrefix="select"
              isMulti
              isDisabled={competitorBrandsOptions.length > 0 ? false : true}
              placeholder={competitorBrandsOptions.length > 0 ? "Selecteer..." : <CustomLoader />}
              value={selectedCompetitorBrands}
              isClearable={true}
              isSearchable={true}
              name="competitorBrand"
              filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
              maxMenuHeight={200} // Limit height to improve rendering
              options={competitorBrandsOptions}
              components={{ // Custom components to make use of react-window to improve rendering
                MenuList,
                Option,
              }}
              onChange={(selectedOptions: MultiValue<OptionType>) => {
                setSelectedCompetitorBrands([...selectedOptions]);
                const newProspectionCompetitorBrands: IProspectionCompetitorBrand[] = selectedOptions
                  .map((x: OptionType) => ({
                    competitorBrandId: +x.value,
                    competitorBrandName: x.label,
                  }));
                setProspectionCompetitorBrands(newProspectionCompetitorBrands);
              }}
            />}
          </fieldset>

          <fieldset>
            {/* NEW BRANDS */}
            <h4 className={styles.h4}>Nieuwe merken</h4>
            <p className={styles.normalLineHeight}>Merken die u niet terugvond in de lijst hierboven:</p>
            <textarea
              value={newBrands}
              placeholder="Nieuw merk met collectie voor dames/heren/kinderen..."
              onChange={(e) => {
                setNewBrands(e.target.value);
              }} />
          </fieldset>

        </FormWizard.TabContent>


        {/* BEST / WORST / TERMINATED BRANDS ------------------------------------------------------------------------------------------------------------ */}

        <FormWizard.TabContent
          title={"Algemeen"}
          icon={<AiOutlineCheck color="lightgrey" />}>

          <h3 className={styles.h3}>Algemene situatie</h3>

          <fieldset>
            <legend>Beste merken</legend>
            <textarea
              value={bestBrands}
              placeholder='De beste merken dit seizoen waren...'
              onChange={(e) => setBestBrands(e.target.value)} />
          </fieldset>

          <fieldset>
            <legend>Slechtste merken</legend>
            <textarea
              value={worstBrands}
              placeholder='De slechtste merken dit seizoen waren...'
              onChange={(e) => setWorstBrands(e.target.value)} />
          </fieldset>

          <fieldset>
            <legend>Merken die niet meer ingekocht worden</legend>
            <textarea
              value={terminatedBrands}
              placeholder='Deze merken worden niet meer ingekocht volgend seizoen...'
              onChange={(e) => setTerminatedBrands(e.target.value)} />
          </fieldset>

        </FormWizard.TabContent>


        {/* FC70 BRANDS SELLOUT ------------------------------------------------------------------------------------------------------------------------- */}

        <FormWizard.TabContent
          title={"FC70"}
          icon={<AiOutlineCheck color="lightgrey" />}>

          <h3 className={styles.h3}>FC70 overzicht</h3>

          {prospectionBrands.map((brand, i) => <div key={i}>
            <BrandInput brand={{ brandId: brand.brandId, brandName: brand.brandName }} />
          </div>)}

          {prospectionBrands.length === 0 &&
            <p className={styles.marginLeft}>Geen FC70 merken beschikbaar.</p>}

        </FormWizard.TabContent>


        {/* BRANDS INTERESTS ------------------------------------------------------------------------------------------------------------------------- */}

        <FormWizard.TabContent
          title={"Interesses"}
          icon={<AiOutlineCheck color="lightgrey" />}>

          <fieldset className={styles.interestSelect}>
            <h3>Interesse FC70 merken</h3>

            <p className={styles.normalLineHeight}>Indien er interesse was in bepaalde FC70 merken, gelieve deze te selecteren met de nodige opmerkingen.</p>

            <Select<OptionType, true>
              theme={customTheme}
              className="basic-multi-select"
              classNamePrefix="select"
              isMulti
              isDisabled={brandInterestOptions.length > 0 ? false : true}
              placeholder={brandInterestOptions.length > 0 ? "Selecteer..." : <CustomLoader />}
              value={selectedBrandInterests}
              isClearable={true}
              isSearchable={true}
              name="brandInterest"
              filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
              maxMenuHeight={200} // Limit height to improve rendering
              options={brandInterestOptions}
              components={{ // Custom components to make use of react-window to improve rendering
                MenuList,
                Option,
              }}
              onChange={(selectedOptions: MultiValue<OptionType>) => {
                setSelectedBrandInterests([...selectedOptions]);
                const newBrandInterests: IProspectionBrandInterest[] = selectedOptions
                  .map((x: OptionType) => ({
                    brandId: +x.value,
                    brandName: x.label,
                  }));
                // set prospection brand interests
                setProspectionBrandInterests(newBrandInterests);
              }}
            />
          </fieldset>

          <div>
            {prospectionBrandInterests.map((brand, i) => <div key={i}>
              <BrandInterestCard brand={brand} selected={selectedBrandInterests} setSelected={setSelectedBrandInterests} />
            </div>
            )}
          </div>

        </FormWizard.TabContent>


        {/* FEEDBACK -------------------------------------------------------------------------------------------------------------------------------- */}

        <FormWizard.TabContent
          title={"Feedback"}
          icon={<AiOutlineCheck color="lightgrey" />}>

          <h3 className={styles.h3}>Feedback</h3>

          <fieldset className={showTrendsBorder ? styles.errorBorder : ""}>
            <legend>Trends en noden in de markt
              <span className={styles.required}> *</span>
            </legend>
            <textarea rows={4} value={trends} placeholder='Trends en noden in de markt...'
              onChange={(e) => setTrends(e.target.value)} />
          </fieldset>

          <fieldset className={showFeedbackBorder ? styles.errorBorder : ""}>
            <legend>Extra opmerkingen/feedback
              <span className={styles.required}> *</span>
            </legend>
            <textarea rows={4} value={feedback} placeholder='Er kwam nog extra feedback met betrekking tot...'
              onChange={(e) => setFeedback(e.target.value)} />
          </fieldset>

          {feedbackErrorMsg && (!feedback || !trends) &&
            <div
              ref={feedbackErrorRef}
              className={styles.error}
            >
              <p>{feedbackErrorMsg}</p>
              <button
                className={styles.close}
                onClick={() => setFeedbackErrorMsg(undefined)} >
                X
              </button>
            </div>}

        </FormWizard.TabContent>


        {/* TO DOS ------------------------------------------------------------------------------------------------------------------------------------ */}

        <FormWizard.TabContent
          title={"Opvolging"}
          icon={<AiOutlineCheck color="lightgrey" />}
          isValid={checkValidateFeedbackTab()}
          validationError={feedbackError}>

          <section className={styles.padding}>
            <h3>Opvolging</h3>
            <div>
              <p className={styles.normalLineHeight}>Hier kan u vrijblijvend items toevoegen die op basis van uw verslag moeten opgevolgd worden.</p>
              <small className={styles.automaticallyAdded}>
                <p className={styles.normalLineHeight}>Worden automatisch opgevolgd:</p>
                <ul className={styles.bulletPoints}>
                  <li>Nieuwe contact info</li>
                  <li>Nieuwe brands</li>
                  <li>Brands interesses</li>
                </ul>
              </small>
            </div>
          </section>

          <ToDoModule toDos={toDos} setToDos={setToDos} />

        </FormWizard.TabContent>

      </FormWizard>

      {submitErrorMsg &&
        <div
          ref={submitErrorRef}
          className={styles.error}
        >
          <p>{submitErrorMsg}</p>
          <button
            className={styles.close}
            onClick={() => setSubmitErrorMsg(undefined)} >
            X
          </button>
        </div>}
    </main >
  );
};
