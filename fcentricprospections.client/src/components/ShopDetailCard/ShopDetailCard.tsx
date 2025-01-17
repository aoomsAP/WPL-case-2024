import styles from './ShopDetailCard.module.css';
import { IShopDetail } from '../../types';

interface ShopDetailProps {
  shop: IShopDetail;
}

export const ShopDetailCard = ({ shop }: ShopDetailProps) => {

  return (
    <section className={styles.shopDetailCard}>
      <p><strong>{shop.name ? <>{shop.name}</> : <>Winkel niet gevonden</>}</strong></p>
      <p>Klant: {shop.customer ? shop.customer : "N/A"}</p>
      <p>Adres: {shop.address ? (<>{shop.address.street1}, {shop.address.city}, {shop.address.country}</>) : "N/A"}</p>
      <p>Eigenaar: {shop.owner ? shop.owner : "N/A"}</p>
    </section>
  )
}
