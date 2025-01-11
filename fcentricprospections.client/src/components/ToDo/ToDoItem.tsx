import { useContext, useEffect, useState } from "react";
import { IEmployee, IProspectionToDo } from "../../types";
import styles from "./ToDoItem.module.css"
import { ProspectionDetailContext } from "../../contexts/ProspectionDetailContext";

interface ToDoItemProps {
    todo: IProspectionToDo
}

export const ToDoItem = ({ todo }: ToDoItemProps) => {

    const [employees, setEmployees] = useState<IEmployee[]>([]);
    const { loadToDoEmployees } = useContext(ProspectionDetailContext);

    async function loadToDoEmployeesFunc(toDoId: number) {
        const loadedEmployees = await loadToDoEmployees(toDoId);
        console.log("loaded employees",loadedEmployees);
        if (loadedEmployees) {
            setEmployees(loadedEmployees);
        }
    }

    useEffect(() => {
        if (todo.toDoId) {
            loadToDoEmployeesFunc(+todo.toDoId);
        }
    }, []);

    return (
        <article key={todo.id} className={styles.toDoCard}>

            <h3>{todo.name}</h3>
            <p>{todo.remarks}</p>
            {employees.length > 0 &&
                <div>
                    <label>Toegewezen aan: </label>
                    <span className={styles.todolabel}>
                        {employees.map((x, i) => i != 0 ? `, ${x.name}` : x.name)}
                    </span>
                </div>
            }

        </article>
    );
}

