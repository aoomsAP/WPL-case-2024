import Select, { createFilter, MultiValue } from "react-select";
import { IToDo, OptionType } from "../../../types";
import styles from "./ToDoEditable.module.css"
import EditableInput from "./EditableInput";
import Option, { customTheme } from "../../ReactSelect/Option/Option";
import MenuList from "../../ReactSelect/MenuList/MenuList";
import CustomLoader from "../../LoaderSpinner/CustomLoader";

interface ToDoEditableProps {
    index: number,
    toDo: IToDo,
    toDos: IToDo[],
    setToDos: (toDos: IToDo[]) => void;
    employeesOptions: OptionType[],
}

export default function ToDoEditable({ toDo, toDos, setToDos, employeesOptions }: ToDoEditableProps) {

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

    // Previously set employees
    const defaultEmployees = toDo.employees?.map(e => ({ value: e.id.toString(), label: e.name }));

    return (
        <div className={styles.toDo}>
            {/* Header with title & delete button */}
            <div className={styles.header}>
                <strong className={styles.title}>
                    <EditableInput
                        type={"input"}
                        value={toDo.name ?? ""}
                        onChange={(newTitle) => {
                            updateToDo({ name: newTitle });
                        }}
                    />
                </strong>
                <button className={styles.close} onClick={handleDelete}>
                    X
                </button>
            </div>

            {/* Description */}
            <div>
                <EditableInput
                    type={"textarea"}
                    value={toDo.remarks ?? ""}
                    onChange={(newDescription) => {
                        updateToDo({ remarks: newDescription });
                    }}
                />
            </div>

            {/* Employees select */}
            <label htmlFor="employee">Toegewezen aan: </label>
            <Select<OptionType, true>
                theme={customTheme}
                className="basic-multi-select"
                classNamePrefix="select"
                isMulti
                isClearable={true}
                isSearchable={true}
                name="employees"
                isDisabled={employeesOptions.length > 0 ? false : true}
                placeholder={employeesOptions.length > 0 ? "Selecteer..." : <CustomLoader />}
                filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
                maxMenuHeight={200} // Limit height to improve rendering
                defaultValue={defaultEmployees}
                options={employeesOptions}
                components={{ // Custom components to make use of react-window to improve rendering
                    MenuList,
                    Option,
                }}
                onChange={(selectedOptions: MultiValue<OptionType>) => {
                    let newSelectedEmployees = selectedOptions.map(x => ({ id: +x.value, name: x.label }));
                    updateToDo({ employees: newSelectedEmployees });
                }}
            />
        </div>
    );
}
