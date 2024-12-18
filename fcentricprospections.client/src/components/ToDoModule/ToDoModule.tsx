import { FormEvent, useContext, useEffect, useState } from "react";
import { IEmployee, IToDo, OptionType } from "../../types";
import styles from "./ToDoModule.module.css"
import { UserContext } from "../../contexts/UserContext";
import Select, { createFilter } from 'react-select';
import ToDoEditable from "./ToDoEditable";
import { v4 as uuidv4 } from 'uuid';
import Option from "./Option/Option";
import MenuList from "./MenuList/MenuListSingle";

interface ToDoModuleProps {
    toDos: IToDo[];
    setToDos: (toDos: IToDo[]) => void;
}

const ToDoModule = ({ toDos, setToDos }: ToDoModuleProps) => {

    const { employees } = useContext(UserContext);

    const [title, setTitle] = useState<string>(""); // "Name" in db
    const [description, setDescription] = useState<string>("");
    const [selectedEmployee, setSelectedEmployee] = useState<OptionType>();
    const [employeesOptions, setEmployeesOptions] = useState<OptionType[]>([]);

    function onSubmit(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();
        console.log("Submit handler");
        console.log("employee", selectedEmployee);
        if (selectedEmployee && description.length > 0) {
            const newToDo: IToDo = {
                id: uuidv4(), // generate temporary unique id
                name: title,
                remarks: description,
                employeeId: +selectedEmployee.value,
                employeeName: selectedEmployee.label,
                toDoStatusId: 1, // DEFAULT
            }
            const newToDos = [...toDos, newToDo];
            console.log(newToDos);
            setToDos(newToDos);
        } else {
            console.log("Invalid task");
        }
    }

    // Create new list without the automatic todo's
    
    const userAddedToDos: IToDo[] = toDos.filter(toDo =>
        toDo.name !== "Nieuwe brands" &&
        toDo.name !== "Nieuwe contact info" &&
        toDo.name !== "FC70 brand interesses"
    );
    
    // Map employees to options for react-select
    useEffect(() => {
        const isValidEmployee = (employee: IEmployee) =>
            !!employee && !!employee.id && !!employee.name;

        let employeesOptions: OptionType[] = employees
            .filter(isValidEmployee)
            .map((employee) => ({
                value: employee.id.toString(),
                label: employee.name
            }));
        setEmployeesOptions(employeesOptions);
    }, [employees])

    return (
        <>
            {/* TO DO INPUT */}
            <form onSubmit={(e) => onSubmit(e)}>
                <fieldset>
                    <legend>Nieuwe taak</legend>

                    {/* Title */}
                    <label htmlFor="title">Naam van taak:</label>
                    <input type="text" name="title" value={title} placeholder="Titel..."
                        onChange={(e) => setTitle(e.target.value)} />

                    {/* Description */}
                    <label htmlFor="description">Omschrijving van de taak:</label>
                    <textarea name="description" value={description} placeholder="Omschrijving..."
                        onChange={(e) => setDescription(e.target.value)} />

                    {/* Employee */}
                    <label htmlFor="employee">Aan wie is de taak gericht?</label>
                    {employeesOptions && <Select
                        className="basic-single"
                        classNamePrefix="select"
                        defaultValue={selectedEmployee}
                        placeholder={"Kies een persoon"}
                        isClearable={true}
                        isSearchable={true}
                        name="employee"
                        options={employeesOptions}
                        components={{ // Custom components to make use of react-window to improve rendering    
                            Option,
                            MenuList, // Custom menu list rendering
                        }}
                        maxMenuHeight={200} // Limit height to improve rendering
                        filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
                        onChange={(e) => {
                            if (e) {
                                setSelectedEmployee(e);
                            }
                        }}
                    />}

                    <button type="submit">Voeg toe</button>
                </fieldset>
            </form>

            {/* TO DO CONTAINER */}
            <div className={styles.toDoContainer}>
                {
                    userAddedToDos
                        .map((toDo, i) =>
                            <ToDoEditable index={i} toDo={toDo} toDos={userAddedToDos} setToDos={setToDos} employeesOptions={employeesOptions} />
                        )
                }
            </div>
        </>
    )
}


export default ToDoModule;