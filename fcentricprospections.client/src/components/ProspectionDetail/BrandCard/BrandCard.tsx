import { IProspectionBrand } from "../../../types"
import styles from "./BrandCard.module.css"

interface BrandCardProps {
    prospectionBrand: IProspectionBrand,
    brandName: string
}

export const BrandCard = ({ prospectionBrand, brandName }: BrandCardProps) => {
    return (
        <div className={styles.card}>
            <h3>{brandName ? brandName : "Merk onbekend"}</h3>
            {prospectionBrand.sellout && <p><strong>Sellout: </strong>{prospectionBrand.sellout}{prospectionBrand.sellout ? "%" : ""}</p>}
            {prospectionBrand.selloutRemark && <p><strong>Opmerking: </strong>{prospectionBrand.selloutRemark}</p>}
        </div>
    )
}
