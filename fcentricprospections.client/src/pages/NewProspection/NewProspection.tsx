import styles from "./NewProspection.module.css";
import FormWizard from "react-form-wizard-component";
import "react-form-wizard-component/dist/style.css";
import { useContext, useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import BrandTag from '../../components/BrandTag/BrandTag';
import { NewProspectionContext } from '../../contexts/NewProspectionContext';
import { ICompetitorBrand, IContactInfo, IProspectionBrand, IProspectionCompetitorBrand, IProspectionDetail, IProspectionToDo, IToDo, OptionType } from '../../types';
import BrandCardInput from '../../components/BrandCardInput/BrandCardInput';
import BrandInterestCard from '../../components/BrandCardInput/BrandInterestCard';
import { AiOutlineCheck } from "react-icons/ai";
import { ShopDetailContext } from '../../contexts/ShopDetailContext';
import { ShopDetailCard } from '../../components/ShopDetailCard/ShopDetailCard';
import ToDoModule from '../../components/ToDoModule/ToDoModule';
import { UserContext } from '../../contexts/UserContext';
import Select, { createFilter, MultiValue } from 'react-select';
import MenuList from "../../components/ToDoModule/MenuList/MenuList"; // Custom MenuList
import Option from "../../components/ToDoModule/Option/Option"; // Custom Option
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

  useEffect(() => {
    if (shopId) {
      setShopId(shopId);
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
  } = useContext(NewProspectionContext);

  // Input fields / states --------------------------------------------------------------------------------------------------------------------

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

  const [contactInfo, setContactInfo] = useState<IContactInfo>();

  // Contact info -----------------------------------------------------------------------------------------------------------

  async function loadContactInfoFromDb(shopId: string, contactTypeId: number) {
    const loadedContactInfo = await loadContactInfo(shopId, contactTypeId);
    setContactInfo(loadedContactInfo);
  }

  useEffect(() => {

    let contactTypeCast: number = 0;

    switch (contactType) {
      case 1: contactTypeCast = 5; break; // Owner
      case 2: contactTypeCast = 6; break; // Buyer
      case 3: contactTypeCast = 7; break; // SalesPerson / ShopManager
      default: setContactInfo(undefined); break;
    }

    if (shopId && contactTypeCast != 0) {
      loadContactInfoFromDb(shopId, contactTypeCast);
    }
  }, [contactType])

  // Todos --------------------------------------------------------------------------------------------------------------------

  // Contact info todos 
  useEffect(() => {
    console.log("todos at contact useffect", toDos);

    if (contactName != "" || contactEmail != "" || contactPhone != "") {

      const newContactName = `${contactName.length > 1 ? `Contact naam: ${contactName}` : ""}`
      const newContactEmail = `${contactEmail.length > 1 ? `Contact email: ${contactEmail}` : ""}`
      const newContactPhone = `${contactPhone.length > 1 ? `Contact telefoon: ${contactPhone}` : ""}`

      // Create todo for each interest
      let contactInfoToDo = {
        id: uuidv4(), // generate temporary unique id
        name: "Nieuwe contact info",
        remarks: newContactName + (newContactName ? " - " : "") + newContactEmail + (newContactEmail ? " - " : "") + newContactPhone,
        employeeId: 0, // TO DO: WHO? DEFAULT? 0 WILL RESULT IN ERROR
        toDoStatusId: 1, // DEFAULT
      };

      // Filter out contact info todo, as to only replace that one
      const toDosWithoutContact = toDos.filter(x => x.name !== "Nieuwe contact info");
      const newToDos = [...toDosWithoutContact, contactInfoToDo];
      setToDos(newToDos);
    }
  }, [contactName, contactEmail, contactPhone, contactType])

  // NewBrands todos 
  useEffect(() => {
    console.log("todos at new brands useffect", toDos);

    // Update newBrands toDo item
    let newBrandsToDo = {
      id: uuidv4(), // generate temporary unique id
      name: "Nieuwe brands",
      remarks: newBrands,
      employeeId: 0, // TO DO: WHO? DEFAULT? 0 WILL RESULT IN ERROR
      toDoStatusId: 1, // DEFAULT
    };
    // Filter out newBrands todos, as to only replace that one
    const toDosWithoutNewBrands = toDos.filter(x => x.name !== "Nieuwe brands");
    const newToDos = [...toDosWithoutNewBrands, newBrandsToDo];
    setToDos(newToDos);
  }, [newBrands])

  // Prospection brand interest todos 
  useEffect(() => {
    console.log("todos at brandi nterest useffect", toDos);

    let newInterestToDos = [];

    // Create todo for each interest
    for (let interest of prospectionBrandInterests) {
      let brandInterestToDo = {
        id: uuidv4(), // generate temporary unique id
        name: "FC70 brand interesse",
        remarks: interest.brandName,
        employeeId: 0, // TO DO: WHO? DEFAULT? 0 WILL RESULT IN ERROR
        toDoStatusId: 1, // DEFAULT
      };
      newInterestToDos.push(brandInterestToDo);
    }
    // Filter out FC70 brand interest todos, as to only replace those
    const toDosWithoutBrandInterests = toDos.filter(x => x.name !== "FC70 brand interesse");
    const newToDos = [...toDosWithoutBrandInterests, ...newInterestToDos];
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


  // Setting default ProspectionBrands based on shopBrands list --------------------------------------------------------------------------------------------------------------------

  useEffect(() => {
    console.log("setting default prospection brands")
    const defaultProspectionBrands: IProspectionBrand[] = shopBrands.map(x => ({ brandId: x.id, brandName: x.name }));
    setProspectionBrands(defaultProspectionBrands);
    console.log("set default prospection brands")
    console.log(defaultProspectionBrands)
  }, [shopBrands])

  // Submit function ------------------------------------------------------------------------------------------------------------------------------------

  async function handleComplete() {
    try {
      console.log("start handleComplete");

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

        if (toDo.employeeId === 0 || toDo.employeeId == undefined) {
          alert("Selecteer een geldige persoon voor elke taak.");
          return;
        }

        const addedToDo = await addToDo({
          remarks: toDo.remarks,
          employeeId: toDo.employeeId,
          toDoStatusId: toDo.toDoStatusId,
          name: toDo.name,
          dateCreated: new Date(),
          userCreatedId: user ? +user.id : 0,
        });
        if (addedToDo) {
          addedToDos.push(addedToDo);
        }
      }
      console.log("todos added to db", addedToDos);

      // Add new prospection and await response
      const createdProspection = await addProspection(newProspection);
      console.log("new prospection added")

      // Only proceed if response was successful
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

        console.log("end handleComplete");

        navigate(`/shop/${shopId}`);

      } else {
        console.error("Failed to add new prospection. Updates aborted.");
      }

    } catch (error) {
      console.error("Error in handleComplete: ", error);
    }
  };

  // const tabChanged = ({prevIndex,nextIndex}: {
  //   prevIndex: number;
  //   nextIndex: number;
  // }) => {
  //   console.log("prevIndex", prevIndex);
  //   console.log("nextIndex", nextIndex);
  // };

  // check validate tab
  const checkValidateTab = () => {
    console.log(trends);
    console.log(feedback);
    if (trends === "" || feedback === "") {
      return false;
    }
    return true;
  };
  // error messages
  const errorMessages = () => {
    // add alert if trends or feedback are empty
    alert("Please fill in the required fields");
  };

  return (
    <main className={styles.main}>

      <FormWizard
        title="Nieuwe prospectie"
        nextButtonText="Volgende"
        backButtonText="Vorige"
        finishButtonText="Verzenden"
        layout="horizontal"
        stepSize="sm"
        // onTabChange={tabChanged}
        onComplete={handleComplete}>

        {/* CONTACT DETAILS ----------------------------------------------------------- */}

        <FormWizard.TabContent title="Info" icon={<AiOutlineCheck />} >

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
              onChange={(e) => setContactName(e.target.value)}></input>
          </fieldset>

          {/* Toon email en telefoonnummer als het geen verkoper of overig is*/}
          {contactType !== 3 && contactType !== 4 && (
            <>
              <fieldset>
                <legend>Contact email</legend>
                <p style={{ marginTop: 0 }}>Huidige email: {contactInfo?.email ?? "Geen email gevonden"}</p>
                <input
                  type='text'
                  placeholder='Update email'
                  value={contactEmail}
                  onChange={(e) => setContactEmail(e.target.value)}></input>
              </fieldset>

              <fieldset>
                <legend>Contact phone</legend>
                <p style={{ marginTop: 0 }}>Huidge telefoonnummer: {contactInfo?.phoneNumber ?? "Geen telefoonnummer gevonden"}</p>
                <input
                  type='text'
                  placeholder='Update telefoonnummer'
                  value={contactPhone}
                  onChange={(e) => setContactPhone(e.target.value)}></input>
              </fieldset>
            </>
          )}

          <fieldset>
            <legend>Bezoek type</legend>
            <label>
              <input type="radio" name="visit" value="1" onChange={(e) => setVisitType(+e.target.value)} checked={visitType === 1} />
              Prospectie
            </label>
            <label>
              <input type="radio" name="visit" value="2" onChange={(e) => setVisitType(+e.target.value)} checked={visitType === 2} />
              Swap
            </label>
            <label>
              <input type="radio" name="visit" value="3" onChange={(e) => setVisitType(+e.target.value)} checked={visitType === 3} />
              Key account meeting
            </label>
            <label>
              <input type="radio" name="visit" value="4" onChange={(e) => setVisitType(+e.target.value)} checked={visitType === 4} />
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

        {/* BRANDMIX ---------------------------------------------------------------------------------------------------------------------- */}

        <FormWizard.TabContent title="Brandmix" icon={<AiOutlineCheck />}>

          {/* FC70 BRANDS */}
          <h3>FC70 merken</h3>
          <div>
            {prospectionBrands.length > 0
              ? prospectionBrands.map(brand => (
                <BrandTag brandId={brand.brandId} brandName={brand.brandName} type="brand" />
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
          <textarea value={newBrands} placeholder='Nieuwe merk met collectie voor dames/heren/kinderen'
            onChange={(e) => {
              setNewBrands(e.target.value);
            }} />

        </FormWizard.TabContent>

        {/* BEST BRANDS, WORST BRANDS, TERMINATED BRANDS ----------------------------------------------------------------------------------------- */}

        <FormWizard.TabContent title="Algemeen" icon={<AiOutlineCheck />}>
          <h3>Algemene situatie</h3>

          <fieldset>
            <legend>Beste merken</legend>
            <textarea value={bestBrands} placeholder='De beste merken dit seizoen waren...'
              onChange={(e) => setBestBrands(e.target.value)} />
          </fieldset>

          <fieldset>
            <legend>Slechtste merken</legend>
            <textarea value={worstBrands} placeholder='De slechtste merken dit seizoen waren...'
              onChange={(e) => setWorstBrands(e.target.value)} />
          </fieldset>

          <fieldset>
            <legend>Merken die niet meer ingekocht worden</legend>
            <textarea value={terminatedBrands} placeholder='Deze merken worden niet meer ingekocht volgend seizoen...'
              onChange={(e) => setTerminatedBrands(e.target.value)} />
          </fieldset>
        </FormWizard.TabContent>

        {/* FC70 BRANDS SELLOUT --------------------------------------------------------------------------------------------- */}

        <FormWizard.TabContent title="FC70" icon={<AiOutlineCheck />}>

          <h3>FC70 overzicht</h3>

          {prospectionBrands.map(brand => <BrandCardInput brand={{ brandId: brand.brandId, brandName: brand.brandName }} />)}
          {prospectionBrands.length === 0 && <p>Geen FC70 merken beschikbaar.</p>}

        </FormWizard.TabContent>

        <FormWizard.TabContent title="Interesses" icon={<AiOutlineCheck />}>

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
            {prospectionBrandInterests.map(brand => <BrandInterestCard brand={brand} />)}
          </div>

        </FormWizard.TabContent>

        {/* FEEDBACK ---------------------------------------------------------------------------------------------- */}

        <FormWizard.TabContent title="Feedback" icon={<AiOutlineCheck />}>

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

        {/* TO DOS -------------------------------------------------------------------------------------------------- */}

        <FormWizard.TabContent title="Opvolging" icon={<AiOutlineCheck />} isValid={checkValidateTab()} validationError={errorMessages}>

          <h3>Takenlijst voor opvolging</h3>
          <p>Hier kan u items toevoegen die op basis van dit verslag moeten opgevolgd worden.</p>
          <p>Worden automatisch toegevoegd:</p>
          <ul>
            <li>Nieuwe contact info</li>
            <li>Nieuwe brands</li>
            <li>Brands interesses</li>
          </ul>

          <ToDoModule toDos={toDos} setToDos={setToDos} />

        </FormWizard.TabContent>

      </FormWizard>

    </main >
  );
};
