import { useContext } from "react";
import { NewProspectionContext } from "../../contexts/NewProspectionContext";
import styles from "./BrandTag.module.css";

interface BrandTagProps {
    brandId: number;
    brandName: string;
    type: "brand" | "competitorBrand";
}

const BrandTag = ({ brandId, brandName, type }: BrandTagProps) => {

    const { prospectionBrands, setProspectionBrands, prospectionCompetitorBrands, setProspectionCompetitorBrands } = useContext(NewProspectionContext);

    // "X" deletes the current brand from the state array
    function handleClick() {
        switch (type) {
            case "brand":
                // Filter out the current brand
                const filteredProspectionBrands = prospectionBrands.filter(brand => brandId !== brand.brandId);
                // Set new filtered array
                setProspectionBrands(filteredProspectionBrands);
                break;
            case "competitorBrand": {
                // Filter out the current competitor brand
                const filteredProspectionCompetitorBrands = prospectionCompetitorBrands.filter(brand => brandId !== brand.brandId);
                // Set new filtered array
                setProspectionCompetitorBrands(filteredProspectionCompetitorBrands);
                break;
            }
        }
    }

    return (
        <div key={brandId}>
            {brandName} <span className={styles.close} onClick={handleClick}>{type === "brand" ? "" : "X"}</span>
        </div>
    );
}

export default BrandTag;