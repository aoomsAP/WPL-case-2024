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
import Option from "../../components/ToDoModule/Option/Option";
import MenuList from "../../components/ToDoModule/MenuList/MenuListSingle";

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
                name: name,
                shopTypeId: 6, // = Prospect
                userCreatedId: userId.toString(),
                dateCreated: new Date(),
                isParallelSales: false,
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
        <>
            <FormWizard
                title="Nieuwe winkel"
                nextButtonText="Volgende"
                backButtonText="Vorige"
                finishButtonText="Verzenden"
                layout="horizontal"
                stepSize="sm"
                onComplete={handleComplete}>

                <FormWizard.TabContent title="Info" icon={<AiOutlineCheck />} >

                    <h3>Winkel informatie</h3>

                    <fieldset>
                        <legend>Naam</legend>
                        <input type="text" value={name} onChange={(e) => setName(e.target.value)} />
                    </fieldset>

                    <fieldset className={styles.address}>
                        <legend>Adres</legend>
                        <div>
                            {/* Countries select */}
                            <label htmlFor="country">Selecteer het land:</label>
                            {countryOptions && <Select
                                className="basic-single"
                                classNamePrefix="select"
                                defaultValue={country}
                                placeholder={"Kies een land"}
                                isClearable={true}
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
                        <div style={{ display: "flex", flexDirection: "row", margin: "1rem 0" }}>
                            <label style={{ flexBasis: "50%" }}>
                                Straat
                                <input type="text" value={street} onChange={(e) => setStreet(e.target.value)} />
                            </label>
                            <label style={{ flexBasis: "25%" }}>
                                Nummer
                                <input type="number" value={streetNumber} onChange={(e) => setStreetNumber(+e.target.value)} />
                            </label>
                            <label style={{ flexBasis: "25%" }}>
                                Toevoeging
                                <input type="text" value={postbox} onChange={(e) => setPostbox(e.target.value)} />
                            </label>
                        </div>
                        <div style={{ display: "flex", flexDirection: "row", margin: "1rem 0" }}>
                            {/* PostalCode select */}
                            <div style={{ flexBasis: "25%" }}>
                                <label htmlFor="postalCode">Postcode:</label>
                                {countryOptions && <Select
                                    isDisabled={country ? false : true}
                                    className="basic-single"
                                    classNamePrefix="select"
                                    // if city is already selected, find matching postalCode
                                    value={postalCode}
                                    placeholder={"0000"}
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
                                            const linkedCity = cities.find((city) => city.postalCode == e.value);
                                            if (linkedCity) {
                                                setCity({ value: linkedCity.id.toString(), label: linkedCity.name });
                                            }
                                        }
                                    }}
                                />}
                            </div>
                            {/* City select */}
                            <div style={{ flexBasis: "75%" }}>
                                <label htmlFor="city">Woonplaats:</label>
                                {countryOptions && <Select
                                    isDisabled={country ? false : true}
                                    className="basic-single"
                                    classNamePrefix="select"
                                    // if postalCode is already selected, find matching city
                                    value={city}
                                    placeholder={"Kies een woonplaats"}
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
                                            const selectedCity = cities.find((city) => city.id.toString() == e.value);
                                            if (selectedCity) {
                                                setPostalCode({ value: selectedCity.postalCode, label: selectedCity.postalCode });
                                            }
                                        }
                                    }}
                                />}
                            </div>

                        </div>

                    </fieldset>

                </FormWizard.TabContent>

            </FormWizard >

        </>
    )
}