import styles from '../../App.module.css';
import FormWizard from "react-form-wizard-component";
import "react-form-wizard-component/dist/style.css";
import ShopCard from '../../components/ShopCard';
import { useContext, useState } from 'react';
import { useParams , useNavigate } from 'react-router-dom';
import BrandTag from '../../components/BrandTag';
import { ProspectionDataContext } from '../../contexts/ProspectionDataContext';
import { IProspection } from '../../types';
import BrandCardInput from '../../components/BrandCardInput';
import BrandInterestCard from '../../components/BrandInterestCard';

export const NewProspection = () => {

  const { shopId } = useParams<{ shopId: string }>();

  const { brands, competitorBrands, prospectionBrands, setProspectionBrands, prospectionCompetitorBrands, setProspectionCompetitorBrands, prospectionBrandInterests, setProspectionBrandInterests,
    addProspection, updateProspectionBrands, updateProspectionCompetitorBrands, updateProspectionBrandInterests } = useContext(ProspectionDataContext);

  const navigate = useNavigate();

  // Input fields
  const [contactType, setContactType] = useState<number>(4);
  const [contactName, setContactName] = useState<string>("");
  const [visitType, setVisitType] = useState<number>(4);
  const [visitContext, setVisitContext] = useState<string>("");
  const [bestBrands, setBestBrands] = useState<string>("");
  const [worstBrands, setWorstBrands] = useState<string>("");
  const [brandsOut, setBrandsOut] = useState<string>("");
  const [trends,setTrends] = useState<string>("");
  const [feedback,setFeedback] = useState<string>("");

  // Search fields
  const [brandSearch, setBrandSearch] = useState<string>("");
  const [competitorBrandSearch, setCompetitorBrandSearch] = useState<string>("");
  const [brandInterestSearch , setBrandInterestSearch] = useState<string>("");

  // Filter for brands
  const brandSearchFunc = brands.filter(brand => {
    // If brand is already in prospectionBrands, do not include
    if (prospectionBrands.map(x => x.brandId).find(x => x === brand.id)) return false;

    // If search value is less than 3 characters, do not include
    if (brandSearch.length < 3) return false;

    // If brand name contains search value, include
    return brand.name.toLowerCase().includes(brandSearch.toLowerCase());
  });


  // Filter for competitor brands
  const competitorBrandSearchFunc = competitorBrands.filter(brand => {

    if (prospectionCompetitorBrands.map(x => x.brandId).find(x => x === brand.id)) return false;

    if (competitorBrandSearch.length < 3) return false;

    return brand.name.toLowerCase().includes(competitorBrandSearch.toLowerCase());
  });


  // Filter for interest search brands
  const brandInterestSearchFunc = brands.filter(brand => {

    if (prospectionBrandInterests.map(x => x.brandId).find(x => x === brand.id)) return false;

    if (brandInterestSearch.length < 3) return false;

    return brand.name.toLowerCase().includes(brandInterestSearch.toLowerCase());
  });


  // IF FORM WIARD SUPPORTS ASYNC FUNCTIONS
  async function handleComplete() {

    const newProspection: IProspection = {
      shopId: Number(shopId),
      date: new Date(),
      dateLastUpdated: new Date(),
      contactPersonTypeId: contactType,
      contactPersonName: contactName,
      visitTypeId: visitType,
      visitContext: visitContext,
      bestBrands: bestBrands,
      worstBrands: worstBrands,
      brandsOut: bestBrands,
      trends: trends,
      extra: feedback
    }

    try {
      // Add new prospection and await response
      const createdProspection = await addProspection(newProspection);

      // Only proceed if response was successful
      if (createdProspection && createdProspection.id) {

        // Get id from new prospection
        const prospectionId = createdProspection.id;

        // Update the relationships
        await updateProspectionBrands(prospectionId, prospectionBrands);
        await updateProspectionBrandInterests(prospectionId, prospectionBrandInterests);
        await updateProspectionCompetitorBrands(prospectionId, prospectionCompetitorBrands);

        console.log("All updates completed successfully.");

        navigate(`/shop/${shopId}`);
        
      } else {
        console.error("Failed to add new prospection. Updates aborted.");
      }

    } catch (error) {
      console.error("Error in onComplete: ", error);
    }
  };

  const tabChanged = ({
    prevIndex,
    nextIndex,
  }: {
    prevIndex: number;
    nextIndex: number;
  }) => {
    console.log("prevIndex", prevIndex);
    console.log("nextIndex", nextIndex);
  };

  return (
    <main className={styles.main}>

      <FormWizard stepSize="sm"
        onTabChange={tabChanged}
        onComplete={handleComplete}>

        <FormWizard.TabContent title="Info" icon="ti-user" >
          {shopId && !isNaN(Number(shopId)) && <ShopCard shopId={Number(shopId)} />}

          <h3>Contact type</h3>

          <fieldset>
            <legend>Contact Type</legend>

            <label>
              <input type="radio" name="role" value="1" onChange={(e) => setContactType(+e.target.value)} checked={contactType === 1} />
              Owner
            </label>

            <label>
              <input type="radio" name="role" value="2" onChange={(e) => setContactType(+e.target.value)} checked={contactType === 2} />
              Buyer
            </label>

            <label>
              <input type="radio" name="role" value="3" onChange={(e) => setContactType(+e.target.value)} checked={contactType === 3} />
              Salesperson
            </label>

            <label>
              <input type="radio" name="role" value="4" onChange={(e) => setContactType(+e.target.value)} checked={contactType === 4} />
              Other
            </label>

          </fieldset>

          <fieldset>
            <legend>Contact Persoon Naam</legend>

            <input type='text' value={contactName} onChange={(e) => setContactName(e.target.value)}></input>
          </fieldset>

          <fieldset>
            <legend>Visit type</legend>

            <label>
              <input type="radio" name="visit" value="1" onChange={(e) => setVisitType(+e.target.value)} checked={visitType === 1} />
              prospection
            </label>

            <label>
              <input type="radio" name="visit" value="2" onChange={(e) => setVisitType(+e.target.value)} checked={visitType === 2} />
              swap
            </label>

            <label>
              <input type="radio" name="visit" value="3" onChange={(e) => setVisitType(+e.target.value)} checked={visitType === 3} />
              key account meeting
            </label>

            <label>
              <input type="radio" name="visit" value="4" onChange={(e) => setVisitType(+e.target.value)} checked={visitType ===  4} />
              other
            </label>
          </fieldset>

          <fieldset>
            <legend>Visit context</legend>

            <input type="text" maxLength={500} value={visitContext} onChange={(e) => setVisitContext(e.target.value)}/>

          </fieldset>

        </FormWizard.TabContent>

        <FormWizard.TabContent title="Brandmix" icon="ti-settings">
          {/* FC70 BRANDS */}
          <h3>FC70 brandmix</h3>
          <input
            type="text"
            placeholder="Zoek..."
            value={brandSearch}
            onChange={(e) => setBrandSearch(e.target.value)} // Update state on input change
          />

          <ul>
            {brandSearchFunc.length > 0 ? (
              brandSearchFunc.map(brand => (
                <li 
                  key={brand.id}
                  onClick={() => {
                    setProspectionBrands([...prospectionBrands, { brandId: brand.id, brandName: brand.name }]);
                    setBrandSearch("");
                  }}>
                  {brand.name}
                </li>
              ))
            ) : (
              brandSearch.length < 3 ? (
                <li>Typ minstens 3 letters.</li>
              ) : (
                <li>Geen merken gevonden</li>
              )
            )}
          </ul>

          <div>
          {prospectionBrands.map(brand => (
            <BrandTag brandId={brand.brandId} brandName={brand.brandName} type="brand" />
          ))}
          </div>


          {/* COMPETITOR BRANDS */}
          <h3>Competitor brands</h3>
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
                    setProspectionCompetitorBrands([...prospectionCompetitorBrands, { brandId: brand.id, brandName: brand.name }]);
                    setCompetitorBrandSearch("");
                  }}>
                  {brand.name}
                </li>
              ))
            ) : (
              competitorBrandSearch.length < 3 ? (
                <li>Typ minstens 3 letters.</li>
              ) : (
                <li>Geen merken gevonden</li>
              )
            )}
          </ul>
          <div>
            {prospectionCompetitorBrands.map(brand => <BrandTag brandId={brand.brandId} brandName={brand.brandName} type="competitorBrand" />)}
          </div>




        </FormWizard.TabContent>

        <FormWizard.TabContent title="Performance" icon="ti-check">
          <h3>Performance</h3>
          <h4>Beste seizoens merken</h4>
          <input type='text' value={bestBrands} onChange={(e) => setBestBrands(e.target.value)}/>

          <h4>Slechtste seizoens merken</h4>
          <input type='text' value={worstBrands} onChange={(e) => setWorstBrands(e.target.value)}/>

          <h4>Merken die niet meer ingekocht worden</h4>
          <input type='text' value={brandsOut} onChange={(e) => setBrandsOut(e.target.value)}/>

        </FormWizard.TabContent>

        <FormWizard.TabContent title="FC 70 eval" icon="ti-check">
          <h3>Fc 70 eval</h3>
          {prospectionBrands.map(brand => <BrandCardInput brand={brand} />)}

        </FormWizard.TabContent>

        <FormWizard.TabContent title="Interests" icon="ti-check">
          <h3>Interests</h3>
          <h4>FC70 intresses van de winkel</h4>

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
              brandSearch.length < 3 ? (
                <li>Typ minstens 3 letters.</li>
              ) : (
                <li>Geen merken gevonden</li>
              )
            )}
          </ul>

          
          {prospectionBrandInterests.map(brand => <BrandInterestCard brand={brand} /> )}




        </FormWizard.TabContent>

        <FormWizard.TabContent title="Feedback" icon="ti-check">
          <h3>Feedback</h3>
          <h4>Trends en noden in de markt</h4>
          <input type='text' value={trends} onChange={(e) => setTrends(e.target.value)}/>

          <h4>Extra opmerkingen/feedbac</h4>
          <input type='text' value={feedback} onChange={(e) => setFeedback(e.target.value)}/>

        </FormWizard.TabContent>


      </FormWizard>


    </main >
  );
};
