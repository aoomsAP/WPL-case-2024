import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import styles from './ProspectionOverview.module.css'
import { Shop2 } from "../../types";

export const ProspectionOverview = () => {

    const { shopId } = useParams<{ shopId: string }>();

    const [prospectieList, setProspectieList] = useState<Shop2>();

    useEffect(() => {

    }, [shopId])

    return (
        <main className={styles.main}>
            <h1>{prospectieList?.shopName}</h1>

            <h2>Voorgaande prospecties</h2>

            <section className={styles.section}>
                {prospectieList?.prospections.map((item) => (
                    <button key={`${prospectieList.id}-${item.id}`}>
                        <Link
                            to={`/shop/${shopId}/prospections/${item.id}`}
                            state={{ prospection: item, shopName: prospectieList.shopName }}
                        >
                            {item.data}
                        </Link>
                    </button>
                ))}
            </section>


        </main>
    );
}
