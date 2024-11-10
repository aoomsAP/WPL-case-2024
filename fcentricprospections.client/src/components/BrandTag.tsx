import { useContext } from "react";
import { ProspectionDataContext } from "../contexts/ProspectionDataContext";

interface BrandTagProps {
    brandId: number;
    brandName: string;
    type: "brand" | "competitorBrand";
}

const BrandTag = ({ brandId, brandName, type }: BrandTagProps) => {

    const { prospectionBrands, setProspectionBrands, prospectionCompetitorBrands, setProspectionCompetitorBrands } = useContext(ProspectionDataContext);

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
            {brandName} <span onClick={handleClick}>X</span>
        </div>
    );
}

export default BrandTag;