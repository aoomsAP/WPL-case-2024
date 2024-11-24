import { useState, useEffect, useContext } from "react";
import { IShop } from "../../types";
import { Link } from "react-router-dom";
import styles from '../../App.module.css'
import homeStyles from './homepage.module.css'
import { UserContext } from "../../contexts/UserContext";
import { Oval } from "react-loader-spinner";

export const Homepage = () => {

    const { user, employee, appointments } = useContext(UserContext);

    const [searchTerm, setSearchTerm] = useState(""); // State for search input
    const [shopNames, setShopNames] = useState<IShop[]>([]); //Sate with list of shops

    // Filter shop names based on the search term, ensuring at least 3 characters are typed
    const filteredShopNames = shopNames.filter(shop => {
        // Check if the search term is at least 3 characters long
        if (searchTerm.length < 3) return false; // If less than 3 characters, do not include
        return shop.name.toLowerCase().includes(searchTerm.toLowerCase()); // Otherwise, filter based on name
    });

    const loadShops = async () => {
        try {
            const response = await fetch('/api/shops', {
                method: 'GET',  // Specify the method if it's not 'GET' by default
                headers: {
                    'Content-Type': 'application/json',  // Define the expected content type                   
                },
            });
            console.log(response)
            const json: IShop[] = await response.json();
            setShopNames(json);
        }
        catch (error) {
            console.log(error)
        }
    };

    useEffect(() => {
        loadShops();
    }, []);

    return (
        <main className={styles.main}>
            <div>
                {/* FOR TESTING PURPOSES */}
                <h2>Hallo, {employee ? employee?.firstName : user?.login}</h2>
                {employee
                    // IF EMPLOYEE EXISTS, SHOW 5 APPOINTMENTS:
                    ? <>
                        <p>Enkele appointments:</p>
                        {/* IF APPOINTMENTS ARE LOADED */}
                        {appointments.length > 1
                            ? <ul>
                                {appointments.slice(0, 5).map((app, i) =>
                                    <li key={i}>
                                        {app.name}
                                    </li>
                                )}
                            </ul>
                            // IF APPOINTMENTS ARE STILL LOADING
                            : <Oval />
                        }
                    </>
                    // IF NO EMPLOYEE FOUND
                    : <p>"Geen employee geassocieerd met deze User"</p>
                }
            </div>

            <h1>Selecteer een winkel</h1>

            <input
                className={styles.inputField}
                type="text"
                placeholder="Zoek..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)} // Update state on input change
            />
            <ul className={homeStyles.ul}>
                {filteredShopNames.length > 0 ? (
                    filteredShopNames.map(shop => (
                        <li className={homeStyles.li} key={shop.id}>  {/* Ensure each `li` has a unique `key` */}
                            <Link className={homeStyles.a} to={`/shop/${shop.id}`}>{shop.name}</Link>
                        </li>
                    ))
                ) : (
                    searchTerm.length < 3 ? (
                        <li className={homeStyles.li1}>Typ minstens 3 letters.</li> // Instruction message if less than 3 characters
                    ) : (
                        <li>Geen winkels gevonden</li> // Message if no shops match
                    )
                )}
            </ul>
        </main>
    );
};