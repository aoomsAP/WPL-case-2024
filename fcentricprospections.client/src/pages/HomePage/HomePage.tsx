import { useState, useEffect, useContext } from "react";
import { IShop, OptionType } from "../../types";
import { Link, useNavigate } from "react-router-dom";
import { UserContext } from "../../contexts/UserContext";
import { Oval } from "react-loader-spinner";
import Select from "react-select";
import { createFilter } from "react-select";
import MenuListSingle from "../../components/ToDoModule/MenuList/MenuListSingle";
import styles from './HomePage.module.css'
import Option from "../../components/ToDoModule/Option/Option";

export const Homepage = () => {


    const navigate = useNavigate();

    const { user, employee, appointments } = useContext(UserContext);

    const [shopNames, setShopNames] = useState<IShop[]>([]); //Sate with list of shops

    const [shopListOptions, setShopListOptions] = useState<OptionType[]>([]);

    useEffect(() => {
        const isValidShopOption = (shopOption: IShop) =>
            !!shopOption && !!shopOption.id && !!shopOption.name;

        let shopOptionOptions: OptionType[] = shopNames
            .filter(isValidShopOption)
            .map((shopOption) => ({
                value: shopOption.id.toString(),
                label: `${shopOption.name}`

            }));
        setShopListOptions(shopOptionOptions);
    }, [shopNames])


    const loadShops = async () => {
        try {
            console.log("start loading shops")
            const response = await fetch('/api/shops', {
                method: 'GET',  // Specify the method if it's not 'GET' by default
                headers: {
                    'Content-Type': 'application/json',  // Define the expected content type                   
                },
            });
            const json: IShop[] = await response.json();
            console.log("shops loaded", json)
            console.log("amount of shops", json.length)
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
                <h1>Hallo, {employee ? employee?.firstName : user?.login}</h1>
            </div>

            {/* SELECTEER WINKEL */}
            <h2>Selecteer een winkel</h2>

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

            {/* NIEUWE WINKEL */}
            <button className={styles.button}>
                <Link className={styles.a} to={`/newshop`}>
                    Maak een nieuwe winkel aan
                </Link>
            </button>

        </main>
    );
};
