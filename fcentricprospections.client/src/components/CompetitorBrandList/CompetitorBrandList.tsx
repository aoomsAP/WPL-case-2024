import React from 'react';
import { IProspectionCompetitorBrand, IBrand } from '../../types';

interface CompetitorBrandListProps {
  prospectionCompetitorBrands: IProspectionCompetitorBrand[];
  brands: IBrand[];
}

export const CompetitorBrandList: React.FC<CompetitorBrandListProps> = ({ prospectionCompetitorBrands, brands }) => (
  <section className="competitor-brand-list">
    <p>Competitor Brands</p>
    {prospectionCompetitorBrands.map((brand, index) => {
      const matchingCompetitorBrand = brands.find(b => b.id === brand.competitorBrandId);
      return (
        <div key={index} className="competitor-brand-card">
          <p>Brand: {matchingCompetitorBrand ? matchingCompetitorBrand.name : "Unknown Brand"}</p>
        </div>
      );
    })}
  </section>
);
