import React from 'react';
import { IProspectionBrandInterest } from '../../../types';
import styles from "./BrandInterestCard.module.css"

interface BrandInterestCardProps {
  index: number,
  brand: IProspectionBrandInterest;
}

export const BrandInterestCard: React.FC<BrandInterestCardProps> = ({ index, brand }) => (
  <div key={index} className={styles.card}>
    <h3>{brand.brandName}</h3>
    {brand.remark && <p><strong>Opmerking: </strong>{brand.remark}</p>}
  </div>
);
