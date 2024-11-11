import { useEffect, useState } from 'react';
import { IShopDetail } from '../../types';
import styles from './ShopDetailCard.module.css';

interface ShopDetailCardProps {
  shopId: number;
}

export const ShopDetailCard = ({ shopId }: ShopDetailCardProps) => {

  const [shop, setShop] = useState<IShopDetail | undefined>();

  async function loadShop() {
    try {
      const response = await fetch(`/api/shops/${shopId}`, {
        method: 'GET',
        headers: { 'Content-Type': 'application/json' },
      });

      const json: IShopDetail | undefined = await response.json();
      setShop(json);

    } catch (error) {
      console.error('Error fetching shops data:', error);
    }
  }

  useEffect(() => {
    loadShop();
  }, []);

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
