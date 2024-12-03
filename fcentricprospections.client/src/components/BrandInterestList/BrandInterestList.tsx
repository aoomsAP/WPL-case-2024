import React from 'react';
import { IProspectionBrandInterest } from '../../types';
import styles from "./BrandInterestList.module.css"

interface BrandInterestListProps {
  prospectionBrandInterests: IProspectionBrandInterest[];
}

export const BrandInterestList: React.FC<BrandInterestListProps> = ({ prospectionBrandInterests }) => (
  <section className={styles.brandInterestList}>
    <h2>Interesse FC70 merken</h2>
    {prospectionBrandInterests.map((brand, index) => {
      return (
        <div key={index} className={styles.brandInterestCard}>
          <h3>Brand: {brand.brandName}</h3>
          {brand.remark &&<p>Opmerking: {brand.remark}</p>}
        </div>
      );
    })}
  </section>
);
