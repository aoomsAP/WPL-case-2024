import { useContext, useEffect, useState } from "react";
import { UserContext } from "../../contexts/UserContext";
import { useNavigate } from "react-router-dom";
import styles from '../HomePage/HomePage.module.css'
import { IUser, OptionType } from "../../types";
import Select from "react-select";
import { createFilter } from "react-select";

const UserPage = () => {

    const { setUserId, users } = useContext(UserContext);
    const navigate = useNavigate();

    const[userOptions , setUserOptions] = useState<OptionType[]>([]);

    useEffect(() => {
        const isValidUserOption = (userOption: IUser) =>
          !!userOption && !!userOption.id && !!userOption.login;
    
        let userOptions: OptionType[] = users
          .filter(isValidUserOption )
          .map((userOption) => ({
            value: userOption.id.toString(),
            label: `${userOption.login} `

          }));
        setUserOptions(userOptions)
      }, [users])
    

    return (
        <main className={styles.main}>
            <h1>Selecteer een Gebruiker</h1>

            {users && <Select<OptionType>
            className="basic-single"
            classNamePrefix="select"
            isClearable={true}
            isSearchable={true}
            name="shopSelect"
            filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
            maxMenuHeight={200} // Limit height to improve rendering
            options={userOptions}
            onChange={(e) => {
                if (e?.value){

                    setUserId(e.value)
                    navigate(`/home`);
                }
               
            }}/>}

            
            
        </main>
    );
}

export default UserPage;