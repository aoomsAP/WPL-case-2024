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
          <p>Klant: {shop.customer}</p>
          <p>Adres: {shop.address.street1}, {shop.address.city}</p>
        </div>}
    </section>
  )
}
