import { FormEvent, useContext, useState } from "react";
import { IEmployee, IToDo } from "../../types";
import styles from "./ToDoModule.module.css"
import { UserContext } from "../../contexts/UserContext";

interface ToDoModuleProps {
    toDos: IToDo[];
    setToDos: (toDos: IToDo[]) => void;
}

const ToDoModule = ({ toDos, setToDos }: ToDoModuleProps) => {

    const { employees } = useContext(UserContext);

    const [description, setDescription] = useState<string>("");
    const [employee, setEmployee] = useState<IEmployee>();

    // Search fields
    const [employeeSearch, setEmployeeSearch] = useState<string>("");

    // Filter for competitor brands
    const employeeSearchResult = employees.filter((employee: IEmployee) => employee.name.toLowerCase().includes(employeeSearch.toLowerCase()));

    function onSubmit(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();
        console.log("Submit handler");
        if (employee && description.length > 0) {
            const newToDo: IToDo = {
                id: (toDos.length > 0 ? (toDos[toDos.length - 1]?.id ?? 0) + 1 : 1),
                remarks: description,
                employeeId: +employee.id,
                toDoStatusId: 1, // DEFAULT
                name: employee.name // ??
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
        const filteredToDos = toDos.filter((_,i) => i !== deleteIndex);
        // Set new filtered array
        setToDos(filteredToDos);
    }


    return (
        <>
            {/* TO DO INPUT */}
            <form onSubmit={(e) => onSubmit(e)}>
                <fieldset>
                    <legend>Nieuwe taak</legend>
                    <label htmlFor="description">Omschrijf de taak:</label>
                    <textarea name="description" value={description} onChange={(e) => setDescription(e.target.value)} />
                    <label>Aan wie is de taak gericht?</label>
                    <input
                        className={styles.inputField}
                        type="text"
                        placeholder="Zoek..."
                        defaultValue={employee?.name ?? ""}
                        value={employeeSearch}
                        onChange={(e) => setEmployeeSearch(e.target.value)}
                    />

                    <ul className={styles.employeeSearch}>
                        {employeeSearchResult.map((employee: IEmployee) => (
                            <li key={employee.id} onClick={() => {
                                setEmployee(employee);
                                setEmployeeSearch(employee.name);
                            }}>{employee.name}</li>
                        ))}
                    </ul>
                    <button type="submit">Voeg toe</button>
                </fieldset>
            </form>

            {/* TO DOS CONTAINER */}
            <div className={styles.toDoContainer}>
                {
                    toDos.map((toDo, i) =>
                        <div key={i} className={styles.toDo}>
                            <button className={styles.close} onClick={() => handleClick(i)}>X</button>
                            <p>Taak: {toDo.remarks}</p>
                            <p>Toegewezen aan: {toDo.name}</p>
                        </div>
                    )
                }
            </div>
        </>
    )
}


export default ToDoModule;