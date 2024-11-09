import React, { useState, useEffect } from "react"
import { IShop } from "../types";

interface DataContext{
    
}

export const ShopIdContext = React.createContext<DataContext>({shopNames : []});

export const DataProvider =  ({children} : {children :  React.ReactNode}) =>{

    const [shopNames , setShopNames] = useState<IShop[]>([]);

         
    const loadShops = async () => {
       
        const  response = await fetch('/api/shops')
        const json : IShop[] = await response.json();
         
        
        setShopNames(json);
    };



    useEffect(() => {

        loadShops();
    }, []);

    return (
        <ShopIdContext.Provider value={{shopNames : shopNames}}>
            {children}
        </ShopIdContext.Provider>
    )
}