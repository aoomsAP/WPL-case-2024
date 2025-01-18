import React, { useState, useEffect } from "react"
import { IAddressCreate, ICity, IContactCreate, ICountry, IShopCreate } from "../types";

interface NewShopContext {
    countries: ICountry[],
    loadCities: (countryId: number) => Promise<ICity[] | undefined>,
    addAddress: (newAddress: IAddressCreate) => Promise<IAddressCreate | undefined>,
    addContact: (newContact: IContactCreate) => Promise<IContactCreate | undefined>,
    addShop: (newShop: IShopCreate) => Promise<IShopCreate | undefined>,
}

export const NewShopContext = React.createContext<NewShopContext>({
    countries: [],
    loadCities: () => Promise.resolve([]),
    addAddress: () => Promise.resolve(undefined),
    addContact: () => Promise.resolve(undefined),
    addShop: () => Promise.resolve(undefined),
});

export const NewShopProvider = ({ children }: { children: React.ReactNode }) => {

    const [countries, setCountries] = useState<ICountry[]>([]);

    // GET DATA

    async function loadCountries() {
        try {
            const response = await fetch(`/api/countries`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: ICountry[] = await response.json();
            setCountries(json);

        } catch (error) {
            console.error('Error fetching countries data:', error);
        }
    }

    async function loadCities(countryId: number) {
        try {
            const response = await fetch(`/api/countries/${countryId}/cities`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: ICity[] = await response.json();
            return json;

        } catch (error) {
            console.error('Error fetching cities data:', error);
        }
    }

    // POST DATA
    // (error handling done on top level)

    async function addAddress(newAddress: IAddressCreate) {
        const response = await fetch(`/api/addresses`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newAddress),
        });

        const json: IAddressCreate = await response.json();

        console.log("Succesful POST new address: ", json)
        return (json);
    }

    async function addContact(newContact: IContactCreate) {
        const response = await fetch(`/api/contacts`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newContact),
        });

        const json: IContactCreate = await response.json();

        console.log("Succesful POST new contact: ", json)
        return (json);
    }

    async function addShop(newShop: IShopCreate) {
        const response = await fetch(`/api/shops`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newShop),
        });

        const json: IShopCreate = await response.json();

        console.log("Succesful POST new shop: ", json)
        return (json);
    }

    useEffect(() => {
        loadCountries();
    }, []);

    return (
        <NewShopContext.Provider value={{
            countries: countries,
            loadCities: loadCities,
            addAddress: addAddress,
            addContact: addContact,
            addShop: addShop
        }}>
            {children}
        </NewShopContext.Provider>
    )
}