import { IProspectionBrand } from "../../types"
import styles from "./BrandCard.module.css"

interface BrandCardProps {
    prospectionBrand: IProspectionBrand,
    brandName: string
  }

export const BrandCard = ({prospectionBrand, brandName} : BrandCardProps) => {
    return (
        <article className={styles.brandCard}>
            <h3>{brandName ? brandName : "Merk onbekend"}</h3>
            {prospectionBrand.sellout && <p>Sellout: {prospectionBrand.sellout}{prospectionBrand.sellout ? "%" : ""}</p>}
            {prospectionBrand.selloutRemark &&<p>Opmerking: {prospectionBrand.selloutRemark}{prospectionBrand.selloutRemark}</p>}
        </article>
    )
}
