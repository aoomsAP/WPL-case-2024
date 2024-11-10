import styles from '../../App.module.css';
import FormWizard from "react-form-wizard-component";
import "react-form-wizard-component/dist/style.css";
import ShopCard from '../../components/ShopCard';
import { useContext, useState } from 'react';
import { useParams } from 'react-router-dom';
import BrandTag from '../../components/BrandTag';
import { ProspectionDataContext } from '../../contexts/ProspectionDataContext';

export const NewProspection = () => {

  const { shopId } = useParams<{ shopId: string }>();

  const { brands, competitorBrands, prospectionBrands, setProspectionBrands, prospectionCompetitorBrands, setProspectionCompetitorBrands } = useContext(ProspectionDataContext);

  // Search fields
  const [brandSearch, setBrandSearch] = useState<string>("");
  const [competitorBrandSearch, setCompetitorBrandSearch] = useState<string>("");

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
    // If competitor brand is already in prospectionCompetitorBrands, do not include
    if (prospectionCompetitorBrands.map(x => x.brandId).find(x => x === brand.id)) return false;

    // If search value is less than 3 characters, do not include
    if (competitorBrandSearch.length < 3) return false;

    // If competitor brand name contains search value, include
    return brand.name.toLowerCase().includes(competitorBrandSearch.toLowerCase());
  });

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
          {shopId && !isNaN(Number(shopId)) && <ShopCard shopId={Number(shopId)} />}

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
                <li key={brand.id}
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
            {prospectionBrands.map(brand => <BrandTag brandId={brand.brandId} brandName={brand.brandName} type="brand" />)}
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
