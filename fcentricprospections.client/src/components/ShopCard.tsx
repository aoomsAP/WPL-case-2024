import { useEffect, useState } from "react";
import { IShopDetail } from "../types";

interface ShopCardProps {
    shopId: number;
}

const ShopCard = ({ shopId }: ShopCardProps) => {

    const [shop, setShop] = useState<IShopDetail | undefined>();

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

    useEffect(() => {
        loadShop();
    }, []);

    return (
        <>
            {shop &&
                <>
                    <p>{shop.name}</p>
                    <p>Klant: {shop.customer}</p>
                    <p>Address: {shop.address.street1}</p>
                </>}
        </>
    )
}


export default ShopCard;