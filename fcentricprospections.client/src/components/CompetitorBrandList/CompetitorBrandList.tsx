import React from 'react';
import { IProspectionCompetitorBrand, IBrand } from '../../types';
import styles from "./CompetitorBrandList.module.css"

interface CompetitorBrandListProps {
  prospectionCompetitorBrands: IProspectionCompetitorBrand[];
  brands: IBrand[];
}

export const CompetitorBrandList: React.FC<CompetitorBrandListProps> = ({ prospectionCompetitorBrands, brands }) => (
  <section className={styles.competitorBrandList}>
    <h2>Andere merken</h2>
    <ul>
      {prospectionCompetitorBrands.map((brand, index) => {
        const matchingCompetitorBrand = brands.find(b => b.id === brand.competitorBrandId); // TO DO: figure out error
        return (
            <li key={index}>{matchingCompetitorBrand ? matchingCompetitorBrand.name : "Onbekend merk"}</li>
        );
      })}
    </ul>
  </section>
);
