import { useContext } from "react";
import { IProspectionToDo } from "../../types";
import { UserContext } from "../../contexts/UserContext";
import styles from "./ToDoItem.module.css"

interface ToDoItemProps {
    todo: IProspectionToDo
}

export const ToDoItem = ({ todo }: ToDoItemProps) => {

    const { employees } = useContext(UserContext)

    return (
        <article key={todo.id} className={styles.toDoCard}>

            <h3>{todo.name}</h3>
            <p>{todo.remarks}</p>

            <div>
                <label>Toegewezen aan: </label>
                <span className={styles.todolabel}>
                    {employees.find(x => x.id == (todo.employeeId)?.toString())?.name}
                </span>
            </div>

        </article>
    );
}

