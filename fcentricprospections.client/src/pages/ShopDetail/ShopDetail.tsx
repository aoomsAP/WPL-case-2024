import { useContext, useEffect } from 'react';
import { Link, useParams } from 'react-router-dom';
import { FaAngleRight } from "react-icons/fa";
import { ShopDetailCard } from '../../components/ShopDetailCard/ShopDetailCard';
import styles from './ShopDetail.module.css';
import { ShopDetailContext } from '../../contexts/ShopDetailContext';

export const ShopDetail = () => {
  const { shopId } = useParams<{ shopId: string }>();

  const { setShopId, shopProspections, shopDetail } = useContext(ShopDetailContext);

  useEffect(() => {
    if (shopId) {
      setShopId(shopId);
    }
  }, [])

  return (
    <>
      <main className={styles.main}>

        {shopDetail && <ShopDetailCard shop={shopDetail} />}

        <section className={styles.prospectionSection}>

          <button className={styles.button}>
            <Link className={styles.a} to={`/shop/${shopId}/prospections/new`}>
              Nieuwe Prospectie
            </Link>
          </button>

          <ul>
            {shopProspections
              // sort on date in descending order
              .sort((a, b) => (new Date(b.visitDate).getTime()) - (new Date(a.visitDate).getTime()))
              // get three latest prospections
              .slice(0, 3)
              .map(prospection => (<li className={styles.li} key={prospection.id}>
                <Link className={styles.prospectionA} to={`/shop/${shopId}/prospections/${prospection.id}`}>
                  Prospectie {new Date(prospection.visitDate).toLocaleDateString()}<FaAngleRight className={styles.icon} />
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

