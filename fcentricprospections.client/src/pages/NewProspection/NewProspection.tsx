import styles from '../../App.module.css';
import FormWizard from "react-form-wizard-component";
import "react-form-wizard-component/dist/style.css";
import { useContext, useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import BrandTag from '../../components/BrandTag/BrandTag';
import { NewProspectionContext } from '../../contexts/NewProspectionContext';
import { IProspectionBrand, IProspectionDetail, IProspectionToDo, IToDo } from '../../types';
import BrandCardInput from '../../components/BrandCardInput/BrandCardInput';
import BrandInterestCard from '../../components/BrandCardInput/BrandInterestCard';
import { AiOutlineCheck } from "react-icons/ai";
import { ShopDetailContext } from '../../contexts/ShopDetailContext';
import { ShopDetailCard } from '../../components/ShopDetailCard/ShopDetailCard';
import ToDoModule from '../../components/ToDoModule/ToDoModule';
import { UserContext } from '../../contexts/UserContext';

export const NewProspection = () => {

  const { shopId } = useParams<{ shopId: string }>();

  // Contexts

  const {user} = useContext(UserContext);

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

  const navigate = useNavigate();

  // Input fields
  const [visitDate, setVisitDate] = useState<Date>(); // TO IMPLEMENT
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

  // Setting default ProspectionBrands based on shopBrands list
  useEffect(() => {
    console.log("setting default prospection brands")
    const defaultProspectionBrands: IProspectionBrand[] = shopBrands.map(x => ({ brandId: x.id, brandName: x.name }));
    setProspectionBrands(defaultProspectionBrands);
    console.log("set default prospection brands")
    console.log(defaultProspectionBrands)
  }, [shopBrands])

  // Search fields
  const [competitorBrandSearch, setCompetitorBrandSearch] = useState<string>("");
  const [brandInterestSearch, setBrandInterestSearch] = useState<string>("");

  // Filter for competitor brands
  const competitorBrandSearchFunc = competitorBrands.filter(brand => {

    if (prospectionCompetitorBrands.map(x => x.competitorBrandId).find(x => x === brand.id)) return false;

    if (competitorBrandSearch.length < 3) return false;

    return brand.name.toLowerCase().includes(competitorBrandSearch.toLowerCase());
  });

  // Filter for interest search brands
  const brandInterestSearchFunc = allBrands.filter(brand => {

    if (prospectionBrandInterests.map(x => x.brandId).find(x => x === brand.id)) return false;

    if (brandInterestSearch.length < 3) return false;

    return brand.name.toLowerCase().includes(brandInterestSearch.toLowerCase());
  });

  // Submit function
  async function handleComplete() {

    const newProspection: IProspectionDetail = {
      shopId: Number(shopId),
      userId: 1029, // TO DO: implement
      employeeId: 4, // TO DO: implement
      visitDate: new Date(), // TO DO: date needs to be picked
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

    try {
      console.log("start handleComplete");

      // Add new todos, save in new array to get toDos with id, and await response
      const addedToDos: IToDo[] = [];
      for (let toDo of toDos) {
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
              toDoId: toDo.id,
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

        <FormWizard.TabContent title="Info" icon={<AiOutlineCheck />} >

          {shopDetail && <ShopDetailCard shop={shopDetail} />}

          <h3>Informatie</h3>

          <fieldset>
            <legend>Contact type</legend>
            <label>
              <input type="radio" name="role" value="1" onChange={(e) => setContactType(+e.target.value)} checked={contactType === 1} />
              Eigenaar
            </label>
            <label>
              <input type="radio" name="role" value="2" onChange={(e) => setContactType(+e.target.value)} checked={contactType === 2} />
              Koper
            </label>
            <label>
              <input type="radio" name="role" value="3" onChange={(e) => setContactType(+e.target.value)} checked={contactType === 3} />
              Verkoper
            </label>
            <label>
              <input type="radio" name="role" value="4" onChange={(e) => setContactType(+e.target.value)} checked={contactType === 4} />
              Overig
            </label>
          </fieldset>

          <fieldset>
            <legend>Contact naam</legend>
            <input type='text' value={contactName} onChange={(e) => setContactName(e.target.value)}></input>
          </fieldset>

          <fieldset>
            <legend>Contact email</legend>
            <input type='text' value={contactEmail} onChange={(e) => setContactEmail(e.target.value)}></input>
          </fieldset>

          <fieldset>
            <legend>Contact phone</legend>
            <input type='text' value={contactPhone} onChange={(e) => setContactPhone(e.target.value)}></input>
          </fieldset>

          {/* TO DO: IMPLEMENT CHECKBOX TO AUTOMATICALLY ADD TO TODOS */}

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

            <textarea maxLength={500} rows={3} value={visitContext} onChange={(e) => setVisitContext(e.target.value)} />

          </fieldset>

        </FormWizard.TabContent>

        <FormWizard.TabContent title="Brandmix" icon={<AiOutlineCheck />}>

          {/* FC70 BRANDS */}
          <h3>FC70 merken</h3>
          <div>
            {prospectionBrands.map(brand => (
              <BrandTag brandId={brand.brandId} brandName={brand.brandName} type="brand" />
            ))}
          </div>

          {/* COMPETITOR BRANDS */}
          <h3>Referentiemerken</h3>
          <input
            type="text"
            placeholder="Zoek..."
            value={competitorBrandSearch}
            onChange={(e) => setCompetitorBrandSearch(e.target.value)} // Update state on input change
          />

          <ul>
            {competitorBrandSearchFunc.length > 0 ? (
              competitorBrandSearchFunc.map(brand => (
                <li key={brand.id}
                  onClick={() => {
                    setProspectionCompetitorBrands([...prospectionCompetitorBrands, { competitorBrandId: brand.id, competitorBrandName: brand.name }]);
                    setCompetitorBrandSearch("");
                  }}>
                  {brand.name}
                </li>
              ))
            ) : (
              competitorBrandSearch.length < 3 ? (
                <p>Typ minstens 3 letters.</p>
              ) : (
                <p>Geen merken gevonden</p>
              )
            )}
          </ul>

          <div>
            {prospectionCompetitorBrands.map(brand => <BrandTag brandId={brand.competitorBrandId} brandName={brand.competitorBrandName} type="competitorBrand" />)}
          </div>

          {/* NEW BRANDS */}
          <h3>Nieuwe merken</h3>
          <legend>Merken die u niet terugvond in de lijst hierboven:</legend>
          <textarea value={newBrands} onChange={(e) => setNewBrands(e.target.value)} />

          {/* TO DO: ADD TO TODOS */}

        </FormWizard.TabContent>

        <FormWizard.TabContent title="Algemeen" icon={<AiOutlineCheck />}>

          <h3>Algemene situatie</h3>

          <fieldset>
            <legend>Beste merken</legend>
            <textarea value={bestBrands} onChange={(e) => setBestBrands(e.target.value)} />
          </fieldset>

          <fieldset>
            <legend>Slechtste merken</legend>
            <textarea value={worstBrands} onChange={(e) => setWorstBrands(e.target.value)} />
          </fieldset>

          <fieldset>
            <legend>Merken die niet meer ingekocht worden</legend>
            <textarea value={terminatedBrands} onChange={(e) => setTerminatedBrands(e.target.value)} />
          </fieldset>

        </FormWizard.TabContent>

        <FormWizard.TabContent title="FC70" icon={<AiOutlineCheck />}>

          <h3>FC70 overzicht</h3>

          {prospectionBrands.map(brand => <BrandCardInput brand={{ brandId: brand.brandId, brandName: brand.brandName }} />)}
          {prospectionBrands.length === 0 && <p>Geen FC70 merken gevonden.</p>}

        </FormWizard.TabContent>

        <FormWizard.TabContent title="Interesses" icon={<AiOutlineCheck />}>

          <h3>Interesse FC70 merken</h3>

          <input
            type="text"
            placeholder="Zoek..."
            value={brandInterestSearch}
            onChange={(e) => setBrandInterestSearch(e.target.value)} // Update state on input change
          />

          <ul>
            {brandInterestSearchFunc.length > 0 ? (
              brandInterestSearchFunc.map(brand => (
                <li key={brand.id}
                  onClick={() => {
                    setProspectionBrandInterests([...prospectionBrandInterests, { brandId: brand.id, brandName: brand.name }]);
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

          {prospectionBrandInterests.map(brand => <BrandInterestCard brand={brand} />)}

        </FormWizard.TabContent>

        <FormWizard.TabContent title="Feedback" icon={<AiOutlineCheck />}>

          <h3>Feedback</h3>

          <h4>Trends en noden in de markt</h4>
          <textarea rows={4} value={trends} onChange={(e) => setTrends(e.target.value)} />

          <h4>Extra opmerkingen/feedback</h4>
          <textarea rows={4} value={feedback} onChange={(e) => setFeedback(e.target.value)} />

        </FormWizard.TabContent>

        <FormWizard.TabContent title="Opvolging" icon={<AiOutlineCheck />}>

          <h3>Takenlijst voor opvolging</h3>
          <p>Hier kan u items toevoegen die op basis van dit verslag moeten opgevolgd worden.</p>

          {/* TO DO LIST */}
          <ToDoModule toDos={toDos} setToDos={setToDos} />

        </FormWizard.TabContent>

      </FormWizard>

    </main >
  );
};
