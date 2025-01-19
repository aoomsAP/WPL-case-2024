import { useContext, useEffect, useState } from "react";
import FormWizard from "react-form-wizard-component";
import { AiOutlineCheck } from "react-icons/ai";
import styles from "./NewShop.module.css"
import { UserContext } from "../../contexts/UserContext";
import { useNavigate } from "react-router-dom";
import { ICity, OptionType } from "../../types";
import { NewShopContext } from "../../contexts/NewShopContext";
import { createFilter } from "react-select";
import Select from "react-select";
import Option, { customTheme } from "../../components/ReactSelect/Option/Option";
import MenuList from "../../components/ReactSelect/MenuList/MenuListSingle";
import CustomLoader from "../../components/LoaderSpinner/CustomLoader";

export default function NewShop() {

    const { userId } = useContext(UserContext);
    const { addAddress, addContact, addShop, countries, loadCities } = useContext(NewShopContext);

    const navigate = useNavigate();

    const [name, setName] = useState<string>("");
    const [street, setStreet] = useState<string>("");
    const [streetNumber, setStreetNumber] = useState<number>(0);
    const [postbox, setPostbox] = useState<string>("");
    const [postalCode, setPostalCode] = useState<OptionType>();
    const [city, setCity] = useState<OptionType>();
    const [country, setCountry] = useState<OptionType>();

    const [countryOptions, setCountryOptions] = useState<OptionType[]>([]);
    const [cities, setCities] = useState<ICity[]>([]);
    const [cityOptions, setCityOptions] = useState<OptionType[]>([]);
    const [postalCodeOptions, setPostalCodeOptions] = useState<OptionType[]>([]);

    // Map countries to options for react-select
    useEffect(() => {
        let countryOptions: OptionType[] = countries
            .map((country) => ({
                value: country.id.toString(),
                label: country.name
            }));
        setCountryOptions(countryOptions);
    }, [countries])

    useEffect(() => {
        const handleBeforeUnload = (event: BeforeUnloadEvent) => {
        event.preventDefault();
        event.returnValue = "!"; // Noodzakelijk voor sommige browsers om de prompt te tonen
        };

        window.addEventListener("beforeunload", handleBeforeUnload);

        // Opruimen van de listener bij ontkoppeling van de component
        return () => {
        window.removeEventListener("beforeunload", handleBeforeUnload);
        };
    }, []);

    // Load & set cities
    async function setCitiesFunc(countryId: number) {
        const citiesByCountry = await loadCities(countryId);
        if (citiesByCountry) {
            setCities(citiesByCountry);
        }
    }

    // Load cities when country is selected
    useEffect(() => {
        if (country) {
            setCitiesFunc(+country.value);
        }
    }, [country]);

    // Map cities to options for react-select
    useEffect(() => {
        let cityOptions: OptionType[] = cities
            .map((city) => ({
                value: city.id.toString(),
                label: city.name
            }));
        setCityOptions(cityOptions);
    }, [cities]);

    // Map postal codes to options for react-select
    useEffect(() => {
        let postalCodeOptions: OptionType[] = cities
            .map((city) => ({
                value: city.postalCode,
                label: city.postalCode,
            }));
        setPostalCodeOptions(postalCodeOptions);
    }, [cities])

    async function handleComplete() {

        try {
            if (!userId) {
                throw Error("No valid user");
            }

            if (!city || !postalCode) {
                throw Error("No valid city selected");
            }

            const newAddress = {
                street1: `${street} ${streetNumber}${postbox ? ` / ${postbox}` : ""}`,
                cityId: +city.value,
                postalCode: postalCode.label,
                userCreatedId: userId,
                dateCreated: new Date(),
            }

            const addedAddress = await addAddress(newAddress);

            if (!addedAddress || !addedAddress?.id) {
                throw Error("Error while adding address");
            }

            const newContact = {
                name: name,
                userCreatedId: userId,
                dateCreated: new Date(),
                addressId: addedAddress.id,
            }

            const addedContact = await addContact(newContact);

            if (!addedContact || !addedContact?.id) {
                throw Error("Error while adding contact");
            }

            const newShop = {
                name: name.toUpperCase(), // All caps like in db?
                shopTypeId: 6, // Hardcoded, = "Prospect"
                userCreatedId: userId,
                dateCreated: new Date(),
                isParallelSales: false, // Hardcoded
                contactId: addedContact.id,
            }

            const addedShop = await addShop(newShop);

            if (!addedShop || !addedShop?.id) {
                throw Error("Error while adding shop");
            }

            navigate(`/shop/${addedShop.id}`)

        } catch (error) {
            console.error(error);
        }
    }

    return (
        <main>
            <FormWizard
                color="black"
                title="Nieuwe winkel"
                nextButtonText="Volgende"
                backButtonText="Vorige"
                finishButtonText="Verzenden"
                layout="horizontal"
                stepSize="sm"
                onComplete={handleComplete}>

                <FormWizard.TabContent
                    title={"Info"}
                    icon={<AiOutlineCheck color="lightgrey" />}>

                    <h3 className={styles.h3}>Winkel informatie</h3>

                    <fieldset>
                        <legend><strong>Naam</strong></legend>
                        <label htmlFor="name">Geef naam van de winkel:</label>
                        <input
                            type="text"
                            name="name"
                            value={name}
                            placeholder="Naam..."
                            onChange={(e) => setName(e.target.value)} />
                    </fieldset>

                    <fieldset className={styles.address}>
                        <legend><strong>Adres</strong></legend>

                        {/* Country select */}
                        <div style={{ marginBottom: "1rem" }}>
                            <label htmlFor="country">Selecteer het land:</label>
                            {countryOptions && <Select
                                theme={customTheme}
                                className="basic-single"
                                classNamePrefix="select"
                                defaultValue={country}
                                isDisabled={countryOptions.length > 0 ? false : true}
                                placeholder={countryOptions.length > 0 ? "Kies een land..." : <CustomLoader />}
                                isSearchable={true}
                                name="country"
                                options={countryOptions}
                                components={{ // Custom components to make use of react-window to improve rendering    
                                    Option,
                                    MenuList, // Custom menu list rendering
                                }}
                                maxMenuHeight={200} // Limit height to improve rendering
                                filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
                                onChange={(e) => {
                                    if (e) {
                                        setCountry(e);
                                    }
                                }}
                            />}
                        </div>

                        {/* Only show full address form when country is selected */}
                        {country && <>

                            {/* Street, street number & postbox/extra info */}
                            <div className={styles.streetContainer}>
                                <label className={styles.street}>
                                    Straat
                                    <input
                                        type="text"
                                        placeholder="Straat..."
                                        value={street}
                                        onChange={(e) => setStreet(e.target.value)} />
                                </label>
                                <div className={styles.numberContainer}>
                                    <label className={styles.number}>
                                        Nummer
                                        <input
                                            type="number"
                                            min={0}
                                            value={streetNumber}
                                            placeholder="0"
                                            onChange={(e) => setStreetNumber(+e.target.value)} />
                                    </label>
                                    <label className={styles.addition}>
                                        Toevoeging
                                        <input
                                            placeholder="Bus A..."
                                            type="text"
                                            value={postbox}
                                            onChange={(e) => setPostbox(e.target.value)} />
                                    </label>
                                </div>
                            </div>

                            {/* Postal code & city */}
                            <div className={styles.cityContainer}>

                                {/* PostalCode select */}
                                <div className={styles.postalCode}>
                                    <label htmlFor="postalCode">Postcode:</label>
                                    {countryOptions && <Select
                                        theme={customTheme}
                                        placeholder={postalCodeOptions.length > 0 ? "0000..." : <CustomLoader />}
                                        isDisabled={country ? false : true}
                                        className="basic-single"
                                        classNamePrefix="select"
                                        value={postalCode}
                                        isSearchable={true}
                                        name="postalCode"
                                        options={postalCodeOptions}
                                        components={{ // Custom components to make use of react-window to improve rendering    
                                            Option,
                                            MenuList, // Custom menu list rendering
                                        }}
                                        maxMenuHeight={200} // Limit height to improve rendering
                                        filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
                                        onChange={(e) => {
                                            if (e) {
                                                setPostalCode(e);
                                                // Find city based on selected postal code for autofill purposes
                                                const linkedCity = cities.find((city) => city.postalCode == e.value);
                                                if (linkedCity) {
                                                    setCity({ value: linkedCity.id.toString(), label: linkedCity.name });
                                                }
                                            }
                                        }}
                                    />}
                                </div>

                                {/* City select */}
                                <div className={styles.city}>
                                    <label htmlFor="city">Woonplaats:</label>
                                    {countryOptions && <Select
                                        theme={customTheme}
                                        placeholder={cityOptions.length > 0 ? "Kies een woonplaats..." : <CustomLoader />}
                                        isDisabled={country ? false : true}
                                        className="basic-single"
                                        classNamePrefix="select"
                                        value={city}
                                        isClearable={true}
                                        isSearchable={true}
                                        name="city"
                                        options={cityOptions}
                                        components={{ // Custom components to make use of react-window to improve rendering    
                                            Option,
                                            MenuList, // Custom menu list rendering
                                        }}
                                        maxMenuHeight={200} // Limit height to improve rendering
                                        filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
                                        onChange={(e) => {
                                            if (e) {
                                                setCity(e);
                                                // Find postal code based on selected city for autofill for autofill purposes
                                                const selectedCity = cities.find((city) => city.id.toString() == e.value);
                                                if (selectedCity) {
                                                    setPostalCode({ value: selectedCity.postalCode, label: selectedCity.postalCode });
                                                }
                                            }
                                        }}
                                    />}
                                </div>
                            </div>
                        </>}
                    </fieldset>

                </FormWizard.TabContent>

            </FormWizard >

        </main>
    )
}