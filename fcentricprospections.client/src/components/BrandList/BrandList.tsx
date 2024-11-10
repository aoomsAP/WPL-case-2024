import React from 'react';
import { IProspectionBrand, IBrand } from '../../types';
import { BrandCard } from '../BrandCard/BrandCard';


interface BrandListProps {
    prospectionBrands: IProspectionBrand[];
    brands: IBrand[];
}

export const BrandList: React.FC<BrandListProps> = ({ prospectionBrands, brands }) => (
    <section className="brand-list">
        <p>FC70 Brands</p>
        {prospectionBrands.map((brand, index) => {
            const matchingBrand = brands.find(b => b.id === brand.brandId);
            return (
                <article key={index}>
                    {matchingBrand ? <BrandCard prospectionBrand={brand} brandName={matchingBrand?.name} /> : "Brand not found"}
                </article>
            );
        })}
    </section>
);



