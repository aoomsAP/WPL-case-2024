import { useEffect, useState } from 'react';
import { IProspection } from '../../types'
import { Link, useParams } from 'react-router-dom';
import { FaAngleRight } from "react-icons/fa";
import { ShopDetailCard } from '../../components/ShopDetailCard/ShopDetailCards';
import styles from './ShopPage.module.css';

export const ShopPage = () => {
  const { shopId } = useParams<{ shopId: string }>(); // Ensure correct types for TypeScript

  const [shopProspections, setShopProspections] = useState<IProspection[]>([]);

  const loadShopProspections = async (id: string) => {
    try {
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
      loadShopProspections(shopId);
  }, [shopId])

  return (
    <>
      <main className={styles.main}>

        {shopId && !isNaN(+shopId) && <ShopDetailCard shopId={+shopId} />}

        <section className={styles.prospectionSection}>
          <button className={styles.button}>
            <Link className={styles.a} to={`/shop/${shopId}/prospections/new`}>
              Nieuwe Prospectie
            </Link>
          </button>
          <ul>
            {shopProspections
              // sort on date in descending order
              .sort((a, b) => (new Date(b.date).getTime()) - (new Date(a.date).getTime()))
              // get three latest prospections
              .slice(0, 3)
              .map(prospection => (<li className={styles.li} key={prospection.id}>
                <Link className={styles.prospectionA} to={`/shop/${shopId}/prospections/${prospection.id}`}>
                  Prospectie {new Date(prospection.date).toLocaleDateString()}<FaAngleRight className={styles.icon} />
                </Link></li>))}
          </ul>
          <button className={styles.button}>
            <Link className={styles.a} to={`/shop/${shopId}/prospections`}>
              Overzicht van alle Prospecties
            </Link>
          </button>
        </section>

      </main>
    </>
  );
};

