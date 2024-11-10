import React from 'react';
import { Shop } from '../../types';

interface ShopDetailCardProps {
  shop: Shop;
}

export const ShopDetailCard: React.FC<ShopDetailCardProps> = ({ shop }) => (
  <section className="card">
    <p>Winkel: {shop.name}</p>
    <p>Klant: {shop.customer}</p>
    <p>Adres: {shop.address.street1}</p>
  </section>
);
