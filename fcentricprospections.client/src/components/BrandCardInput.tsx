import { ProspectionDataContext } from "../contexts/ProspectionDataContext";
import { IProspectionBrand } from "../types";
import { useContext, useEffect, useState } from "react";


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
        <div key={brand.brandId}>
            <h4>{brand.brandName}</h4>
            <legend>Sellout (%)</legend>
            <input type="number" max={100} value={sellout} onChange={(e) => setSellout(+e.target.value)} />
            <legend>Verantwoordelijke sales</legend>
            <input type="text" value={sales} onChange={(e) => setSales(e.target.value)} />
            <legend>Commercial support</legend>
            <input type="text" value={commercial} onChange={(e) => setCommercial(e.target.value)} />
        </div>
    )
}

export default BrandCardInput;