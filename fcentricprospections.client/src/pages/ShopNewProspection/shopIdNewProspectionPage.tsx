import styles from '../../App.module.css';
import FormWizard from "react-form-wizard-component";
import "react-form-wizard-component/dist/style.css";
import ShopCart from '../../components/ShopCart';
import { IBrand, ICompetitorBrand, IContactType, IVisitType, IProspection, IProspectionBrand, IProspectionCompetitorBrand, IProspectionBrandInterest, Shop } from "../../types"
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import BrandTag from '../../components/BrandTag';

export const Prospectie = () => {

  const { id } = useParams<{ id: string }>();

  // data states
  const [brands, setBrands] = useState<IBrand[]>([]);
  const [competitorBrands, setCompetitorBrands] = useState<ICompetitorBrand[]>([]);
  const [contactTypes, setContactTypes] = useState<IContactType[]>([]);
  const [visitTypes, setVisitTypes] = useState<IVisitType[]>([]);
  const [shopData, setShopData] = useState<Shop>();

  // new prospection states
  const [prospection, setProspection] = useState<IProspection>();
  const [prospectionBrands, setProspectionBrands] = useState<IProspectionBrand[]>([]);
  const [prospectionCompetitorBrands, setProspectionCompetitorBrands] = useState<IProspectionCompetitorBrand[]>([]);
  const [prospectionBrandInterests, setProspectionBrandInterests] = useState<IProspectionBrandInterest[]>([]);

  // search fields
  const [brandSearch, setBrandSearch] = useState<string>("");
  const [competitorBrandSearch, setCompetitorBrandSearch] = useState<string>("");

  // Filter brand names based on the search term, ensuring at least 3 characters are typed
  const brandSearchFunc = brands.filter(brand => {

    if(prospectionBrands.map(x => x.brandId).find(x => x === brand.id)) return false;
    // Check if the search term is at least 3 characters long
    if (brandSearch.length < 3) return false; // If less than 3 characters, do not include
    return brand.name.toLowerCase().includes(brandSearch.toLowerCase()); // Otherwise, filter based on name
  });


  //filer voor de competitor brands
  const competitorBrandSearchFunc = competitorBrands.filter(brand => {

    if(prospectionCompetitorBrands.map(x => x.brandId).find(x => x === brand.id)) return false;
    
    if (brandSearch.length < 3) return false; 
    return brand.name.toLowerCase().includes(brandSearch.toLowerCase()); 
  });



  // LOAD DATA FUNCTIONS

  async function loadBrands() {
    try {
      const response = await fetch(`/api/brands`, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
      });

      const json: IBrand[] = await response.json();
      setBrands(json);

    } catch (error) {
      console.error('Error fetching brands data:', error);
    }
  }

  async function loadCompetitorBrands() {
    try {
      const response = await fetch(`/api/competitorbrands`, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
      });

      const json: ICompetitorBrand[] = await response.json();
      setCompetitorBrands(json);

    } catch (error) {
      console.error('Error fetching competitor brands data:', error);
    }
  }

  async function loadContactTypes() {
    try {
      const response = await fetch(`/api/contacttypes`, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
      });

      const json: IContactType[] = await response.json();
      setContactTypes(json);

    } catch (error) {
      console.error('Error fetching contact types data:', error);
    }
  }

  async function loadVisitTypes() {
    try {
      const response = await fetch(`/api/visittypes`, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
      });

      const json: IVisitType[] = await response.json();
      setVisitTypes(json);

    } catch (error) {
      console.error('Error fetching visit types:', error);
    }
  }

  async function loadShopData() {
    try {
      const response = await fetch(`/api/shops/${id}`, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
      });

      const json: Shop = await response.json();
      setShopData(json);

    } catch (error) {
      console.error('Error fetching shop data:', error);
    }
  }

  // LOAD DATA USE EFFECT

  useEffect(() => {
    loadBrands();
    loadCompetitorBrands();
    loadContactTypes();
    loadVisitTypes();
    loadShopData();
  }, [])

  // ADD NEW PROSPECTION FUNCTIONS

  async function addProspection(newProspection: IProspection) {
    try {
      const response = await fetch(`/api/prospections`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newProspection),
      });

      const json: IProspection = await response.json();

      console.log("Succesful POST new prospection: ", json)

      // if in context: load anew

    } catch (error) {
      console.error('Error POST new prospection:', error);
    }
  }

  async function updateProspectionBrands(prospectionBrands: IProspectionBrand[]) {
    try {
      const response = await fetch(`/api/prospections/${id}/brands`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(prospectionBrands),
      });

      const json = await response.json();

      console.log("Succesful PUT prospection brands: ", json)

      // if in context: load anew

    } catch (error) {
      console.error('Error PUT prospection brands:', error);
    }
  }

  async function updateProspectionBrandInterests(prospectionBrandInterests: IProspectionBrandInterest[]) {
    try {
      const response = await fetch(`/api/prospections/${id}/brandinterests`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(prospectionBrandInterests),
      });

      const json = await response.json();

      console.log("Succesful PUT prospection brand interests: ", json)

      // if in context: load anew

    } catch (error) {
      console.error('Error PUT prospection brand interests:', error);
    }
  }

  async function updateProspectionCompetitorBrands(prospectionCompetitorBrands: IProspectionCompetitorBrand[]) {
    try {
      const response = await fetch(`/api/prospections/${id}/competitorbrands`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(prospectionCompetitorBrands),
      });

      const json = await response.json();

      console.log("Succesful PUT prospection competitor brands: ", json)

      // if in context: load anew

    } catch (error) {
      console.error('Error PUT prospection competitor brands:', error);
    }
  }

  function handleComplete() {

    // POST
    // PUT
    // PUT
    // PUT

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

        <FormWizard.TabContent title="Info" icon="ti-user">
          {shopData && <ShopCart data={shopData} />}

          <h3>Contact type</h3>

          <fieldset>
            <legend>Contact Type</legend>

            <label>
              <input type="radio" name="role" value="owner" />
              Owner
            </label>

            <label>
              <input type="radio" name="role" value="buyer" />
              Buyer
            </label>

            <label>
              <input type="radio" name="role" value="salesperson" />
              Salesperson
            </label>

            <label>
              <input type="radio" name="role" value="other" />
              Other
            </label>

          </fieldset>

          <fieldset>
            <legend>Contact Persoon Naam</legend>

            <input type='text'></input>
          </fieldset>

          <fieldset>
            <legend>Visit type</legend>

            <label>
              <input type="radio" name="visit" value="prospection" />
              prospection
            </label>

            <label>
              <input type="radio" name="visit" value="swap" />
              swap
            </label>

            <label>
              <input type="radio" name="visit" value="key account meeting" />
              key account meeting
            </label>

            <label>
              <input type="radio" name="visit" value="other" />
              other
            </label>
          </fieldset>

          <fieldset>
            <legend>Visit context</legend>

            <input type="text" name="" id="" maxLength={500} />

          </fieldset>

        </FormWizard.TabContent>

        <FormWizard.TabContent title="Brands" icon="ti-settings">
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
                <li key={brand.id}
                  onClick={() => {
                    setProspectionBrands(prev => [...prev, { brandId: brand.id, brandName: brand.name }]);
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
          {prospectionBrands.map(brand => <BrandTag key={brand.brandId} data={brand.brandName}/>)}  
        </div>


        {/*Voor de competitorbrands*/}
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
                    setProspectionCompetitorBrands(prev => [
                      ...prev,
                      {
                        id: brand.id,           
                        brandId: brand.id,
                        brandName: brand.name,
                      }
                    ]);
                    
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
          {prospectionCompetitorBrands.map(brand => <BrandTag key={brand.brandId} data={brand.brandName}/>)}  
        </div>




      </FormWizard.TabContent>

      <FormWizard.TabContent title="Preformance" icon="ti-check">
        <h3>Proformance</h3>


      </FormWizard.TabContent>

      <FormWizard.TabContent title="FC 70 eval" icon="ti-check">
        <h3>Fc 70 eval</h3>


      </FormWizard.TabContent>

      <FormWizard.TabContent title="Interests" icon="ti-check">
        <h3>Interests</h3>


      </FormWizard.TabContent>

      <FormWizard.TabContent title="Feedback" icon="ti-check">
        <h3>Feedback</h3>


      </FormWizard.TabContent>


    </FormWizard>


    </main >
  );
};
