import React from 'react';
import { Shop } from '../../types';
import styles from './ShopDetailCard.module.css';

interface ShopDetailCardProps {
  shop: Shop;
}

export const ShopDetailCard: React.FC<ShopDetailCardProps> = ({ shop }) => (
  <section className={styles.shopDetailCard}>
    <div>
      <p>Winkel: {shop.name}</p>
      <p>Klant: {shop.customer}</p>
      <p>Adres: {shop.address.street1}</p>
    </div>
  </section>
);
