import { useContext, useEffect, useState } from "react";
import { UserContext } from "../../contexts/UserContext";
import { useNavigate } from "react-router-dom";
import { IUser, OptionType } from "../../types";
import Select from "react-select";
import { createFilter } from "react-select";
import Option, { customTheme } from "../../components/ToDoModule/Option/Option";
import MenuList from "../../components/ToDoModule/MenuList/MenuListSingle";
import styles from "./UserPage.module.css"

const UserPage = () => {

  const { setUserId, users } = useContext(UserContext);
  const navigate = useNavigate();

  const [userOptions, setUserOptions] = useState<OptionType[]>([]);

  useEffect(() => {
    const isValidUserOption = (userOption: IUser) =>
      !!userOption && !!userOption.id && !!userOption.login;

    let userOptions: OptionType[] = users
      .filter(isValidUserOption)
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
        theme={customTheme}
        className="basic-single"
        classNamePrefix="select"
        isClearable={true}
        isSearchable={true}
        placeholder={"Selecteer..."}
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