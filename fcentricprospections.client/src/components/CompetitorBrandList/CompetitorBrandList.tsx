import React from 'react';
import { IProspectionCompetitorBrand, IBrand } from '../../types';
import styles from "./CompetitorBrandList.module.css"

interface CompetitorBrandListProps {
  prospectionCompetitorBrands: IProspectionCompetitorBrand[];
  brands: IBrand[];
}

export const CompetitorBrandList: React.FC<CompetitorBrandListProps> = ({ prospectionCompetitorBrands, brands }) => (
  <section className={styles.competitorBrandList}>
    <h2>Competitor Brands</h2>
    <ul>
      {prospectionCompetitorBrands.map((brand, index) => {
        const matchingCompetitorBrand = brands.find(b => b.id === brand.competitorBrandId);
        return (
            <li key={index}>{matchingCompetitorBrand ? matchingCompetitorBrand.name : "Unknown Brand"}</li>
        );
      })}
    </ul>
  </section>
);
