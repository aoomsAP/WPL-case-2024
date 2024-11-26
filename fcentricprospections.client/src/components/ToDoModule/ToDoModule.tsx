import { FormEvent, useContext, useEffect, useState } from "react";
import { IEmployee, IToDo } from "../../types";
import styles from "./ToDoModule.module.css"
import { UserContext } from "../../contexts/UserContext";
import Select from 'react-select';

interface ToDoModuleProps {
    toDos: IToDo[];
    setToDos: (toDos: IToDo[]) => void;
}

interface EmployeeOption {
    value: string;
    label: string;
}

const ToDoModule = ({ toDos, setToDos }: ToDoModuleProps) => {

    const { employees } = useContext(UserContext);

    const [title, setTitle] = useState<string>(""); // "Name" in db
    const [description, setDescription] = useState<string>("");
    const [employee, setEmployee] = useState<IEmployee>();
    const [employeesOptions, setEmployeesOptions] = useState<EmployeeOption[]>([]);

    // Search fields
    // const [employeeSearch, setEmployeeSearch] = useState<string>("");
    // const employeeSearchResult = employees.filter((employee: IEmployee) => employee.name.toLowerCase().includes(employeeSearch.toLowerCase()));

    function onSubmit(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();
        console.log("Submit handler");
        if (employee && description.length > 0) {
            const newToDo: IToDo = {
                id: (toDos.length > 0 ? (toDos[toDos.length - 1]?.id ?? 0) + 1 : 1),
                name: title,
                remarks: description,
                employeeId: +employee.id,
                toDoStatusId: 1, // DEFAULT
                employeeName: employee.name,
            }
            const newToDos = [...toDos, newToDo];
            console.log(newToDos);
            setToDos(newToDos);
        } else {
            console.log("Invalid task");
        }
    }

    // "X" deletes the current todo from the state array
    function handleClick(deleteIndex: number) {
        // Filter out the current todo
        const filteredToDos = toDos.filter((_, i) => i !== deleteIndex);
        // Set new filtered array
        setToDos(filteredToDos);
    }

    useEffect(() => {
        const isValidEmployee = (employee: IEmployee) =>
            !!employee && !!employee.id && !!employee.name;

        let employeesOptions: EmployeeOption[] = employees
            .filter(isValidEmployee)
            .map((employee) => ({
                value: employee.id,
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
                    <input type="text" name="title" value={title} onChange={(e) => setTitle(e.target.value)} />

                    {/* Description */}
                    <label htmlFor="description">Omschrijving van de taak:</label>
                    <textarea name="description" value={description} onChange={(e) => setDescription(e.target.value)} />

                    {/* Employee */}
                    <label htmlFor="employee">Aan wie is de taak gericht?</label>
                    {employeesOptions && <Select
                        className="basic-single"
                        classNamePrefix="select"
                        defaultValue={employeesOptions[0]}
                        placeholder={""}
                        isClearable={true}
                        isSearchable={true}
                        name="employee"
                        options={employeesOptions}
                        onChange={(e) => {
                            const selectedEmployee = employees.find(x => x.id === e?.value);
                            setEmployee(selectedEmployee);
                        }}
                    />}

                    <button type="submit">Voeg toe</button>
                </fieldset>
            </form>

            {/* TO DO CONTAINER */}
            <div className={styles.toDoContainer}>
                {
                    toDos.map((toDo, i) =>
                        <div key={i} className={styles.toDo}>
                            <button className={styles.close} onClick={() => handleClick(i)}>X</button>
                            <p><strong>Titel: {toDo.name}</strong></p>
                            <p>Taak: {toDo.remarks}</p>
                            <p>Toegewezen aan: {toDo.employeeName}</p>
                        </div>
                    )
                }
            </div>
        </>
    )
}


export default ToDoModule;