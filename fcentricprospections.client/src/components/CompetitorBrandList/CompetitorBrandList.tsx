import React from 'react';
import { IProspectionCompetitorBrand } from '../../types';
import styles from "./CompetitorBrandList.module.css"

interface CompetitorBrandListProps {
  prospectionCompetitorBrands: IProspectionCompetitorBrand[];
}

export const CompetitorBrandList: React.FC<CompetitorBrandListProps> = ({ prospectionCompetitorBrands }) => {

  console.log(prospectionCompetitorBrands);

  return (
    <section className={styles.competitorBrandList}>
      <h2>Referentiemerken</h2>
      <ul>
        {prospectionCompetitorBrands.map((brand, index) => {
          return (
            <li key={index}>{brand.competitorBrandName}</li>
          );
        })}
      </ul>
    </section>
  );
}
