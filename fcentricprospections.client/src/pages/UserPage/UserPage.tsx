import { useContext, useState } from "react";
import { UserContext } from "../../contexts/UserContext";
import { Link } from "react-router-dom";
import homeStyles from '../Home/HomePage.module.css'
import styles from '../../App.module.css'


const UserPage = () =>{

    
  const {setUserId , userList } = useContext(UserContext);

  const [searchTerm, setSearchTerm] = useState(""); // State for search input

  // Filter user names based on the search term, ensuring at least 3 characters are typed
  const filteredUSerNames = userList.filter(user => {
    // Check if the search term is at least 3 characters long
    if (searchTerm.length < 3) return false; // If less than 3 characters, do not include
    return user.login.toLowerCase().includes(searchTerm.toLowerCase()); // Otherwise, filter based on name
});



    return(
        <main className={styles.main}>
        <h1>Selecteer een Gebruiker</h1>

    <input 
            className={styles.inputField} 
            type="text" 
            placeholder="Zoek..." 
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)} // Update state on input change
    />

        <ul className={homeStyles.ul}>
            {filteredUSerNames.length > 0 ? (
                filteredUSerNames.map(user => (
                    <li className={homeStyles.li}  key={user.id}>  {/* Ensure each `li` has a unique `key` */}
                    <Link className={homeStyles.a} to={`/home`} onClick={()=>setUserId(user.id)}>{user.login}</Link>
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
);}

export default UserPage;