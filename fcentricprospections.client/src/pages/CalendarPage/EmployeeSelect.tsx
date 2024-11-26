import { useContext, useEffect, useState } from "react";
import { UserContext } from "../../contexts/UserContext";
import styles from '../../App.module.css'
import homeStyles from '../HomePage/HomePage.module.css'
import { IAppointment } from "../../types";



 export const EmployeeSelect = () =>{

    const { employeeList , loadEmployeeList, loadAppointmentShown, appointments,setShownAppointments} = useContext(UserContext);
    const [searchTerm, setSearchTerm] = useState(""); // State for search input

    // Filter user names based on the search term, ensuring at least 3 characters are typed
    const filteredEmployeeNames = employeeList.filter(employee => {
        // Check if the search term is at least 3 characters long
        if (searchTerm.length < 3) return false; // If less than 3 characters, do not include
        return employee.name.toLowerCase().includes(searchTerm.toLowerCase()); // Otherwise, filter based on name
    });

     async function AddCalendar (employeeId : string ) {

        const newAppointments : IAppointment[] = await loadAppointmentShown(employeeId);

        setShownAppointments([...appointments,...newAppointments])

     };

   useEffect(()=>{
    
    loadEmployeeList();

   },[]);

    return(
        <>
        <input
                className={styles.inputField}
                type="text"
                placeholder="Zoek..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)} // Update state on input change
            />
             <ul className={homeStyles.ul}>
                {filteredEmployeeNames.length > 0 ? (
                    filteredEmployeeNames.map(employee => (
                        <li className={homeStyles.li} key={employee.id} onClick={()=>AddCalendar(employee.id)}>  {/* Ensure each `li` has a unique `key` */}
                            {employee.name}
                        </li>
                    ))
                ) : (
                    searchTerm.length < 3 ? (
                        <li className={homeStyles.li1}>Typ minstens 3 letters.</li> // Instruction message if less than 3 characters
                    ) : (
                        <li>Geen employees gevonden</li> // Message if no shops match
                    )
                )}
            </ul>
        
        </>
    );
}