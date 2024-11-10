import { useEffect, useState } from 'react';
import styles from './ShopPage.module.css';
import { IShopDetail, IProspection } from '../../types'
import { Link, useParams } from 'react-router-dom';
import { FaAngleRight } from "react-icons/fa";
import { ShopDetailCard } from '../../components/ShopDetailCard/ShopDetailCards';

export const ShopPage = () => {
  const { shopId } = useParams<{ shopId: string }>(); // Ensure correct types for TypeScript

  const [shopData, setShopData] = useState<IShopDetail | undefined>(undefined);
  const [shopProspections, setShopProspections] = useState<IProspection[]>([]);

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

      const json: IShopDetail = await response.json();
      setShopData(json);

      // load list of Shop Prospections
      const responseProspection = await fetch(`/api/shops/${id}/prospections`, {
        method: 'GET',  // Specify the method if it's not 'GET' by default
        headers: {
          'Content-Type': 'application/json',  // Define the expected content type                   
        },
      })

      if (!responseProspection.ok) {
        throw new Error('Failed to fetch prospections data')
      }

      const json2: IProspection[] = await responseProspection.json();
      setShopProspections(json2)

    } catch (error) {
      console.error('Error fetching prospections data:', error);
    }
  }

  useEffect(() => {
    if (shopId)
      loadShopDetail(shopId);
  }, [shopId])

  return (
    <>
      <main className={styles.main}>
        <section>

          {shopData && !isNaN(Number(shopId)) && <ShopDetailCard shop={shopData} />}

        </section>

        <section className={styles.prospectionSection}>
          <button className={styles.button}>
            <Link className={styles.a} to={`/shop/${shopId}/prospections/new`}>Nieuwe Prospectie</Link>
          </button>
          <ul>
            {shopProspections.sort((a, b) => (Number(b.date))-(Number(a.date))).slice(0, 3)
              .map(prospection => (<li className={styles.li} key={prospection.id}>
                <Link className={styles.prospectionA} to={`/shop/${shopId}/prospections/${prospection.id}`}>
                  Prospectie {prospection.date?.toString().slice(0, 10)}<FaAngleRight className={styles.icon} />
                </Link></li>))}
          </ul>
          <button className={styles.button}>
            <Link className={styles.a} to={`/shop/${shopId}/prospections`}>Overzicht van alle Prospecties</Link>
          </button>
        </section>

      </main>
    </>
  );
};

