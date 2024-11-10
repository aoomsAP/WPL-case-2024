import React from 'react';
import { IProspectionBrandInterest, IBrand } from '../../types';

interface BrandInterestListProps {
  prospectionBrandInterests: IProspectionBrandInterest[];
  brands: IBrand[];
}

export const BrandInterestList: React.FC<BrandInterestListProps> = ({ prospectionBrandInterests, brands }) => (
  <section className="brand-interest-list">
    <p>Interesse FC70 merken</p>
    {prospectionBrandInterests.map((brand, index) => {
      const matchingBrandInterest = brands.find(b => b.id === brand.brandId);
      return (
        <div key={index} className="brand-interest-card">
          <p>Brand: {matchingBrandInterest ? matchingBrandInterest.name : "Unknown Brand"}</p>
          <p>Sales: {brand.sales}</p>
        </div>
      );
    })}
  </section>
);
