import React from 'react';
import { IProspectionBrand, IBrand } from '../../../types';
import { BrandCard } from '../BrandCard/BrandCard';
import styles from "./BrandList.module.css"

interface BrandListProps {
    prospectionBrands: IProspectionBrand[];
    brands: IBrand[];
}

export const BrandList: React.FC<BrandListProps> = ({ prospectionBrands, brands }) => (
    <section className={styles.brandList}>
        {prospectionBrands.map((brand, index) => {
            const matchingBrand = brands.find(b => b.id === brand.brandId);
            return (
                <article key={index}>
                    {matchingBrand ? <BrandCard prospectionBrand={brand} brandName={matchingBrand?.name} /> : <p className={styles.brandNotFound}>Merk niet gevonden</p>}
                </article>
            );
        })}
    </section>
);



