import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import styles from './ProspectionOverview.module.css'
import { IProspection } from "../../types";
import { ShopDetailCard } from "../../components/ShopDetailCard/ShopDetailCards";
import { FaAngleRight } from "react-icons/fa";

export const ProspectionOverview = () => {

    const { shopId } = useParams<{ shopId: string }>();

    const [prospections, setProspections] = useState<IProspection[]>([]);

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
        loadProspections();
    }, []);

    return (
        <main className={styles.main}>
          {shopId && !isNaN(+shopId) && <ShopDetailCard shopId={+shopId} />}

            <h2>Voorgaande prospecties</h2>

            <section className={styles.section}>
                {prospections
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
