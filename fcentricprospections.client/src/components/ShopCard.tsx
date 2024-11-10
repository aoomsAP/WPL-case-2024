import { useEffect, useState } from "react";
import { Shop } from "../types";

interface ShopCardProps {
    shopId: number;
}

const ShopCard = ({ shopId }: ShopCardProps) => {

    const [shop, setShop] = useState<Shop | undefined>();

    async function loadShop() {
        try {
            const response = await fetch(`/api/shops/${shopId}`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: Shop | undefined = await response.json();
            setShop(json);

        } catch (error) {
            console.error('Error fetching shops data:', error);
        }
    }

    useEffect(() => {
        loadShop();
    }, []);

    return (
        <>
            {shop &&
                <>
                    <p>{shop.name}</p>
                    <p>{shop.customer}</p>
                    <p>{shop.address.street1}</p>
                </>}
        </>
    )
}


export default ShopCard;