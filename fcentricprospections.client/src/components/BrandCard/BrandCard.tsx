import { IProspectionBrand } from "../../types"

interface BrandCardProps {
    prospectionBrand: IProspectionBrand,
    brandName: string
  }

export const BrandCard = ({prospectionBrand, brandName} : BrandCardProps) => {
    return (
        <article>
              <p>{brandName ? brandName : "Unknown Brand"}</p>
              <p>Sellout: {prospectionBrand.sellout}%</p>
              <p>Verantwoordelijke sales: {prospectionBrand.salesRepresentative}</p>
              <p>Commercial support: {prospectionBrand.commercialSupport}</p>  
        </article>
    )
}
