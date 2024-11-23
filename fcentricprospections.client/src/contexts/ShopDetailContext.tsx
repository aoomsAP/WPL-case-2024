import React, { useState, useEffect } from "react"
import { IProspection, IShopDetail } from "../types";

interface ShopDetailContext {
    setShopId: (id: string) => void;
    shopDetail: IShopDetail | undefined,
    shopProspections: IProspection[],
}

export const ShopDetailContext = React.createContext<ShopDetailContext>({ 
    setShopId: () => {},
    shopDetail: {} as IShopDetail,
    shopProspections: [],
});

export const ShopDetailProvider = ({ children }: { children: React.ReactNode }) => {

    const [shopId, setShopId] = useState<string>();
    const [shopDetail, setShopDetail] = useState<IShopDetail | undefined>();
    const [shopProspections, setShopProspections] = useState<IProspection[]>([]);

    async function loadShopDetail(shopId: string) {
        try {
            const response = await fetch(`/api/shops/${shopId}`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IShopDetail | undefined = await response.json();
            setShopDetail(json);

        } catch (error) {
            console.error('Error fetching shops data:', error);
        }
    }

    const loadShopProspections = async (id: string) => {
      try {
        // load list of Shop Prospections
        const responseProspection = await fetch(`/api/shops/${id}/prospections`, {
          method: 'GET',  // Specify the method if it's not 'GET' by default
          headers: {
            'Content-Type': 'application/json',  // Define the expected content type                   
          },
        })
  
        if (!responseProspection.ok) {
          throw new Error('Failed to fetch prospections data')
        }
  
        const json2: IProspection[] = await responseProspection.json();
        setShopProspections(json2)
  
      } catch (error) {
        console.error('Error fetching prospections data:', error);
      }
    }

    useEffect(() => {
        if (shopId) {
            loadShopProspections(shopId);
            loadShopDetail(shopId);
        }
    }, [shopId]);

    return (
        <ShopDetailContext.Provider value={{
            shopDetail: shopDetail,
            setShopId: setShopId,
            shopProspections: shopProspections
        }}>
            {children}
        </ShopDetailContext.Provider>
    )
}