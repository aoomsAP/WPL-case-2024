import { NewProspectionContext } from "../../../contexts/NewProspectionContext";
import { IProspectionBrand } from "../../../types";
import { useContext, useEffect, useState } from "react";
import styles from "./BrandInput.module.css"

interface BrandInputProps {
    brand: IProspectionBrand
}

const BrandInput = ({ brand }: BrandInputProps) => {

    const { prospectionBrands, setProspectionBrands } = useContext(NewProspectionContext);

    const currentProspectionBrand = prospectionBrands.find(x => x.brandId == brand.brandId);

    const [sellout, setSellout] = useState<number | undefined>(currentProspectionBrand?.sellout ?? undefined);
    const [selloutRemark, setSelloutRemark] = useState<string>(currentProspectionBrand?.selloutRemark ?? "");

    useEffect(() => {
        const newProspectionBrand = {
            brandId: brand.brandId,
            brandName: brand.brandName,
            sellout: sellout,
            selloutRemark: selloutRemark
        }

        // Only replace NEW brand in prospection brands array
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
            <h4>{brand.brandName}</h4>

            <div>
                <label>Sellout (%)</label>
                <input
                    type="number"
                    min={0}
                    max={100}
                    defaultValue={sellout}
                    placeholder="[0-100]"
                    onChange={(e) => setSellout(+e.target.value)} /><br />
            </div>

            <div>
                <label>Opmerking:</label>
                <textarea
                    value={selloutRemark}
                    placeholder="Opmerking over de verkoop..."
                    onChange={(e) => setSelloutRemark(e.target.value)} />
            </div>
        </fieldset>
    )
}

export default BrandInput;