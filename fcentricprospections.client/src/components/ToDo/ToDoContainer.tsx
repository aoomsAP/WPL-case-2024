import { IProspectionToDo } from "../../types";
import { ToDoItem } from "./ToDoItem";
import styles from './ToDoContainer.module.css'

interface ToDoContainerProps {
    todos: IProspectionToDo[]
}

export const ToDoContainer = ({ todos }: ToDoContainerProps) => {

    return (
        <section className={styles.toDoContainer}>
            <h2>Opvolging</h2>
            <div style={{display: "flex",flexDirection: "column", gap: "1rem"}}>
                {todos.map((x, index) => (
                    <ToDoItem key={index} todo={x} />
                ))}
            </div>
        </section>
    );
}