import { FormEvent, useContext, useEffect, useState } from "react";
import { IEmployee, IToDo, OptionType } from "../../types";
import styles from "./ToDoModule.module.css"
import { UserContext } from "../../contexts/UserContext";
import Select, { createFilter, MultiValue } from 'react-select';
import ToDoEditable from "./ToDoEditable";
import { v4 as uuidv4 } from 'uuid';
import Option from "./Option/Option";
import MenuList from "./MenuList/MenuList";

interface ToDoModuleProps {
    toDos: IToDo[];
    setToDos: (toDos: IToDo[]) => void;
}

const ToDoModule = ({ toDos, setToDos }: ToDoModuleProps) => {

    const { employees } = useContext(UserContext);

    const [title, setTitle] = useState<string>(""); // "Name" in db
    const [description, setDescription] = useState<string>("");
    const [selectedEmployees, setSelectedEmployees] = useState<OptionType[]>([]);
    const [employeesOptions, setEmployeesOptions] = useState<OptionType[]>([]);

    function onSubmit(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();
        console.log("Submit handler");
        console.log("Employees", selectedEmployees);
        if (selectedEmployees && description.length > 0) {

            const employees: IEmployee[] = selectedEmployees.map(e => {
                return ({
                    id: +e.value,
                    name: e.label,
                })
            });

            const newToDo: IToDo = {
                id: uuidv4(), // generate temporary unique id
                name: title,
                remarks: description,
                employees: employees,
                toDoStatusId: 1, // HARDCODED = "Ongoing"
                toDoTypeId: 4, // HARDCODED = "Other"
            }
            const newToDos = [...toDos, newToDo];
            console.log(newToDos);
            setToDos(newToDos);
        } else {
            console.log("Invalid task");
        }
    }

    // Create new list without the automatic todo's

    const userAddedToDos: IToDo[] = toDos.filter(toDo => toDo.toDoTypeId === 4); ///HARDCODED = "Other"

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
            <form onSubmit={(e) => {
                onSubmit(e);
                // Clear "new todo"
                setTitle("");
                setDescription("");
                setSelectedEmployees([]);
            }}>
                <fieldset className={styles.newToDo}>
                    <h4>Nieuwe taak</h4>

                    {/* Title */}
                    <div>
                        <label htmlFor="title">Naam van taak:</label>
                        <input type="text" name="title" value={title} placeholder="Titel..."
                            onChange={(e) => setTitle(e.target.value)} />
                    </div>

                    {/* Description */}
                    <div>
                        <label htmlFor="description">Omschrijving van de taak:</label>
                        <textarea name="description" value={description} placeholder="Omschrijving..."
                            onChange={(e) => setDescription(e.target.value)} />
                    </div>

                    {/* Employee */}
                    <div>
                        <label htmlFor="employee">Aan wie is de taak gericht?</label>
                        {employeesOptions && <Select<OptionType, true>
                            className="basic-multi-select"
                            classNamePrefix="select"
                            isMulti
                            isClearable={true}
                            isSearchable={true}
                            name="employees"
                            filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
                            maxMenuHeight={200} // Limit height to improve rendering
                            value={selectedEmployees}
                            options={employeesOptions}
                            components={{ // Custom components to make use of react-window to improve rendering
                                MenuList,
                                Option,
                            }}
                            onChange={(selectedOptions: MultiValue<OptionType>) => {
                                let newSelectedOptions = selectedOptions.map(x => x);
                                setSelectedEmployees(newSelectedOptions);
                            }}
                        />}
                    </div>

                    <button type="submit">Voeg toe</button>
                </fieldset>
            </form>

            {/* TO DO CONTAINER */}
            <div className={styles.toDoContainer}>
                {
                    userAddedToDos
                        .map((toDo, i) =>
                            <div key={i}>
                                <ToDoEditable index={i} toDo={toDo} toDos={userAddedToDos} setToDos={setToDos} employeesOptions={employeesOptions} />
                            </div>
                        )
                }
            </div>
        </>
    )
}


export default ToDoModule;