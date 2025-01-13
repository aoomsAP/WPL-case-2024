import { useContext, useEffect, useState } from "react";
import { IProspectionBrandInterest, OptionType } from "../../../types";
import { NewProspectionContext } from "../../../contexts/NewProspectionContext";
import styles from "./BrandInterestInput.module.css"

interface BrandInterestInputProps {
    brand: IProspectionBrandInterest,
    selected: OptionType[],
    setSelected: (selected: OptionType[]) => void;
}

const BrandInterestInput = ({ brand, selected,setSelected }: BrandInterestInputProps) => {

    const { prospectionBrandInterests, setProspectionBrandInterests } = useContext(NewProspectionContext);

    const currentProspectionBrand = prospectionBrandInterests.find(x => x.brandId == brand.brandId);

    const [remark, setRemark] = useState<string>(currentProspectionBrand?.remark ?? "");

    // "X" deletes the current brand from the state array
    function handleClick() {
        // Reset remark
        setRemark("");
        // Remove from selection
        setSelected(selected.filter(x => x.value != brand.brandId.toString()))
        // Filter out the current brand
        const filteredProspectionBrandInterests = prospectionBrandInterests.filter(b => b.brandId !== brand.brandId);
        // Set new filtered array
        setProspectionBrandInterests(filteredProspectionBrandInterests);
    }

    useEffect(() => {
        const newProspectionBrandInterest = {
            brandId: brand.brandId,
            brandName: brand.brandName,
            remark: remark,
        }

        // Only replace NEW brand interest in prospection brand interests array
        const newProspectionBrandInterests = prospectionBrandInterests.map(p => {
            if (p.brandId === brand.brandId) {
                return newProspectionBrandInterest;
            }
            return p;
        });

        setProspectionBrandInterests(newProspectionBrandInterests);
    }, [remark])

    return (
        <fieldset className={styles.brand_fieldset}>
            <button className={styles.close} onClick={handleClick}>X</button>
            <legend><strong>{brand.brandName}</strong></legend>
            <label>Opmerking:</label>
            <textarea value={remark} placeholder={`Opmerking over interesse in ${brand.brandName}...`}
                onChange={(e) => setRemark(e.target.value)} />
        </fieldset>
    )
}

export default BrandInterestInput;