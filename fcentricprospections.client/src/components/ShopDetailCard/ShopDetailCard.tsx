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
      // Get only allowed properties from address object
      .map((key) => obj[key as keyof IAddress])

      // Filter out the empty values
      .filter((value) => (value != null) && (value?.toString().trim() !== ""))

      // Join with comma and white space
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
