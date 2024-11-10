import { useContext, useEffect, useState } from "react";
import { IProspectionBrand } from "../types";
import { ProspectionDataContext } from "../contexts/ProspectionDataContext";

interface BrandInterestCardProps {
    brand: IProspectionBrand
}

const BrandInterestCard = ({ brand }: BrandInterestCardProps) => {

    const { prospectionBrandInterests, setProspectionBrandInterests } = useContext(ProspectionDataContext);

    const [sales, setSales] = useState<string>("");

    useEffect(() => {
        const newProspectionBrandInterest = {
            brandId: brand.brandId,
            brandName: brand.brandName,
            sales: sales,
        }

        const newProspectionBrandInterests = prospectionBrandInterests.map(p => {
            if (p.brandId === brand.brandId) {
                return newProspectionBrandInterest;
            }
            return p;
        });

        setProspectionBrandInterests(newProspectionBrandInterests);
    }, [sales])

    return (
        <div key={brand.brandId}>
            <h4>{brand.brandName}</h4>
            <legend>Sales:</legend>
            <input type="text" value={sales} onChange={(e) => setSales(e.target.value)} />
        </div>
    )
}

export default BrandInterestCard;