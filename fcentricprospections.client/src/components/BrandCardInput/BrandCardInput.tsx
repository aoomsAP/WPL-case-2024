import { NewProspectionContext } from "../../contexts/NewProspectionContext";
import { IProspectionBrand } from "../../types";
import { useContext, useEffect, useState } from "react";
import styles from "./BrandCardInput.module.css"

interface BrandCardInputProps {
    brand: IProspectionBrand
}

const BrandCardInput = ({ brand }: BrandCardInputProps) => {

    const { prospectionBrands, setProspectionBrands } = useContext(NewProspectionContext);

    const [sellout, setSellout] = useState<number | undefined>(undefined);
    const [selloutRemark, setSelloutRemark] = useState<string>("");

    useEffect(() => {
        const newProspectionBrand = {
            brandId: brand.brandId,
            brandName: brand.brandName,
            sellout: sellout,
            selloutRemark: selloutRemark
        }

        const newProspectionBrands = prospectionBrands.map(p => {
            if (p.brandId === brand.brandId) {
                return newProspectionBrand;
            }
            return p;
        });

        setProspectionBrands(newProspectionBrands);
    }, [sellout, selloutRemark])

    return (
        <fieldset className={styles.brand_fieldset} key={brand.brandId}>
            <legend className={styles.brand_legend}>{brand.brandName}</legend>

            <label>Sellout (%)</label><br />
            <input type="number" max={100} value={sellout} onChange={(e) => setSellout(+e.target.value)} /><br />

            <label>Sellout opmerking</label><br />
            <textarea value={selloutRemark} onChange={(e) => setSelloutRemark(e.target.value)} />
        </fieldset>
    )
}

export default BrandCardInput;