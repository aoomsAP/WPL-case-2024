import { useContext, useEffect, useState } from "react";
import { IProspectionBrand } from "../../types";
import { NewProspectionContext } from "../../contexts/NewProspectionContext";
import styles from "./BrandInterestCard.module.css"

interface BrandInterestCardProps {
    brand: IProspectionBrand
}

const BrandInterestCard = ({ brand }: BrandInterestCardProps) => {

    const { prospectionBrandInterests, setProspectionBrandInterests } = useContext(NewProspectionContext);

    const [remark, setRemark] = useState<string>("");

    // "X" deletes the current brand from the state array
    function handleClick() {
        // Reset remark
        setRemark("");

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

        const newProspectionBrandInterests = prospectionBrandInterests.map(p => {
            if (p.brandId === brand.brandId) {
                return newProspectionBrandInterest;
            }
            return p;
        });

        setProspectionBrandInterests(newProspectionBrandInterests);
    }, [remark])

    return (
        <fieldset className={styles.brand_fieldset} key={brand.brandId}>
            <button className={styles.close} onClick={handleClick}>X</button>
            <legend className={styles.brand_legend}>{brand.brandName}</legend>
            <label>Opmerking:</label>
            <textarea value={remark} placeholder={`Opmerking over interesse in ${brand.brandName}...`}
            onChange={(e) => setRemark(e.target.value)} />
        </fieldset>
    )
}

export default BrandInterestCard;