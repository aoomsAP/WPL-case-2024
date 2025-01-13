import React from 'react';
import { IProspectionCompetitorBrand } from '../../../types';
import styles from "./CompetitorBrandList.module.css"

interface CompetitorBrandListProps {
  prospectionCompetitorBrands: IProspectionCompetitorBrand[];
}

export const CompetitorBrandList: React.FC<CompetitorBrandListProps> = ({ prospectionCompetitorBrands }) => {

  return (
    <article className={styles.card}>
      <h3>Referentiemerken</h3>
      <ul className={styles.list}>
        {prospectionCompetitorBrands.map((brand, index) =>
          <li key={index}>{brand.competitorBrandName}</li>
        )}
      </ul>
    </article>
  );
}
