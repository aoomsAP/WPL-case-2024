import { useParams, useLocation, useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { Prospection } from "../../types";
import styles from './ProspectionDetail.module.css'

export const ProspectionDetail = () => {
    const { shopId, prospectionId } = useParams();  // Extract the IDs from the URL for the prospection as the store
    const location = useLocation();  // Get the location object, which contains the passed state so there is no extra call needed
    const navigate = useNavigate();

    // Access the state passed from the previous component
    const state = location.state as { prospection?: Prospection; shopName?: string } | null;

    useEffect(() => {
        if (!state) {
            // If state is missing (e.g., direct URL access), redirect to the shop overview page
            navigate(`/shop/${shopId}/overview`);
        }
    }, [state, navigate, shopId]);

    
    if (!state) {
        return <div>Loading...</div>;
    }

    // Destructure the prospection and shopName from the state
    const { prospection, shopName } = state;

    return (
        <main className={styles.main}>
            <h1 className={styles.h1}>Prospection Details</h1>
            <h2>Winkel: {shopName}</h2>  
            <p>Prospection ID: {prospectionId}</p>  
            <p>Datum: {prospection?.data}</p>
            <section className={styles.section}>
            <h3>Beschrijving:</h3>
            <p>{prospection?.text}</p>
            </section>
        </main>
    );
};

