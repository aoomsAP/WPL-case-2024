import { useContext, useEffect, useState } from "react";
import { IEmployee, IProspectionToDo } from "../../../types";
import styles from "./ToDoItem.module.css"
import { ProspectionDetailContext } from "../../../contexts/ProspectionDetailContext";
import React from "react";

interface ToDoItemProps {
    todo: IProspectionToDo
}

export const ToDoItem = ({ todo }: ToDoItemProps) => {

    const [employees, setEmployees] = useState<IEmployee[]>([]);
    const { loadToDoEmployees } = useContext(ProspectionDetailContext);

    async function loadToDoEmployeesFunc(toDoId: number) {
        const loadedEmployees = await loadToDoEmployees(toDoId);
        console.log("loaded employees", loadedEmployees);
        if (loadedEmployees) {
            setEmployees(loadedEmployees);
        }
    }

    const stringToNode = (text: string) => {
        // Split the input text by double newlines and then by single newlines
        const sections = text.split(/\n\n/);

        return (
            <div>
                {sections.map((section, sectionIndex) => (
                    <React.Fragment key={sectionIndex}>
                        {section.split('\n').map((line, lineIndex) => {
                            // If the line contains a colon, make everything before colon a label
                            const colonIndex = line.indexOf(':');
                            if (colonIndex > -1) {
                                // Extract label including the colon
                                const label = line.slice(0, colonIndex + 1);

                                // Extract the rest of the line
                                const value = line.slice(colonIndex + 1).trim();
                                return (
                                    <p className={styles.toDoLine} key={lineIndex}>
                                        <strong>{label}</strong> {value}
                                    </p>
                                );
                            }
                            return <p className={styles.toDoLine} key={lineIndex}>{line}</p>;
                        })}

                        {/* Separate sections (double new lines) with a hr element */}
                        {sectionIndex < sections.length - 1 && <hr />}
                    </React.Fragment>
                ))}
            </div>
        );
    };

    useEffect(() => {
        if (todo.toDoId) {
            loadToDoEmployeesFunc(+todo.toDoId);
        }
    }, []);

    return (
        <>
            <article key={todo.id} className={styles.card}>
                <h3>{todo.name}</h3>
                <div className={styles.remarksContainer}>
                    {todo.remarks && stringToNode(todo.remarks)}
                </div>
                {employees.length > 0 &&
                    <p><strong>Toegewezen aan:&nbsp;</strong>
                        <span className={styles.employees}>
                            {employees.map((x, i) => i != 0 ? `, ${x.name}` : x.name)}
                        </span>
                    </p>
                }
            </article>
        </>
    );
}

