import { useContext, useEffect } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import styles from './ProspectionOverview.module.css'
import { ShopDetailCard } from "../../components/ShopDetailCard/ShopDetailCard";
import { ShopDetailContext } from "../../contexts/ShopDetailContext";
import { TfiArrowTopRight } from "react-icons/tfi";
import CustomLoader from "../../components/LoaderSpinner/CustomLoader";

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
                if (!shopDetail) {
                    setShopId(parseInt(shopId));
                }
            }
        }
    }, [])

    return (
        <main className={styles.main}>

            <h1>Overzicht prospecties</h1>

            {shopDetail && <ShopDetailCard shop={shopDetail} />}

            <ul className={styles.ul}>
                {shopProspections
                    // sort on date in descending order
                    .sort((a, b) => (new Date(b.visitDate).getTime()) - (new Date(a.visitDate).getTime()))
                    // get three latest prospections
                    .map(prospection => (<li className={styles.li} key={prospection.id}>
                        <Link to={`/shop/${shopId}/prospections/${prospection.id}`}>
                            Prospectie {new Date(prospection.visitDate).toLocaleDateString()}
                            <TfiArrowTopRight className={styles.li__icon} />
                        </Link></li>))}
            </ul>

            {!shopProspections &&
                <div className={styles.loading}>
                    <p>Prospecties worden geladen...</p>
                    <CustomLoader />
                </div>}

            <button
                className={styles.link_button}
                onClick={() => navigate(`/shop/${shopId}`)}>
                Terug naar winkel
                <TfiArrowTopRight className={styles.link_button__icon} />
            </button>
        </main>
    );
}
