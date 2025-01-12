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
        <fieldset className={styles.brand_fieldset}>
            <h3>{brand.brandName}</h3>

            <div>
                <label>Sellout (%)</label>
                <input type="number" max={100} defaultValue={sellout} placeholder="[0-100]"
                    onChange={(e) => setSellout(+e.target.value)} /><br />
            </div>

            <div>
                <label>Sellout opmerking</label>
                <textarea value={selloutRemark} placeholder="Sellout omschrijving..."
                    onChange={(e) => setSelloutRemark(e.target.value)} />
            </div>
        </fieldset>
    )
}

export default BrandCardInput;