import React from 'react';
import { IProspectionBrandInterest, IBrand } from '../../types';
import styles from "./BrandInterestList.module.css"

interface BrandInterestListProps {
  prospectionBrandInterests: IProspectionBrandInterest[];
  brands: IBrand[];
}

export const BrandInterestList: React.FC<BrandInterestListProps> = ({ prospectionBrandInterests, brands }) => (
  <section className={styles.brandInterestList}>
    <h2>Interesse FC70 merken</h2>
    {prospectionBrandInterests.map((brand, index) => {
      const matchingBrandInterest = brands.find(b => b.id === brand.brandId);
      return (
        <div key={index} className={styles.brandInterestCard}>
          <h3>Brand: {matchingBrandInterest ? matchingBrandInterest.name : "Unknown Brand"}</h3>
          <p>Sales: {brand.sales}</p>
        </div>
      );
    })}
  </section>
);
