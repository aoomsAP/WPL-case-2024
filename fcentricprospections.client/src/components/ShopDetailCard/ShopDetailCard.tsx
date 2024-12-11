import styles from './ShopDetailCard.module.css';
import { IShopDetail } from '../../types';

interface ShopDetailProps {
  shop: IShopDetail;
}

export const ShopDetailCard = ({shop}: ShopDetailProps) => {

  return (
    <section className={styles.shopDetailCard}>
      {shop &&
        <div>
          <p>Winkel: {shop.name}</p>
          <p>Klant: {shop.customer ? shop.customer : "geen gegevens"}</p>
          <p>Adres: {shop.address.street1}, {shop.address.city}, {shop.address.country}</p>
          <p>Eigenaar: {shop.owner ? shop.owner : "geen gegevens"}</p>
        </div>}
    </section>
  )
}
