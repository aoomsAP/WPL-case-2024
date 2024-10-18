import React, { useState, useEffect } from "react"

interface ShopIdContextType {
    shopNames: ShopId[]; // This is now an array of ShopId objects
  }

interface ShopId {
    id: string; // Example property, replace with real ones
    name: string; // Example property
  }

export const ShopIdContext = React.createContext<ShopIdContextType>({shopNames : []});

export const DataProvider =  ({children} : {children :  React.ReactNode}) =>{

    const [shopNames , setShopNames] = useState<ShopId[]>([]);

    /*
    const loadData = async () =>{
        const response = await fetch("")
        const json = await response.json();
        setShopNames(json);
    }*/

         // Load dummy data instead of fetching from an API
    const loadData = async () => {
        // Replace this with actual fetch if needed in the future
        const dummyData: ShopId[] = [
            { id: "1", name: "Coffee Shop" },
            { id: "2", name: "Bookstore" },
            { id: "3", name: "Grocery Store" },
            { id: "4", name: "Clothing Boutique" },
            { id: "5", name: "Electronics Store" },
            { id: "6", name: "Flower Shop" },
            { id: "7", name: "Music Store" },
            { id: "8", name: "Hardware Store" },
            { id: "9", name: "Jewelry Store" },
            { id: "10", name: "Art Gallery" },
        ];
        setShopNames(dummyData);
    };



    useEffect(() => {
        loadData();
    }, []);

    return (
        <ShopIdContext.Provider value={{shopNames : shopNames}}>
            {children}
        </ShopIdContext.Provider>
    )
}