import { useEffect, useState } from 'react';
import styles from './ShopPage.module.css';
import { Shop, Prospection } from '../../types'
import { Link, useParams } from 'react-router-dom';
import { FaAngleRight } from "react-icons/fa";
import ShopCard from '../../components/ShopCard';

export const ShopPage = () => {
  const { shopId } = useParams<{ shopId: string }>(); // Ensure correct types for TypeScript

  const [shopData, setShopData] = useState<Shop | undefined>(undefined);
  const [shopProspections, setShopProspections] = useState<Prospection[]>([]);

  const loadShopDetail = async (id: string) => {

    try {
      // load list of Shops
      const response = await fetch(`/api/shops/${id}`, {
        method: 'GET',  // Specify the method if it's not 'GET' by default
        headers: {
          'Content-Type': 'application/json',  // Define the expected content type                   
        },
      });

      if (!response.ok) {
        throw new Error('Failed to fetch shop data');
      }

      const json: Shop = await response.json();
      setShopData(json);

      // load list of Shop Prospections
      const responseProspection = await fetch(`/api/shops/${id}/prospections`, {
        method: 'GET',  // Specify the method if it's not 'GET' by default
        headers: {
          'Content-Type': 'application/json',  // Define the expected content type                   
        },
      })

      if (!responseProspection.ok) {
        throw new Error('Failed to fetch prospection data')
      }

      const json2: Prospection[] = await responseProspection.json();
      setShopProspections(json2)

    } catch (error) {
      console.error('Error fetching shop data:', error);
    }
  }

  useEffect(() => {
    if (shopId)
      loadShopDetail(shopId);
  }, [shopId])

  return (
    <>
      <main className={styles.main}>
        <section className={styles.infoSection}>

          {shopId && !isNaN(Number(shopId)) && <ShopCard shopId={Number(shopId)} />}

        </section>

        <section className={styles.prospectionSection}>
          <button className={styles.button}>
            <Link className={styles.a} to={`/shop/${shopId}/prospections/new`}>Nieuwe Prospectie</Link>
          </button>
          <ul>
            {shopProspections.map(prospection => (<li className={styles.li} key={prospection.id}>  {/* Ensure each `li` has a unique `key` */}
              <Link className={styles.prospectionA} to={`/shop/${shopId}/prospections/${prospection.id}`}>Prospectie {prospection.date.slice(0, 10)}<FaAngleRight className={styles.icon} /> </Link></li>))}
          </ul>
          <button className={styles.button}>
            <Link className={styles.a} to={`/shop/${shopId}/prospections/overview`}>Overzicht van alle Prospecties</Link>
          </button>
        </section>

      </main>
    </>
  );
};

