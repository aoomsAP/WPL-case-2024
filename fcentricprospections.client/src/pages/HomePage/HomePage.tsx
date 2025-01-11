import { useState, useEffect, useContext } from "react";
import { IShop, OptionType } from "../../types";
import { Link, useNavigate } from "react-router-dom";
import { UserContext } from "../../contexts/UserContext";
import Select from "react-select";
import { createFilter } from "react-select";
import styles from './HomePage.module.css'
import Option from "../../components/ToDoModule/Option/Option";
import MenuList from "../../components/ToDoModule/MenuList/MenuListSingle";

export const Homepage = () => {

    const navigate = useNavigate();

    const { user, employee } = useContext(UserContext);

    const [shopNames, setShopNames] = useState<IShop[]>([]); //Sate with list of shops
    const [shopListOptions, setShopListOptions] = useState<OptionType[]>([]);

    useEffect(() => {
        const isValidShopOption = (shopOption: IShop) =>
            !!shopOption && !!shopOption.id && !!shopOption.name;

        let shopOptionOptions: OptionType[] = shopNames
            .filter(isValidShopOption)
            .map((shopOption) => {
                if (shopOption.name.includes(shopOption.city)) {
                    return ({
                        value: shopOption.id.toString(),

                        label: `${shopOption.name}`
                    })
                }
                return ({
                    value: shopOption.id.toString(),

                    label: `${shopOption.name} - ${shopOption.city}`

                })
            });
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
        <main>
            <h2>Hallo, {employee ? employee?.firstName : user?.login}</h2>

            {/* SELECTEER WINKEL */}
            <h1>Selecteer een winkel</h1>

            {shopNames && <Select<OptionType>
                className="basic-single"
                classNamePrefix="select"
                isClearable={true}
                isSearchable={true}
                name="shopSelect"
                placeholder={"Selecteer..."}
                filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
                maxMenuHeight={200} // Limit height to improve rendering
                options={shopListOptions}
                components={{ // Custom components to make use of react-window to improve rendering    
                    Option,
                    MenuList, // Custom menu list rendering
                }}
                onChange={(e) => {
                    if (e?.value != undefined) {
                        navigate(`/shop/${e?.value}`);
                    }
                }}
            />}

            <div className={styles.newShop}>
                <p>Winkel niet gevonden?</p>

                {/* NIEUWE WINKEL */}
                <Link className={styles.a} to={`/newshop`}>
                    <button className={styles.button}>
                        Maak een nieuwe winkel aan
                    </button>
                </Link>
            </div>

        </main>
    );
};
