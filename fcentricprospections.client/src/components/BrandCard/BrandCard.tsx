import { IProspectionBrand } from "../../types"
import styles from "./BrandCard.module.css"

interface BrandCardProps {
    prospectionBrand: IProspectionBrand,
    brandName: string
  }

export const BrandCard = ({prospectionBrand, brandName} : BrandCardProps) => {
    return (
        <article className={styles.brandCard}>
              <h3>{brandName ? brandName : "Unknown Brand"}</h3>
              <p>Sellout: {prospectionBrand.sellout}%</p>
              <p>Verantwoordelijke sales: {prospectionBrand.salesRepresentative}</p>
              <p>Commercial support: {prospectionBrand.commercialSupport}</p>  
        </article>
    )
}
