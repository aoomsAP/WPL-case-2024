import { useContext, useState } from "react";
import { ShopIdContext } from "../../contexts/dataContext"; // Make sure the path is correct
import styles from '../../App.module.css'; // Adjust your styles as necessary
import { Link } from "react-router-dom";

export const Homepage = () => {
    const { shopNames } = useContext(ShopIdContext); // Get shop names from context
    const [searchTerm, setSearchTerm] = useState(""); // State for search input

    // Filter shop names based on the search term, ensuring at least 3 characters are typed
    const filteredShopNames = shopNames.filter(shop => {
        // Check if the search term is at least 3 characters long
        if (searchTerm.length < 3) return false; // If less than 3 characters, do not include
        return shop.name.toLowerCase().includes(searchTerm.toLowerCase()); // Otherwise, filter based on name
    });

    return (
            <main className={styles.main}>
            <input 
                    className={styles.inputField} 
                    type="text" 
                    placeholder="Zoek..." 
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)} // Update state on input change
                />
                <ul>
                    {filteredShopNames.length > 0 ? (
                        filteredShopNames.map(shop => (
                            <li key={shop.id}>  {/* Ensure each `li` has a unique `key` */}
                            <Link to={`/shop/${shop.id}`}>{shop.name}</Link>
                        </li>
                        ))
                    ) : (
                        searchTerm.length < 3 ? (
                            <li>Typ minstens 3 letters.</li> // Instruction message if less than 3 characters
                        ) : (
                            <li>Geen winkels gevonden</li> // Message if no shops match
                        )
                    )}
                </ul>
            </main>      
    );
};
