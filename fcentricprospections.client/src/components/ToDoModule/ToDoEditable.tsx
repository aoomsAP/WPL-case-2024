import Select, { createFilter } from "react-select";
import { IToDo, OptionType } from "../../types";
import styles from "./ToDoEditable.module.css"
import EditableInput from "./EditableInput";
import Option from "./Option/Option";
import MenuList from "./MenuList/MenuListSingle";

interface ToDoEditableProps {
    index: number,
    toDo: IToDo,
    toDos: IToDo[],
    setToDos: (toDos: IToDo[]) => void;
    employeesOptions: OptionType[],
}

export default function ToDoEditable({ index, toDo, toDos, setToDos, employeesOptions }: ToDoEditableProps) {

    const isDisabled = (toDo.name === "Nieuwe brands") ||
        (toDo.name === "Nieuwe contact info") ||
        (toDo.name === "FC70 brand interesses")

    // Update a specific todo
    const updateToDo = (updatedFields: Partial<IToDo>) => {
        setToDos(
            toDos.map(t =>
                t.id === toDo.id ? { ...t, ...updatedFields } : t
            )
        );
    };

    // Delete the todo
    const handleDelete = () => {
        console.log("Deleting toDo with ID:", toDo.id);
        console.log("Current toDos IDs:", toDos.map(t => t.id));
        console.log("Before deletion:", toDos);
        const updatedToDos = toDos.filter(t => t.id !== toDo.id);
        console.log("After deletion:", updatedToDos);
        setToDos(updatedToDos);
    };

    return (
        <div className={styles.toDo} key={toDo.id}>
            {/* Header with delete button */}
            <div className={styles.editableinput_container}>
                <strong>#{index + 1}</strong>
                {!isDisabled && (
                    <button className={styles.close} onClick={handleDelete}>
                        X
                    </button>
                )}
            </div>

            {/* Title */}
            <div className={styles.editableinput_container}>
                <strong>
                    <EditableInput
                        type={"input"}
                        value={toDo.name ?? ""}
                        onChange={(newTitle) => {
                            updateToDo({ name: newTitle });
                        }}
                        disabled={isDisabled}
                    />
                </strong>
            </div>

            {/* Description */}
            <div className={styles.editableinput_container}>
                <label htmlFor="description">Taak:</label><br />
                <EditableInput
                    type={"textarea"}
                    value={toDo.remarks ?? ""}
                    onChange={(newDescription) => {
                        updateToDo({ remarks: newDescription });
                    }}
                    disabled={isDisabled}
                />
            </div>

            <label htmlFor="employee">Toegewezen aan: </label>
            <Select
                className="basic-single"
                classNamePrefix="select"
                value={employeesOptions.find((x) => x.value === toDo.employeeId?.toString())}
                placeholder={"Kies een persoon"}
                isClearable={true}
                isSearchable={true}
                name="employee"
                maxMenuHeight={200} // Limit height to improve rendering
                options={employeesOptions}
                components={{ // Custom components to make use of react-window to improve rendering    
                    Option,
                    MenuList, // Custom menu list rendering
                }}
                filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
                onChange={(e) => {
                    if (e) {
                        updateToDo({
                            employeeId: parseInt(e?.value ?? ""),
                            employeeName: e?.label,
                        });
                    }
                }}
            />
        </div>
    );
}
