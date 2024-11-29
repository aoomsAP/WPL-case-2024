import { useState, useEffect, useContext } from "react";
import { IShop, OptionType } from "../../types";
import { useNavigate } from "react-router-dom";
import { UserContext } from "../../contexts/UserContext";
import { Oval } from "react-loader-spinner";
import Select from "react-select";
import { createFilter} from "react-select";
import MenuListSingle from "../../components/ToDoModule/MenuList/MenuListSingle";
import styles from './HomePage.module.css'
import Option from "../../components/ToDoModule/Option/Option";

export const Homepage = () => {

    
    const navigate = useNavigate();

    const { user, employee, appointments } = useContext(UserContext);

    const [searchTerm, setSearchTerm] = useState(""); // State for search input
    const [shopNames, setShopNames] = useState<IShop[]>([]); //Sate with list of shops

    const[shopListOptions , setShopListOptions] = useState<OptionType[]>([]);

    useEffect(() => {
        const isValidShopOption = (shopOption: IShop) =>
          !!shopOption && !!shopOption.id && !!shopOption.name;
    
        let shopOptionOptions: OptionType[] = shopNames
          .filter(isValidShopOption )
          .map((shopOption) => ({
            value: shopOption.id.toString(),
            label: `${shopOption.name} ${shopOption.city}`

          }));
        setShopListOptions(shopOptionOptions);
      }, [shopNames])
    

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
        <main className={`${styles.main} ${styles.homepage}`}>
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

            
            {shopNames && <Select<OptionType>
            className="basic-single"
            classNamePrefix="select"
            isClearable={true}
            isSearchable={true}
            name="shopSelect"
            filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
            maxMenuHeight={200} // Limit height to improve rendering
            options={shopListOptions}
            components={{ // Custom components to make use of react-window to improve rendering
                
                Option,
              }}

            onChange={(e) => {
                navigate(`/shop/${e?.value}`);
            }}
            
          />}



           


        </main>
    );
};
