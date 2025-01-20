import { useContext, useEffect, useRef, useState } from "react";
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
import { ShopListContext } from "../../contexts/ShopListContext";

export default function NewShop() {

    const { userId } = useContext(UserContext);
    const { loadShops } = useContext(ShopListContext);

    const { addAddress, addContact, addShop, countries, loadCities } = useContext(NewShopContext);

    const navigate = useNavigate();

    const [name, setName] = useState<string>("");
    const [street, setStreet] = useState<string>("");
    const [streetNumber, setStreetNumber] = useState<number>(0);
    const [postbox, setPostbox] = useState<string>("");

    const [country, setCountry] = useState<OptionType>();
    const [countryOptions, setCountryOptions] = useState<OptionType[]>([]);

    const [city, setCity] = useState<OptionType>();
    const [cities, setCities] = useState<ICity[]>([]);
    const [cityLoading, setCityLoading] = useState<boolean>(false);
    const [cityOptions, setCityOptions] = useState<OptionType[]>([]);

    const [postalCode, setPostalCode] = useState<OptionType>();
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

    // Load & set cities
    async function setCitiesFunc(countryId: number) {
        setCityLoading(true);
        const citiesByCountry = await loadCities(countryId);
        if (citiesByCountry) {
            setCities(citiesByCountry);
        }
        setCityLoading(false);
    }

    // Load cities when country is selected
    useEffect(() => {
        if (country) {
            setCity(undefined);
            setErrorMessage(undefined);
            setPostalCode(undefined);
            setCitiesFunc(+country.value);
        }
    }, [country]);

    // Map cities to options for react-select
    useEffect(() => {
        let cityOptions: OptionType[] = cities
            .map((city) => ({
                value: city.id.toString(),
                label: city.name
            }))
            .sort((a, b) => {
                if (a.label < b.label) return -1;
                if (a.label > b.label) return 1;
                return 0;
            });
        setCityOptions(cityOptions);
    }, [cities]);

    // Map postal codes to options for react-select
    useEffect(() => {
        let postalCodeOptions: OptionType[] = cities
            .map((city) => ({
                value: city.postalCode,
                label: city.postalCode,
            }))
        setPostalCodeOptions(postalCodeOptions);
    }, [cities])

    // Submit function ------------------------------------------------------------------------------------------------------------------------------------

    const [loading, setLoading] = useState<boolean>(false);
    const [isButtonDisabled, setIsButtonDisabled] = useState(false);
    const [errorMessage, setErrorMessage] = useState<string>();
    const errorRef = useRef<HTMLDivElement | null>(null);

    async function handleComplete() {

        try {
            setLoading(true);
            setIsButtonDisabled(true);

            if (!userId) {
                throw Error("Geen geldige gebruiker. Probeer opnieuw in te loggen.");
            }

            if (!name || name.trim().length < 1) {
                throw Error("Geen geldige naam.");
            }

            if (!country) {
                throw Error("Geen geldig land geselecteerd.");
            }

            if (!city) {
                throw Error("Geen geldige stad geselecteerd.");
            }

            const newAddress = {
                street1: (`${street ?? ""}${(streetNumber != 0) ? ` ${streetNumber}` : ""}${postbox ? ` / ${postbox}` : ""}`).toUpperCase(), // All caps like in db?
                cityId: +city.value,
                postalCode: postalCode?.label ?? undefined,
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

            // Reload shops with newly added shop
            await loadShops();

            navigate(`/shop/${addedShop.id}`)

        } catch (error) {
            console.error(error);
            let message = "Er ging iets mis. Probeer het later opnieuw."
            if (error instanceof Error) {
                message = error.message;
                if (error.message.includes("Geen")) message = error.message
            }
            setErrorMessage(message);
            setTimeout(() => {
                errorRef.current?.scrollIntoView({ behavior: "smooth", block: "center" });
            }, 0);

        } finally {
            setLoading(false);
            setIsButtonDisabled(false);
        }
    }

    return (
        <main>
            <FormWizard
                color="black"
                title="Nieuwe winkel"
                nextButtonText="Volgende"
                backButtonText="Vorige"
                finishButtonTemplate={(handleComplete) => (
                    <button
                        className="wizard-footer-right"
                        onClick={handleComplete}
                        disabled={isButtonDisabled}
                    >
                        <div className={styles.loading}>
                            {loading ? <span>Verzenden...</span> : <span>Verzenden</span>} {/* Show "Verzenden" when not loading */}
                            {loading && <CustomLoader />} {/* Show spinner if loading */}
                        </div>
                    </button>
                )}
                layout="horizontal"
                stepSize="sm"
                onComplete={handleComplete}>

                <FormWizard.TabContent
                    title={"Info"}
                    icon={<AiOutlineCheck color="lightgrey" />}>

                    <h3 className={styles.h3}>Winkel informatie</h3>

                    <fieldset className={(errorMessage && (!name || name.trim() === "")) ? styles.errorBorder : ""}>
                        <legend>
                            <strong>Naam</strong>
                        </legend>
                        <label htmlFor="name">
                            Geef naam van de winkel:&nbsp;
                            <span className={styles.required}> *</span>
                        </label>
                        <input
                            type="text"
                            name="name"
                            value={name}
                            placeholder="Naam..."
                            onChange={(e) => setName(e.target.value)} />
                    </fieldset>

                    <fieldset className={`${styles.address} ${(errorMessage && !city) ? styles.errorBorder : ""}`}>
                        <legend><strong>Adres</strong></legend>

                        {/* Country select */}
                        <div>
                            <label htmlFor="country">
                                Selecteer het land:&nbsp;
                                <span className={styles.required}> *</span>
                            </label>
                            {countryOptions && <Select
                                theme={customTheme}
                                className={`basic-single`}
                                classNamePrefix="select"
                                value={country}
                                isDisabled={countryOptions.length > 0 ? false : true}
                                placeholder={countryOptions.length > 0 ? "Kies een land..." : <div className={styles.loading}>Landen laden... <CustomLoader /></div>}
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

                        {cityLoading && <div className={styles.container}>
                            <CustomLoader />
                        </div>}

                        {/* Only show full address form when country is selected AND country has valid cities to add address */}
                        {country && (!cityLoading && cityOptions.length > 0) && <>

                            {/* Street, street number & postbox/extra info */}
                            <div className={styles.streetContainer}>
                                <label className={styles.street}>
                                    Straat:
                                    <input
                                        type="text"
                                        placeholder="Straat..."
                                        value={street}
                                        onChange={(e) => setStreet(e.target.value)} />
                                </label>
                                <div className={styles.numberContainer}>
                                    <label className={styles.number}>
                                        Nummer:
                                        <input
                                            type="number"
                                            min={1}
                                            value={streetNumber}
                                            placeholder="1"
                                            onChange={(e) => setStreetNumber(+e.target.value)} />
                                    </label>
                                    <label className={styles.addition}>
                                        Toevoeging:
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
                                    <label htmlFor="city">Woonplaats:&nbsp;
                                        <span className={styles.required}> *</span></label>
                                    {countryOptions && <Select
                                        theme={customTheme}
                                        placeholder={cityOptions.length > 0 ? "Kies een woonplaats..." : <CustomLoader />}
                                        isDisabled={country ? false : true}
                                        className={`basic-single`}
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

                        {/* If cities have loaded and there are none, it's not possible to add an address to db without adding a city */}
                        {/* Check with db admin to request permission to add cities & postal codes */}
                        {(country && !cityLoading && cityOptions.length === 0) &&
                            <p>Het is momenteel niet mogelijk om een winkel toe te voegen voor dit land. Contacteer IT.</p>}
                    </fieldset>

                </FormWizard.TabContent>

            </FormWizard >

            {errorMessage && (!name || !city || !country) &&
                <div
                    ref={errorRef}
                    className={styles.error}
                >
                    <p>{errorMessage}</p>
                    <button
                        className={styles.close}
                        onClick={() => setErrorMessage(undefined)} >
                        X
                    </button>
                </div>}
        </main>
    )
}