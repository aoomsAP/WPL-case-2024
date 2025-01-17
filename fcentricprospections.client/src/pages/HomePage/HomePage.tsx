import { useState, useEffect, useContext } from "react";
import { IShop, OptionType } from "../../types";
import { useNavigate } from "react-router-dom";
import { UserContext } from "../../contexts/UserContext";
import Select from "react-select";
import { createFilter } from "react-select";
import styles from './HomePage.module.css'
import Option, { customTheme } from "../../components/ReactSelect/Option/Option";
import MenuList from "../../components/ReactSelect/MenuList/MenuListSingle";
import { TfiPlus } from "react-icons/tfi";
import CustomLoader from "../../components/LoaderSpinner/CustomLoader";
import { ShopListContext } from "../../contexts/ShopListContext";

export const Homepage = () => {

    const navigate = useNavigate();

    const { user, employee, userDataLoading } = useContext(UserContext);
    const { shops } = useContext(ShopListContext);

    const [shopListOptions, setShopListOptions] = useState<OptionType[]>([]);
    const isDataLoaded = employee && user && !userDataLoading;

    useEffect(() => {
        const isValidShopOption = (shopOption: IShop) =>
            !!shopOption && !!shopOption.id && !!shopOption.name;

        let shopOptionOptions: OptionType[] = shops
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
    }, [shops])

    if (isDataLoaded) return (
        <main>
            <section>
                <h2>Hallo, {employee ? employee?.firstName : user?.login}</h2>
            </section>

            {/* SELECTEER WINKEL */}
            <section>
                <h1>Selecteer een winkel</h1>

                <p>Zoek een winkel in de lijst om naar de detailpagina te navigeren.</p>

                <Select<OptionType>
                    className="basic-single"
                    classNamePrefix="select"
                    theme={customTheme}
                    isClearable={true}
                    isSearchable={true}
                    name="shopSelect"
                    isDisabled={shopListOptions.length > 0 ? false : true}
                    placeholder={shopListOptions.length > 0 ? "Selecteer..." : <CustomLoader />}
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
                />
            </section>

            <section>
                <p>Winkel niet gevonden?</p>

                {/* NIEUWE WINKEL */}
                <button
                    title="Nieuwe winkel"
                    className={styles.add_button}
                    onClick={() => navigate(`/newshop`)}>
                    Maak een nieuwe winkel aan
                    <TfiPlus className={styles.add_button__icon} />
                </button>
            </section>
        </main>
    );

    // if the employee or the user is not found or the user/employee data is still loading, only a loading indicator is shown
    if (!isDataLoaded) return <CustomLoader />
};
