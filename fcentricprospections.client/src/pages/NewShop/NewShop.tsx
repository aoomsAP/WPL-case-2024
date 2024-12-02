import { useContext, useState } from "react";
import FormWizard from "react-form-wizard-component";
import { AiOutlineCheck } from "react-icons/ai";
import styles from "./NewShop.module.css"
import { NewProspectionContext } from "../../contexts/NewProspectionContext";

export default function NewShop() {

    // const { toDos, setToDos } = useContext(NewProspectionContext);

    const [name, setName] = useState<string>("");
    const [street, setStreet] = useState<string>("");
    const [postalCode, setPostalCode] = useState<string>("");
    const [streetNumber, setStreetNumber] = useState<number>(0);
    const [postbox, setPostbox] = useState<string>("");
    const [city, setCity] = useState<string>("");
    const [country, setCountry] = useState<string>("");

    function newShopInTodos() {
        // TO DO: implement
    }

    async function handleComplete() {

        // TO DO:
        // const newShop = { shopName : name, shopType: 6 (== Prospect) }
        // const loadedShop = await addShop(newShop)
        // newShopInTodos({ shopId: id, shopName: name, address: addressinfo })
        // navigate(`/shop/${loadedShop.id}`)

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