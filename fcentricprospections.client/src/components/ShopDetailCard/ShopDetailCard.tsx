import styles from './ShopDetailCard.module.css';
import { IShopDetail } from '../../types';

interface ShopDetailProps {
  shop: IShopDetail;
}

export const ShopDetailCard = ({ shop }: ShopDetailProps) => {

  return (
    <section className={styles.shopDetailCard}>
      <p><strong>{shop.name ? <>{shop.name}</> : <>Winkel niet gevonden</>}</strong></p>
      <p>Klant: {shop.customer ? shop.customer : "geen gegevens"}</p>
      <p>Adres: {shop.address ? (<>{shop.address.street1}, {shop.address.city}, {shop.address.country}</>) : "geen gegevens"}</p>
      <p>Eigenaar: {shop.owner ? shop.owner : "geen gegevens"}</p>
    </section>
  )
}
