import React, { useState, useEffect } from "react"
import { IShop } from "../types";

interface ShopListContext {
    shops: IShop[],
    loadShops: () => Promise<void>,
}

export const ShopListContext = React.createContext<ShopListContext>({
    shops: [],
    loadShops: () => Promise.resolve(),
});

export const ShopListProvider = ({ children }: { children: React.ReactNode }) => {

    const [shops, setShops] = useState<IShop[]>([]);

    const loadShops = async () => {
        try {
            const response = await fetch('/api/shops')
            const json: IShop[] = await response.json();
            console.log(`Shops loaded (${json.length}): `, json)
            setShops(json);
        }
        catch (error) {
            console.error('Error fetching shops data:', error);
        }
    };

    useEffect(() => {
        loadShops();
    }, []);

    return (
        <ShopListContext.Provider value={{
            shops: shops,
            loadShops: loadShops
        }}>
            {children}
        </ShopListContext.Provider>
    )
}