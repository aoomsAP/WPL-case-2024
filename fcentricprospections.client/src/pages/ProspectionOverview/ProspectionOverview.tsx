import { useContext, useEffect } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import styles from './ProspectionOverview.module.css'
import { ShopDetailCard } from "../../components/ShopDetailCard/ShopDetailCard";
import { FaAngleRight } from "react-icons/fa";
import { ShopDetailContext } from "../../contexts/ShopDetailContext";

export const ProspectionOverview = () => {

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
        <main className={styles.main}>
            {shopDetail && <ShopDetailCard shop={shopDetail} />}

            <h2>Voorgaande prospecties</h2>

            <section className={styles.section}>
                {shopProspections
                    // sort on date in descending order
                    .sort((a, b) => (new Date(b.visitDate).getTime()) - (new Date(a.visitDate).getTime()))
                    // get three latest prospections
                    .map((prospection) => (
                        <button className={styles.button} key={prospection.id}>
                            <Link to={`/shop/${shopId}/prospections/${prospection.id}`}>
                                Prospectie {new Date(prospection.visitDate).toLocaleDateString()}<FaAngleRight className={styles.icon} />
                            </Link>
                        </button>
                    ))}
            </section>


        </main>
    );
}
