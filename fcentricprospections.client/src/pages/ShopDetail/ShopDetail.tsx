import { useContext, useEffect } from 'react';
import { Link, useNavigate, useParams } from 'react-router-dom';
import { FaAngleRight } from "react-icons/fa";
import { ShopDetailCard } from '../../components/ShopDetailCard/ShopDetailCard';
import styles from './ShopDetail.module.css';
import { ShopDetailContext } from '../../contexts/ShopDetailContext';
import { Oval } from 'react-loader-spinner'

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
        setShopId(parseInt(shopId));
      }
    }
  }, [])

  return (
    <>
      <main>

        {!shopDetail
          ? <Oval />
          : <>
          
            <ShopDetailCard shop={shopDetail} />

            <section>

              <button onClick={() => navigate(`/shop/${shopId}/prospections/new`)}>
                Nieuwe Prospectie
              </button>

              <ul className={styles.ul}>
                {shopProspections
                  // sort on date in descending order
                  .sort((a, b) => (new Date(b.visitDate).getTime()) - (new Date(a.visitDate).getTime()))
                  // get three latest prospections
                  .slice(0, 3)
                  .map(prospection => (<li className={styles.li} key={prospection.id}>
                    <Link
                      className={styles.prospectionA}
                      to={`/shop/${shopId}/prospections/${prospection.id}`}>
                      Prospectie {new Date(prospection.visitDate).toLocaleDateString()}<FaAngleRight className={styles.icon} />
                    </Link></li>))}
              </ul>

              <button onClick={() => navigate(`/shop/${shopId}/prospections`)}>
                Overzicht van alle Prospecties
              </button>

            </section>
          </>
        }

      </main>
    </>
  );
};

