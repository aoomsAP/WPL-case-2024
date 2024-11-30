import Select from "react-select";
import { IEmployee, IToDo, OptionType } from "../../types";
import styles from "./ToDoEditable.module.css"
import { useContext, useEffect, useState } from "react";
import { UserContext } from "../../contexts/UserContext";
import EditableInput from "./EditableInput";

interface ToDoEditableProps {
    index: number,
    toDo: IToDo,
    toDos: IToDo[],
    setToDos: (toDos: IToDo[]) => void;
    employeesOptions: OptionType[],
}

export default function ToDoEditable({ index, toDo, toDos, setToDos, employeesOptions }: ToDoEditableProps) {

    const { employees } = useContext(UserContext);

    const [title, setTitle] = useState<string>(toDo.name ?? ""); // "Name" in db
    const [description, setDescription] = useState<string>(toDo.remarks ?? ""); // "Remarks" in db
    const [selectedEmployee, setSelectedEmployee] = useState<IEmployee | undefined>(employees.find(x => x.id === toDo?.employeeId?.toString()));

    const isDisabled = (toDo.name === "Nieuwe brands") ||
        (toDo.name === "Nieuwe contact info") ||
        (toDo.name === "FC70 brand interesse")

    // "X" deletes the current todo from the state array
    function handleDelete() {
        // Filter out the current todo
        const filteredToDos = toDos.filter((_, i) => i !== index);
        // Set new filtered array
        setToDos(filteredToDos);
    }

    useEffect(() => {
        let newToDo = {
            id: toDo.id,
            remarks: toDo.remarks,
            employeeId: toDo.employeeId,
            employeeName: toDo.remarks,
            toDoStatusId: toDo.toDoStatusId,
            toDoStatus: toDo.toDoStatus,
            name: toDo.name,
            dateCreated: toDo.dateCreated,
            userCreatedId: toDo.userCreatedId,
        }
        toDos[index] = newToDo;
        const newToDos = [...toDos];
        setToDos(newToDos);
    }, [selectedEmployee])

    return (
        <>
            <div key={index} className={styles.toDo}>


                {/* Header with delete button */}
                <div className={styles.editableinput_container}>
                    <strong>
                        #{index + 1}
                    </strong>
                    {!isDisabled &&
                        <button className={styles.close} onClick={() => handleDelete()}>X</button>
                    }
                </div>

                {/* Title */}
                <div className={styles.editableinput_container}>
                    <strong>
                        <EditableInput type={"input"} value={title} onChange={setTitle} disabled={isDisabled} />
                    </strong>
                </div>

                {/* Description */}
                <div className={styles.editableinput_container}>
                    <label htmlFor="description">Taak:</label><br></br>
                    <EditableInput type={"textarea"} value={description} onChange={setDescription} disabled={isDisabled} />
                </div>

                <label htmlFor="employee">Toegewezen aan: </label>
                <Select
                    className={`basic-single`}
                    classNamePrefix="select"
                    defaultValue={employeesOptions.find(x => x.value == toDo.employeeId?.toString())}
                    placeholder={"Kies een persoon"}
                    isClearable={true}
                    isSearchable={true}
                    name="employee"
                    options={employeesOptions}
                    onChange={(e) => {
                        const selected = employees.find(x => x.id === e?.value);
                        if (selected) {
                            setSelectedEmployee(selected);
                        }
                    }}
                />

            </div >
        </>
    )
}