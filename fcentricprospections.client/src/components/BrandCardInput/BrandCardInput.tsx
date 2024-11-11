import { ProspectionDataContext } from "../../contexts/ProspectionDataContext";
import { IProspectionBrand } from "../../types";
import { useContext, useEffect, useState } from "react";
import styles from "./BrandCardInput.module.css"

interface BrandCardInputProps {
    brand: IProspectionBrand
}

const BrandCardInput = ({ brand }: BrandCardInputProps) => {

    const { prospectionBrands, setProspectionBrands } = useContext(ProspectionDataContext);

    const [sellout, setSellout] = useState<number | undefined>(undefined);
    const [sales, setSales] = useState<string>("");
    const [commercial, setCommercial] = useState<string>("");

    useEffect(() => {
        const newProspectionBrand = {
            brandId: brand.brandId,
            brandName: brand.brandName,
            sellout: sellout,
            salesRepresentative: sales,
            commercialSupport: commercial
        }

        const newProspectionBrands = prospectionBrands.map(p => {
            if (p.brandId === brand.brandId) {
                return newProspectionBrand;
            }
            return p;
        });

        setProspectionBrands(newProspectionBrands);
    }, [sellout, sales, commercial])

    return (
        <fieldset className={styles.brand_fieldset} key={brand.brandId}>
            <legend className={styles.brand_legend}>{brand.brandName}</legend>

            <label>Sellout (%)</label><br />
            <input type="number" max={100} value={sellout} onChange={(e) => setSellout(+e.target.value)} /><br />

            <label>Verantwoordelijke sales</label><br />
            <input type="text" value={sales} onChange={(e) => setSales(e.target.value)} />

            <label>Commercial support</label><br />
            <input type="text" value={commercial} onChange={(e) => setCommercial(e.target.value)} />
        </fieldset>
    )
}

export default BrandCardInput;