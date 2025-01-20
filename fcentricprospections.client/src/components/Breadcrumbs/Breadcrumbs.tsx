import { Link, useLocation, useParams } from "react-router-dom";
import styles from "./Breadcrumbs.module.css";
import { ShopListContext } from "../../contexts/ShopListContext";
import { useContext } from "react";
import { IProspection, IShop } from "../../types";
import { ShopDetailContext } from "../../contexts/ShopDetailContext";

const routeLabels: Record<string, string> = {
    shop: 'Winkel',
    prospections: 'Prospecties',
    new: 'Nieuw',
    agenda: 'Agenda',
    home: 'Home',
};

export default function Breadcrumbs() {
    const location = useLocation();
    const { shopId, prospectionId } = useParams<{ shopId: string, prospectionId: string }>();
    const { shops } = useContext(ShopListContext);
    const { shopProspections } = useContext(ShopDetailContext);

    function getShopNameById(id: string) {
        const shop = shops.find((shop: IShop) => shop.id.toString() === id);
        return shop ? shop.name : id;
    };

    function getProspectionNameById(id: string) {
        const prospection = shopProspections.find((p: IProspection) => p.id.toString() === id);
        return prospection ? (new Date(prospection.visitDate).toDateString()) : id;
    }

    // Split the path into segments, ignoring empty segments
    const pathSegments = location.pathname.split('/').filter(Boolean);

    // Build breadcrumb links for each segment
    const breadcrumbs = pathSegments.map((segment, index) => {
        const path = `/${pathSegments.slice(0, index + 1).join('/')}`;
        let label = routeLabels[segment] || decodeURIComponent(segment);

        // Get shop name instead of shop id
        if (segment === shopId) {
            label = getShopNameById(segment);
        }

        // Get prospection date instead of prospection id
        // (BUG / TO DO: since shopProspections is not loaded yet, does not work)
        if (segment === prospectionId) {
            label = getProspectionNameById(segment);
        }

        const isActive = location.pathname === path;
        const isLast = index === pathSegments.length - 1;

        // If segment is shop, remove Link, because /shop is no valid route
        if (segment === "shop") {
            return (
                <span key={path} className={`${styles.crumb} ${isActive ? styles.active : ''}`}>
                    <span>
                        {label}
                    </span>
                    {!isLast && <span className={styles.separator}> / </span>}
                </span>
            )
        }
        // Otherwise, return segment as Link
        else {
            return (
                <span key={path} className={`${styles.crumb} ${isActive ? styles.active : ''}`}>
                    <Link to={path} className={isActive ? styles.active : ''}>
                        {label}
                    </Link>
                    {!isLast && <span className={styles.separator}> / </span>}
                </span>
            );
        }
    });

    return (
        <nav className={styles.breadcrumbs}>
            {/* Manually add index link (except on index page), because / is filtered out of path segments */}
            {location.pathname != "/" &&
                <span className={`${styles.crumb} ${styles.home}`}>
                    <Link to="/">
                        Index
                    </Link>
                    {breadcrumbs.length > 0 && <span className={styles.separator}> / </span>}
                </span>
            }
            {/* Manually add homepage link, because /home is not part of path in current router state */}
            {/* Do not add on "/home" to avoid duplicate, and do not add on index */}
            {(location.pathname != "/home" && location.pathname != "/") &&
                <span className={`${styles.crumb} ${styles.home}`}>
                    <Link to="/home">
                        Home
                    </Link>
                    {breadcrumbs.length > 0 && <span className={styles.separator}> / </span>}
                </span>
            }
            {breadcrumbs}
        </nav>
    );
}