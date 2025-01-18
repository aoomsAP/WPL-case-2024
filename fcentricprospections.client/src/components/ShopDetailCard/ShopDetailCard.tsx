import styles from './ShopDetailCard.module.css';
import { IAddress, IShopDetail } from '../../types';

interface ShopDetailProps {
  shop: IShopDetail;
}

export const ShopDetailCard = ({ shop }: ShopDetailProps) => {

  const getStreet = (obj: Partial<IAddress>): string => {
    // Only get street1, city and country
    const allowedProperties = ["street1", "city", "country"];
  
    return allowedProperties
      .map((key) => obj[key as keyof IAddress]) // Get values
      .filter((value) => value?.toString().trim() !== "") // Filter out empty values
      .join(", ");
  };

  return (
    <section className={styles.shopDetailCard}>
      <p><strong>{shop.name ? <>{shop.name}</> : <>Winkel niet gevonden</>}</strong></p>
      <p>Klant: {shop.customer ? shop.customer : "N/A"}</p>
      <p>Adres: {shop.address ? (<>{getStreet(shop.address)}</>) : "N/A"}</p>
      <p>Eigenaar: {shop.owner ? shop.owner : "N/A"}</p>
    </section>
  )
}
