import { useContext, useState } from "react";
import FormWizard from "react-form-wizard-component";
import { AiOutlineCheck } from "react-icons/ai";
import styles from "./NewShop.module.css"
import { UserContext } from "../../contexts/UserContext";
import { useNavigate } from "react-router-dom";
import { IAddressCreate, IContactCreate, IShopCreate } from "../../types";

export default function NewShop() {

    const { userId } = useContext(UserContext);

    const navigate = useNavigate();

    const [name, setName] = useState<string>("");
    const [street, setStreet] = useState<string>("");
    const [postalCode, setPostalCode] = useState<string>("");
    const [streetNumber, setStreetNumber] = useState<number>(0);
    const [postbox, setPostbox] = useState<string>("");
    const [cityId, setCityId] = useState<number>(0);
    const [country, setCountry] = useState<string>("");

    // TO DO: put in context?
    async function addAddress(newAddress: IAddressCreate) {
        try {
            const response = await fetch(`/api/addresses`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(newAddress),
            });

            const json: IAddressCreate = await response.json();

            console.log("Succesful POST new address: ", json)
            return (json);

        } catch (error) {
            console.error('Error POST new address:', error);
        }
    }

    async function addContact(newContact: IContactCreate) {
        try {
            const response = await fetch(`/api/contacts`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(newContact),
            });

            const json: IContactCreate = await response.json();

            console.log("Succesful POST new contact: ", json)
            return (json);

        } catch (error) {
            console.error('Error POST new contact:', error);
        }
    }

    async function addShop(newShop: IShopCreate) {
        try {
            const response = await fetch(`/api/shops`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(newShop),
            });

            const json: IShopCreate = await response.json();

            console.log("Succesful POST new shop: ", json)
            return (json);

        } catch (error) {
            console.error('Error POST new shop:', error);
        }
    }

    async function handleComplete() {

        try {
            const newAddress = {
                street1: `${street} ${streetNumber}`,
                cityId: cityId,
                postalCode: postalCode,
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
                            {/* TO DO: SELECT */}
                            <label>
                                Land:
                                <input type="text" value={country} onChange={(e) => setCountry(e.target.value)} />
                            </label>
                        </div>
                        <div style={{ display: "flex", flexDirection: "row" }}>
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
                        <div style={{ display: "flex", flexDirection: "row" }}>
                            <label style={{ flexBasis: "25%" }}>
                                Postcode
                                <input type="text" value={postalCode} onChange={(e) => setPostalCode(e.target.value)} />
                            </label>
                            {/* TO DO: REPLACE WITH SELECT */}
                            <label style={{ flexBasis: "75%" }}>
                                Woonplaats
                                <input type="text" value={city} onChange={(e) => setCity(e.target.value)} />
                            </label>
                        </div>

                    </fieldset>

                </FormWizard.TabContent>

            </FormWizard>

        </>
    )
}