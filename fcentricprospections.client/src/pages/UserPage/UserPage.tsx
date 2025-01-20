import { useContext, useEffect, useState } from "react";
import { UserContext } from "../../contexts/UserContext";
import { useNavigate } from "react-router-dom";
import { IUser, OptionType } from "../../types";
import Select from "react-select";
import { createFilter } from "react-select";
import Option, { customTheme } from "../../components/ReactSelect/Option/Option";
import MenuList from "../../components/ReactSelect/MenuList/MenuListSingle";
import styles from "./UserPage.module.css"
import CustomLoader from "../../components/LoaderSpinner/CustomLoader";
import { GoPerson } from "react-icons/go";

const UserPage = () => {

  const { setUserId, users, user, employee } = useContext(UserContext);
  const navigate = useNavigate();

  const [userOptions, setUserOptions] = useState<OptionType[]>([]);

  useEffect(() => {
    const isValidUserOption = (userOption: IUser) =>
      !!userOption && !!userOption.id && !!userOption.login;

    let userOptions: OptionType[] = users
      .filter(isValidUserOption)
      .sort((a, b) => a.login.localeCompare(b.login))
      .map((userOption) => ({
        value: userOption.id.toString(),
        label: `${userOption.login} `

      }));
    setUserOptions(userOptions)
  }, [users])

  return (
    <main className={styles.main}>
      <h1>Aanmelden</h1>

      {user && <div className={styles.logged_in}>
        <GoPerson />
        <p>Ingelogd als <strong>{employee ? employee?.firstName : user?.login}</strong></p>
      </div>}

      <p>Dit scherm zal in de toekomst vervangen worden door een aanmeldscherm, maar voorlopig kunnen gebruikers in de lijst hieronder geselecteerd worden.</p>

      {users && <Select<OptionType>
        theme={customTheme}
        className="basic-single"
        classNamePrefix="select"
        isClearable={true}
        isSearchable={true}
        isDisabled={userOptions.length > 0 ? false : true}
        placeholder={userOptions.length > 0 ? "Selecteer..." : <CustomLoader />}
        name="shopSelect"
        filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
        maxMenuHeight={200} // Limit height to improve rendering
        options={userOptions}
        components={{ // Custom components to make use of react-window to improve rendering    
          Option,
          MenuList, // Custom menu list rendering
        }}
        onChange={(e) => {
          if (e?.value) {
            setUserId(+e.value);
            navigate(`/home`);
          }
        }} />}

    </main>
  );
}

export default UserPage;