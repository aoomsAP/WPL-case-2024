import React, { useState, useEffect } from "react"
import { IBrand, IProspection, IShopDetail } from "../types";

interface ShopDetailContext {
    setShopId: (id: number) => void;
    shopDetail: IShopDetail | undefined,
    shopProspections: IProspection[],
    shopBrands: IBrand[],
    loadShopProspections: (shopId: number) => Promise<void>,
} 

export const ShopDetailContext = React.createContext<ShopDetailContext>({
    setShopId: () => { },
    shopDetail: {} as IShopDetail,
    shopProspections: [],
    shopBrands: [],
    loadShopProspections: () => Promise.resolve(),
});

export const ShopDetailProvider = ({ children }: { children: React.ReactNode }) => {

    const [shopId, setShopId] = useState<number>();
    const [shopDetail, setShopDetail] = useState<IShopDetail | undefined>();
    const [shopProspections, setShopProspections] = useState<IProspection[]>([]);
    const [shopBrands, setShopBrands] = useState<IBrand[]>([]);

    async function loadShopDetail(shopId: number) {
        try {
            const response = await fetch(`/api/shops/${shopId}`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IShopDetail | undefined = await response.json();
            setShopDetail(json);

            console.log("shop detail loaded", json)

        } catch (error) {
            console.error('Error fetching shops data:', error);
        }
    }

    const loadShopProspections = async (id: number) => {
        try {
            const responseProspection = await fetch(`/api/shops/${id}/prospections`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                },
            })

            if (!responseProspection.ok) {
                throw new Error('Failed to fetch prospections data')
            }

            const json: IProspection[] = await responseProspection.json();
            setShopProspections(json)

        } catch (error) {
            console.error('Error fetching prospections data:', error);
        }
    }

    async function loadShopBrands(shopId: number) {
        try {
            const response = await fetch(`/api/shops/${shopId}/brands`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IBrand[] = await response.json();
            setShopBrands(json);

            console.log("shop brands set");
        } catch (error) {
            console.error('Error fetching brands data:', error);
        }
    }

    useEffect(() => {
        if (shopId) {
            loadShopProspections(shopId);
            loadShopDetail(shopId);
            loadShopBrands(shopId);
        }
    }, [shopId]);

    return (
        <ShopDetailContext.Provider value={{
            shopDetail: shopDetail,
            setShopId: setShopId,
            shopProspections: shopProspections,
            shopBrands: shopBrands,
            loadShopProspections: loadShopProspections
        }}>
            {children}
        </ShopDetailContext.Provider>
    )
}