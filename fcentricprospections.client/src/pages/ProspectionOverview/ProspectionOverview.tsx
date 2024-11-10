import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import styles from './ProspectionOverview.module.css'
import { IProspection, IShopDetail } from "../../types";
import { ShopDetailCard } from "../../components/ShopDetailCard/ShopDetailCards";

export const ProspectionOverview = () => {

    const { shopId } = useParams<{ shopId: string }>();

    const [shop, setShop] = useState<IShopDetail | undefined>();
    const [prospections, setProspections] = useState<IProspection[]>([]);

    async function loadShop() {
        try {
            const response = await fetch(`/api/shops/${shopId}`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IShopDetail | undefined = await response.json();
            setShop(json);

        } catch (error) {
            console.error('Error fetching shops data:', error);
        }
    }

    async function loadProspections() {
        try {
            const response = await fetch(`/api/shops/${shopId}/prospections`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IProspection[] = await response.json();
            setProspections(json);

        } catch (error) {
            console.error('Error fetching shops data:', error);
        }
    }

    useEffect(() => {
        loadShop();
        loadProspections();
    }, []);

    return (
        <main className={styles.main}>
            {shop && <ShopDetailCard shop={shop} />}

            <h2>Voorgaande prospecties</h2>

            <section className={styles.section}>
                {prospections
                .sort((a, b) => (Number(a.date))-(Number(b.date))) // TODO: FIX
                .map((prospection) => (
                    <button key={prospection.id}>
                        <Link to={`/shop/${shopId}/prospections/${prospection.id}`}>
                            {new Date(prospection.date).toLocaleDateString()}
                        </Link>
                    </button>
                ))}
            </section>


        </main>
    );
}
