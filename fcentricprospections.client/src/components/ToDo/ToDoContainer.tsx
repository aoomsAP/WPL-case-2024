import { IProspectionToDo } from "../../types";
import { ToDoItem } from "./ToDoItem";
import style from './todoitem.module.css'

interface ToDoContainerProps{
    todos : IProspectionToDo[]
}

export const ToDoContainer = ({todos}: ToDoContainerProps) =>{

    return(
        <section className={style.todocontainer}>
        {todos.map((x, index) => (
            <ToDoItem key={index} todo={x} />
        ))}
    </section>
    );
}