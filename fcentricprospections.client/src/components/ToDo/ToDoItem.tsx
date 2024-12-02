import { useContext } from "react";
import { IProspectionToDo } from "../../types";
import { UserContext } from "../../contexts/UserContext";
import style from "./todoitem.module.css"

interface ToDoItemProps{
    todo : IProspectionToDo
}

export const ToDoItem = ({todo}: ToDoItemProps) => {

    const {employees} = useContext(UserContext)

    return(
        <article key={todo.id} className={style.TodoCard}>

          <label className={style.todolabel}>Title</label>

          <p className={style.todop}>{todo.name}</p>

          <label className={style.todolabel}>Omschrijving</label>

          <p className={style.todop}>{todo.remarks}</p>

          <label className={style.todolabel}>Toegewezen aan</label>

          <p className={style.todop}>{employees.find(x => x.id == (todo.employeeId)?.toString())?.name}</p>
          
        </article>
    );
}

