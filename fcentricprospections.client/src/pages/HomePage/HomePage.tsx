import { useState, useEffect, useContext } from "react";
import { IShop, OptionType } from "../../types";
import { useNavigate } from "react-router-dom";
import { UserContext } from "../../contexts/UserContext";
import Select from "react-select";
import { createFilter } from "react-select";
import styles from './HomePage.module.css'
import Option, { customTheme } from "../../components/ReactSelect/Option/Option";
import MenuList from "../../components/ReactSelect/MenuList/MenuListSingle";
import { TfiPlus, TfiAlert } from "react-icons/tfi";
import CustomLoader from "../../components/LoaderSpinner/CustomLoader";
import { ShopListContext } from "../../contexts/ShopListContext";
import { GoPerson } from "react-icons/go";

export const Homepage = () => {

    const navigate = useNavigate();

    const { user, employee, userDataLoading } = useContext(UserContext);
    const { shops } = useContext(ShopListContext);

    const [shopListOptions, setShopListOptions] = useState<OptionType[]>([]);
    const isDataLoaded = !userDataLoading;

    // Map list of shops to shop options for react-select
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

    return (
        <main>
            <section>
                {/* User greeting (if user has finished loading) */}
                {isDataLoaded && (user
                
                        // Employee name or user name (if user is found)
                        ? <div className={styles.logged_in}>
                            <GoPerson />
                            <h2>Hallo, {employee ? employee?.firstName : user?.login}</h2>
                        </div>

                        // Error (if user is not found)
                        : <div className={styles.not_logged_in}>
                            <TfiAlert />
                            <p>Gebruiker niet gevonden. Probeer opnieuw aan te melden.</p>
                        </div>
                )}
                {/* Loading indicator (if user is still loading) */}
                {!isDataLoaded && <CustomLoader />}
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
                    onClick={() => navigate(`/shop/new`)}>
                    Maak een nieuwe winkel aan
                    <TfiPlus className={styles.add_button__icon} />
                </button>
            </section>
        </main >
    );
};
