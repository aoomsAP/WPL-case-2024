import { useContext, useEffect } from "react";
import { Link, useParams } from "react-router-dom";
import styles from './ProspectionOverview.module.css'
import { ShopDetailCard } from "../../components/ShopDetailCard/ShopDetailCards";
import { FaAngleRight } from "react-icons/fa";
import { ShopDetailContext } from "../../contexts/ShopDetailContext";

export const ProspectionOverview = () => {

    const { shopId } = useParams<{ shopId: string }>();

    const { setShopId, shopProspections, shopDetail } = useContext(ShopDetailContext);

    useEffect(() => {
        if (shopId) {
          setShopId(shopId);
        }
      }, [])

    return (
        <main className={styles.main}>
          {shopDetail && <ShopDetailCard shop={shopDetail} />}

            <h2>Voorgaande prospecties</h2>

            <section className={styles.section}>
                {shopProspections
                    // sort on date in descending order
                    .sort((a, b) => (new Date(b.date).getTime()) - (new Date(a.date).getTime()))
                    // get three latest prospections
                    .map((prospection) => (
                        <button className={styles.button} key={prospection.id}>
                            <Link to={`/shop/${shopId}/prospections/${prospection.id}`}>
                                Prospectie {new Date(prospection.date).toLocaleDateString()}<FaAngleRight className={styles.icon} />
                            </Link>
                        </button>
                    ))}
            </section>


        </main>
    );
}
