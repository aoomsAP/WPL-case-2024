import { useContext, useEffect } from 'react';
import { Link, useNavigate, useParams } from 'react-router-dom';
import { TfiArrowTopRight, TfiPlus } from "react-icons/tfi";
import { ShopDetailCard } from '../../components/ShopDetailCard/ShopDetailCard';
import styles from './ShopDetail.module.css';
import { ShopDetailContext } from '../../contexts/ShopDetailContext';
import CustomLoader from '../../components/LoaderSpinner/CustomLoader';

export const ShopDetail = () => {

  const navigate = useNavigate();

  const { shopId } = useParams<{ shopId: string }>();

  const { setShopId, shopProspections, shopDetail } = useContext(ShopDetailContext);

  // Set shop id
  useEffect(() => {
    if (shopId) {
      if (Number.isNaN(parseInt(shopId))) {
        // If shopId cannot be set (e.g. undefined), navigate to NotFound page
        navigate("/404");
      }
      else {
        if (!shopDetail) {
          setShopId(parseInt(shopId));
        }
      }
    }
  }, [])

  return (
    <>
      <main>
        {shopDetail && <>
          <h1>{shopDetail.name}</h1>

          <ShopDetailCard shop={shopDetail} />

          <section>
            <p>Voeg een nieuwe prospectie toe:</p>
            <button
              title='Nieuwe prospectie'
              className={styles.add_button}
              onClick={() => navigate(`/shop/${shopId}/prospections/new`)}>
              Nieuwe Prospectie
              <TfiPlus className={styles.add_button__icon} />
            </button>
          </section>

          <section className={styles.overview}>
            <h2>Voorgaande prospecties</h2>
            {shopProspections.length > 0 &&
              <>
                <ul className={styles.ul}>
                  {shopProspections
                    // sort on date in descending order
                    .sort((a, b) => (new Date(b.visitDate).getTime()) - (new Date(a.visitDate).getTime()))
                    // get three latest prospections
                    .slice(0, 3)
                    .map(prospection => (<li className={styles.li} key={prospection.id}>
                      <Link to={`/shop/${shopId}/prospections/${prospection.id}`}>
                        Prospectie {new Date(prospection.visitDate).toLocaleDateString()}
                        <TfiArrowTopRight className={styles.li__icon} />
                      </Link></li>))}
                </ul>
                <button className={styles.link_button} onClick={() => navigate(`/shop/${shopId}/prospections`)}>
                  Overzicht van alle Prospecties
                  <TfiArrowTopRight className={styles.link_button__icon} />
                </button>
              </>
            }
          </section>
        </>
        }

        {!shopDetail &&
          <div className={styles.loading}>
            <p>Winkel wordt geladen...</p>
            <CustomLoader />
          </div>}
      </main>
    </>
  );
};

