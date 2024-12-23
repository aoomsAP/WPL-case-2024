// react utilities
import { useContext, useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
// styles
import styles from "./NewProspection.module.css";
// types
import { ICompetitorBrand, IContactInfo, IProspectionBrand, IProspectionCompetitorBrand, IProspectionDetail, IProspectionToDo, IToDo, OptionType } from '../../types';
// components
import BrandTag from '../../components/BrandTag/BrandTag';
import BrandCardInput from '../../components/BrandCardInput/BrandCardInput';
import BrandInterestCard from '../../components/BrandCardInput/BrandInterestCard';
import { ShopDetailCard } from '../../components/ShopDetailCard/ShopDetailCard';
import ToDoModule from '../../components/ToDoModule/ToDoModule';
// contexts
import { ShopDetailContext } from '../../contexts/ShopDetailContext';
import { UserContext } from '../../contexts/UserContext';
import { NewProspectionContext } from '../../contexts/NewProspectionContext';
// react-select
import Select, { createFilter, MultiValue } from 'react-select';
import MenuList from "../../components/ToDoModule/MenuList/MenuList"; // Custom MenuList
import Option from "../../components/ToDoModule/Option/Option"; // Custom Option
// form-wizard
import FormWizard from "react-form-wizard-component";
import "react-form-wizard-component/dist/style.css";
// icons
import { AiOutlineCheck } from "react-icons/ai";
// uuid
import { v4 as uuidv4 } from 'uuid';

export const NewProspection = () => {

  const { shopId } = useParams<{ shopId: string }>();
  const navigate = useNavigate();

  // Contexts --------------------------------------------------------------------------------------------------------------------

  const { user, employee } = useContext(UserContext);

  const {
    setShopId,
    shopDetail,
    shopBrands
  } = useContext(ShopDetailContext);

  // Set shop id
  useEffect(() => {
    if (shopId) {
      if (Number.isNaN(parseInt(shopId))) {
        // If shopId cannot be set (e.g. undefined), navigate to NotFound page
        navigate("/404");
      }
      else {
        setShopId(parseInt(shopId));
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

  // Input fields / states --------------------------------------------------------------------------------------------------------------------

  // prospection fields
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

  // contact info
  const [contactInfo, setContactInfo] = useState<IContactInfo>();

  // validation
  const [nameChecked, setNameChecked] = useState<boolean>(true);
  const [emailChecked, setEmailChecked] = useState<boolean>(true);
  const [phoneChecked, setPhoneChecked] = useState<boolean>(true);

  // window size
  const [windowWidth, setWindowWidth] = useState<number>(window.innerWidth);

  // Window width ----------------------------------------------------------------------------------------------------------

  useEffect(() => {
    const updateWidth = () => {
      setWindowWidth(window.innerWidth);
    };

    const interval = setInterval(updateWidth, 500);

    updateWidth();

    return () => clearInterval(interval);
  }, []);


  // Contact info -----------------------------------------------------------------------------------------------------------

  async function loadContactInfoFromDb(shopId: number, contactTypeId: number) {
    const loadedContactInfo = await loadContactInfo(shopId, contactTypeId);
    setContactInfo(loadedContactInfo);
  }

  useEffect(() => {
    let contactTypeCast: number = 0;

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

    if (shopId && contactTypeCast != 0) {
      loadContactInfoFromDb(+shopId, contactTypeCast);
    }
  }, [contactType])


  // Todos --------------------------------------------------------------------------------------------------------------------

  // Contact info todos 
  useEffect(() => {
    if (contactName != "" || contactEmail != "" || contactPhone != "") {

      const newContactName = `${contactName.length > 1 ? `Contact naam: ${contactName}` : ""}`
      const newContactEmail = `${contactEmail.length > 1 ? `Contact email: ${contactEmail}` : ""}`
      const newContactPhone = `${contactPhone.length > 1 ? `Contact telefoon: ${contactPhone}` : ""}`
      const newContactInfo = `${newContactName != "" ? `${newContactName}\n` : ""}${newContactEmail != "" ? `${newContactEmail}\n` : ""}${newContactPhone != "" ? `${newContactPhone}` : ""}`;

      // Create todo for each interest
      let contactInfoToDo = {
        id: uuidv4(), // generate temporary unique id
        name: "Nieuwe contact info",
        remarks: newContactInfo,
        employees: [], // Initialize as empty until query assigns group of employees
        toDoStatusId: 1, // HARDCODED = "Ongoing"
        toDoTypeId: 1, // HARDCODED = "New contact info"
      };

      // Filter out contact info todo, as to only replace that one
      const toDosWithoutContact = toDos.filter(x => x.toDoTypeId !== 1);
      const newToDos = [...toDosWithoutContact, contactInfoToDo];
      setToDos(newToDos);
    }
  }, [contactName, contactEmail, contactPhone, contactType])

  // NewBrands todos 
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
    // Filter out newBrands todos, as to only replace that one
    const toDosWithoutNewBrands = toDos.filter(x => x.toDoTypeId !== 2);
    const newToDos = [...toDosWithoutNewBrands, newBrandsToDo];
    setToDos(newToDos);
  }, [newBrands])

  // Prospection brand interest todos 
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

    // Filter out FC70 brand interest todos, as to only replace those
    const toDosWithoutBrandInterests = toDos.filter(x => x.toDoTypeId !== 3);
    const newToDos = [...toDosWithoutBrandInterests, brandInterestToDo];
    setToDos(newToDos);
  }, [prospectionBrandInterests])


  // Select -------------------------------------------------------------------------------------------------------------------

  // Creating competitor brand options for react-select
  const [competitorBrandsOptions, setCompetitorBrandsOptions] = useState<OptionType[]>([]);
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

  // Search fields - react-select not (yet) implemented for brand interest seardch
  const [brandInterestSearch, setBrandInterestSearch] = useState<string>("");

  // Filter for interest search brands
  const brandInterestSearchFunc = allBrands.filter(brand => {

    if (prospectionBrandInterests.map(x => x.brandId).find(x => x === brand.id)) return false;

    if (brandInterestSearch.length < 3) return false;

    return brand.name.toLowerCase().includes(brandInterestSearch.toLowerCase());
  });


  // Default prospectionBrands --------------------------------------------------------------------------------------------------------------------

  useEffect(() => {
    console.log("Setting default prospection brands")
    const defaultProspectionBrands: IProspectionBrand[] = shopBrands.map(x => ({ brandId: x.id, brandName: x.name }));
    setProspectionBrands(defaultProspectionBrands);
    console.log("Set default prospection brands")
    console.log(defaultProspectionBrands)
  }, [shopBrands])


  // Form wizard validation ------------------------------------------------------------------------------------------------------------------------------------

  // Validate contact info tab
  const checkValidateContactTab = () => {
    if (!nameChecked || !emailChecked || !phoneChecked) {
      return false;
    }
    return true;
  };

  // Contact info tab error message
  const contactTabError = () => {
    alert("Gelieve de nodige contact informatie af te vinken.");
  };

  // Validate trends & feedback tab
  const checkValidateFeedbackTab = () => {
    if (trends === "" || feedback === "") {
      return false;
    }
    return true;
  };

  // Trends & feedback tab error messages
  const feedbackError = () => {
    alert("Gelieve de verplichte velden in te vullen.");
  };


  // Submit function ------------------------------------------------------------------------------------------------------------------------------------

  async function handleComplete() {
    try {
      console.log("Start newProspection handleComplete");

      if (!user?.id) {
        alert("Geen geldige gebruiker. Probeer opnieuw in the loggen.");
        throw Error("Invalid user id");
      }

      if (!employee?.id) {
        alert("Geen geldige gebruiker. Probeer opnieuw in the loggen.");
        throw Error("Invalid employee id");
      }

      const newProspection: IProspectionDetail = {
        shopId: Number(shopId),
        userId: +user.id,
        employeeId: +employee.id,
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

        console.log("End newProspection handleComplete");

        navigate(`/shop/${shopId}`);

      } else {
        console.error("Failed to add new prospection. Updates aborted.");
      }

    } catch (error) {
      console.error("Error in newProspection handleComplete: ", error);
    }
  };


  return (
    <main className={styles.main}>

      <FormWizard
        color="black"
        title="Nieuwe prospectie"
        nextButtonText="Volgende"
        backButtonText="Vorige"
        finishButtonText="Verzenden"
        layout="horizontal"
        stepSize="sm"
        onComplete={handleComplete}>


        {/* CONTACT INFO ------------------------------------------------------------------------------------------------------------------------- */}

        <FormWizard.TabContent
          title={windowWidth < 700 ? "" : "Info"}
          icon={<AiOutlineCheck color="#D4AF37" width={50} />}   >

          {/* Shop info */}
          {shopDetail && <ShopDetailCard shop={shopDetail} />}

          {/* Visit Date */}
          <fieldset>
            <legend>Datum van prospectie</legend>
            <input
              type="date"
              value={visitDate ? visitDate.toISOString().substring(0, 10) : ''}
              onChange={(e) => setVisitDate(new Date(e.target.value))}
            />
          </fieldset>

          <h3>Informatie</h3>

          {/* Contact type */}
          <fieldset>
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

          {/* Contact type */}
          <fieldset>
            <legend>Contact naam</legend>
            <p style={{ marginTop: 0 }}>Huidige naam: {contactInfo?.name ?? "Geen naam gevonden"}</p>
            <input
              type='text'
              placeholder='Update naam'
              value={contactName}
              onChange={(e) => {
                setContactName(e.target.value);
                // If contact name has any value, consider automatically checked
                if (e.target.value != "") setNameChecked(true);
                else setNameChecked(false);
              }} />

            {/* Checkbox validation */}
            {/* Only show if contact type is owner or buyer */}
            {(contactType == 1 || contactType == 2) && !nameChecked &&
              <div className={styles.checkbox}>
                <label htmlFor="nameValidation">
                  Geen informatie ontvangen&nbsp;
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
              <fieldset>
                <legend>Contact email</legend>
                <p style={{ marginTop: 0 }}>Huidige email: {contactInfo?.email ?? "Geen email gevonden"}</p>
                <input
                  type='text'
                  placeholder='Update email'
                  value={contactEmail}
                  onChange={(e) => {
                    setContactEmail(e.target.value);
                    // If contact email has any value, consider automatically checked
                    if (e.target.value != "") setEmailChecked(true);
                    else setEmailChecked(false);
                  }}>
                </input>

                {/* Checkbox validation */}
                {!emailChecked &&
                  <div className={styles.checkbox}>
                    <label htmlFor="emailValidation">
                      Geen informatie ontvangen&nbsp;
                      <input
                        type="checkbox"
                        name="emailValidation"
                        onChange={(e) => setEmailChecked(e.target.checked)}
                        checked={emailChecked}
                      />
                    </label>
                  </div>
                }
              </fieldset>

              <fieldset>
                <legend>Contact phone</legend>
                <p style={{ marginTop: 0 }}>Huidge telefoonnummer: {contactInfo?.phoneNumber ?? "Geen telefoonnummer gevonden"}</p>
                <input
                  type='text'
                  placeholder='Update telefoonnummer'
                  value={contactPhone}
                  onChange={(e) => {
                    setContactPhone(e.target.value);
                    // If contact phone has any value, consider automatically checked
                    if (e.target.value != "") setPhoneChecked(true);
                    else setPhoneChecked(false);

                  }} />

                {/* Checkbox validation */}
                {!phoneChecked &&
                  <div className={styles.checkbox}>
                    <label htmlFor="phoneValidation">
                      Geen informatie ontvangen&nbsp;
                      <input
                        type="checkbox"
                        name="phoneValidation"
                        onChange={(e) => setPhoneChecked(e.target.checked)}
                        checked={phoneChecked}
                      />
                    </label>
                  </div>
                }
              </fieldset>
            </>
          }

          <fieldset>
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

          <fieldset>
            <legend>Reden van bezoek</legend>

            <textarea
              maxLength={500}
              rows={3}
              value={visitContext}
              placeholder='Dit bezoek werd gepland ter gelegenheid van...'
              onChange={(e) => setVisitContext(e.target.value)} />

          </fieldset>

        </FormWizard.TabContent>


        {/* BRANDMIX --------------------------------------------------------------------------------------------------------------------------- */}

        <FormWizard.TabContent
          title={windowWidth < 700 ? "" : "Brandmix"}
          icon={<AiOutlineCheck color="#D4AF37" />}
          isValid={checkValidateContactTab()}
          validationError={contactTabError}>

          {/* FC70 BRANDS */}
          <h3>FC70 merken</h3>
          <div>
            {prospectionBrands.length > 0
              ? prospectionBrands.map((brand, i) => (
                <div key={i}>
                  <BrandTag brandId={brand.brandId} brandName={brand.brandName} type="brand" />
                </div>
              ))
              : "Geen Fashion Club 70 merken beschikbaar."}
          </div>

          {/* COMPETITOR BRANDS */}
          <h3>Referentiemerken</h3>

          {competitorBrands && <Select<OptionType, true>
            className="basic-multi-select"
            classNamePrefix="select"
            isMulti
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
              const newProspectionCompetitorBrands: IProspectionCompetitorBrand[] = selectedOptions
                .map((x: OptionType) => ({
                  competitorBrandId: +x.value,
                  competitorBrandName: x.label,
                }));
              setProspectionCompetitorBrands(newProspectionCompetitorBrands);
            }}
          />}

          {/* NEW BRANDS */}
          <h3>Nieuwe merken</h3>
          <legend>Merken die u niet terugvond in de lijst hierboven:</legend>
          <textarea
            value={newBrands}
            placeholder='Nieuwe merk met collectie voor dames/heren/kinderen'
            onChange={(e) => {
              setNewBrands(e.target.value);
            }} />

        </FormWizard.TabContent>


        {/* BEST / WORST / TERMINATED BRANDS ------------------------------------------------------------------------------------------------------------ */}

        <FormWizard.TabContent
          title={windowWidth < 700 ? " " : "Algemeen"}
          icon={<AiOutlineCheck color="#D4AF37" />}>

          <h3>Algemene situatie</h3>

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
          title={windowWidth < 700 ? " " : "FC70"}
          icon={<AiOutlineCheck color="#D4AF37" />}>

          <h3>FC70 overzicht</h3>

          {prospectionBrands.map((brand, i) => <div key={i}>
            <BrandCardInput brand={{ brandId: brand.brandId, brandName: brand.brandName }} />
          </div>)}
          {prospectionBrands.length === 0 && <p>Geen FC70 merken beschikbaar.</p>}

        </FormWizard.TabContent>

        <FormWizard.TabContent
          title={windowWidth < 700 ? "" : "Interesses"}
          icon={<AiOutlineCheck color="#D4AF37" />}>

          <h3>Interesse FC70 merken</h3>

          <input
            type="text"
            placeholder="Zoek..."
            value={brandInterestSearch}
            onChange={(e) => setBrandInterestSearch(e.target.value)} // Update state on input change
          />

          <ul className={styles.ul}>
            {brandInterestSearchFunc.length > 0 ? (
              brandInterestSearchFunc.map(brand => (
                <li key={brand.id} className={styles.li}
                  onClick={() => {
                    // set prospection brand interests
                    setProspectionBrandInterests([...prospectionBrandInterests, { brandId: brand.id, brandName: brand.name }]);

                    // clear search
                    setBrandInterestSearch("");
                  }}>
                  {brand.name}
                </li>
              ))
            ) : (
              brandInterestSearch.length < 3 ? (
                <p>Typ minstens 3 letters.</p>
              ) : (
                <p>Geen merken gevonden</p>
              )
            )}
          </ul>

          <div className={styles.cardsContainer}>
            {prospectionBrandInterests.map((brand, i) => <div key={i}>
              <BrandInterestCard brand={brand} />
            </div>
            )}
          </div>

        </FormWizard.TabContent>


        {/* FEEDBACK -------------------------------------------------------------------------------------------------------------------------------- */}

        <FormWizard.TabContent
          title={windowWidth < 700 ? " " : "Feedback"}
          icon={<AiOutlineCheck color="#D4AF37" />}>

          <h3>Feedback</h3>

          <fieldset>
            <legend>Trends en noden in de markt
              <span style={{ color: "red", fontSize: "20px", fontWeight: "bold" }}> *</span>
            </legend>
            <textarea rows={4} value={trends} placeholder='Trends en noden in de markt...'
              onChange={(e) => setTrends(e.target.value)} />
          </fieldset>

          <fieldset>
            <legend>Extra opmerkingen/feedback
              <span style={{ color: "red", fontSize: "20px", fontWeight: "bold" }}> *</span>
            </legend>
            <textarea rows={4} value={feedback} placeholder='Er kwam nog extra feedback met betrekking tot...'
              onChange={(e) => setFeedback(e.target.value)} />
          </fieldset>

        </FormWizard.TabContent>


        {/* TO DOS ------------------------------------------------------------------------------------------------------------------------------------ */}

        <FormWizard.TabContent
          title={windowWidth < 700 ? " " : "Opvolging"}
          icon={<AiOutlineCheck color="#D4AF37" />}
          isValid={checkValidateFeedbackTab()}
          validationError={feedbackError}>

          <h3>Takenlijst voor opvolging</h3>
          <p>Hier kan u items toevoegen die op basis van dit verslag moeten opgevolgd worden.</p>
          <small>
            <p>Worden automatisch toegevoegd:</p>
            <ul>
              <li>Nieuwe contact info</li>
              <li>Nieuwe brands</li>
              <li>Brands interesses</li>
            </ul>
          </small>

          <ToDoModule toDos={toDos} setToDos={setToDos} />

        </FormWizard.TabContent>

      </FormWizard>

    </main >
  );
};
