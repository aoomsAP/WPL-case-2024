import { FormEvent, useContext, useEffect, useRef, useState } from "react";
import { IEmployee, IToDo, OptionType } from "../../../types";
import styles from "./ToDoModule.module.css"
import { UserContext } from "../../../contexts/UserContext";
import Select, { createFilter, MultiValue } from 'react-select';
import ToDoEditable from "./ToDoEditable/ToDoEditable";
import { v4 as uuidv4 } from 'uuid';
import Option, { customTheme } from "../../ReactSelect/Option/Option";
import MenuList from "../../ReactSelect/MenuList/MenuList";
import { TfiPlus } from "react-icons/tfi";
import CustomLoader from "../../LoaderSpinner/CustomLoader";
import CustomModal from "../../CustomModal/CustomModal";

interface ToDoModuleProps {
    toDos: IToDo[];
    setToDos: (toDos: IToDo[]) => void;
}

const ToDoModule = ({ toDos, setToDos }: ToDoModuleProps) => {

    const { employees } = useContext(UserContext);

    const [title, setTitle] = useState<string>(""); // "Name" in db
    const [description, setDescription] = useState<string>("");
    const [selectedEmployees, setSelectedEmployees] = useState<OptionType[]>([]);
    const [employeesOptions, setEmployeesOptions] = useState<OptionType[]>([]);

    const [isModalVisible, setModalVisible] = useState(false);

    const [errorMessage, setErrorMessage] = useState<string>();
    const errorRef = useRef<HTMLDivElement | null>(null);
    const showError = errorMessage != undefined && (title.trim() == "" || description.trim() == "" || selectedEmployees.length < 1)

    const [successMsg, setSuccessMsg] = useState<string>();
    const successRef = useRef<HTMLDivElement | null>(null);
    const showSuccess = successMsg && setTimeout(() => setSuccessMsg(undefined), 5000);

    function resetToDo() {
        setErrorMessage(undefined);
        setTitle("");
        setDescription("");
        setSelectedEmployees([]);
    }

    function onSubmit(event: FormEvent<HTMLFormElement>) {
        event.preventDefault();
        console.log("Submit handler");

        try {
            // All fields required
            if (selectedEmployees.length < 1 || description.trim() == "" || title.trim() == "") {
                throw Error("Vul alle velden in.");
            }

            const employees: IEmployee[] = selectedEmployees.map(e => {
                return ({
                    id: +e.value,
                    name: e.label,
                })
            });

            const newToDo: IToDo = {
                id: uuidv4(), // generate temporary unique id
                name: title,
                remarks: description,
                employees: employees,
                toDoStatusId: 1, // HARDCODED = "Ongoing"
                toDoTypeId: 4, // HARDCODED = "Other"
            }
            const newToDos = [...toDos, newToDo];
            console.log(newToDos);
            setToDos(newToDos);

            setModalVisible(false);

            setSuccessMsg(`Nieuwe taak "${newToDo.name}" toegevoegd`);
            setTimeout(() => {
                successRef.current?.scrollIntoView({ behavior: "smooth", block: "center" });
            }, 0);

            resetToDo();
        }

        catch (error) {
            console.error(error);
            let message = "Er ging iets mis. Probeer het later opnieuw."
            if (error instanceof Error) {
                message = error.message;
            }
            setErrorMessage(message);
            setTimeout(() => {
                errorRef.current?.scrollIntoView({ behavior: "smooth", block: "center" });
            }, 0);
        }
    }

    // Create new list without the automatic todo's

    const userAddedToDos: IToDo[] = toDos
        .filter(toDo => toDo.toDoTypeId === 4) ///HARDCODED = "Other"

    // Map employees to options for react-select
    useEffect(() => {
        const isValidEmployee = (employee: IEmployee) =>
            !!employee && !!employee.id && !!employee.name;

        let employeesOptions: OptionType[] = employees
            .filter(isValidEmployee)
            .sort((a, b) => a.name.localeCompare(b.name))
            .map((employee) => ({
                value: employee.id.toString(),
                label: employee.name
            }));
        setEmployeesOptions(employeesOptions);
    }, [employees])

    return (
        <>
            {/* TO DO CONTAINER */}
            {userAddedToDos.length > 0 &&
                <section className={styles.toDoContainer}>
                    <h3>ITEMS</h3>
                    <div>
                        {userAddedToDos.map((toDo, i) =>
                            <div key={toDo.id}>
                                <ToDoEditable index={i} toDo={toDo} toDos={userAddedToDos} setToDos={setToDos} employeesOptions={employeesOptions} />
                            </div>
                        )}
                    </div>
                    {showSuccess &&
                        <div
                            ref={successRef}
                            className={styles.success}
                        >
                            <p>{successMsg}</p>
                            <button
                                className={styles.successClose}
                                onClick={() => setSuccessMsg(undefined)} >
                                X
                            </button>
                        </div>}
                </section>
            }

            {/* OPEN TO DO MODAL */}
            {!isModalVisible &&
                <button
                    className={styles.modal_button}
                    title="Voeg taak toe"
                    onClick={() => setModalVisible(!isModalVisible)}
                >
                    Voeg item toe
                    <TfiPlus className={styles.modal_button__icon} />
                </button>
            }

            {/* TO DO INPUT */}
            <CustomModal
                visible={isModalVisible}
                onRequestClose={() => {
                    resetToDo();
                    setModalVisible(false);
                }}
                submitTitle="Voeg toe"
                onSecondButtonPress={() => {
                    resetToDo();
                    setModalVisible(false);
                }}
                secondButtonTitle="Terug"
                headerTitle="Voeg item toe"
                error={showError}
                errorMsg={errorMessage}
                formId="todoForm"
            >
                <form id="todoForm" onSubmit={onSubmit}>
                    <fieldset className={styles.newToDo}>
                        {/* Title */}
                        <div>
                            <label htmlFor="title">Naam van item:&nbsp;
                                <span className={styles.required}> *</span></label>
                            <input type="text" name="title" value={title} placeholder="Titel..."
                                onChange={(e) => setTitle(e.target.value)} />
                        </div>

                        {/* Description */}
                        <div>
                            <label htmlFor="description">Omschrijving van taak:&nbsp;
                                <span className={styles.required}> *</span></label>
                            <textarea name="description" value={description} placeholder="Omschrijving..."
                                onChange={(e) => setDescription(e.target.value)} />
                        </div>

                        {/* Employee */}
                        <div>
                            <label htmlFor="employee">Aan wie is de taak gericht?&nbsp;
                                <span className={styles.required}> *</span></label>
                            {employeesOptions && <Select<OptionType, true>
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
                                value={selectedEmployees}
                                options={employeesOptions}
                                components={{ // Custom components to make use of react-window to improve rendering
                                    MenuList,
                                    Option,
                                }}
                                onChange={(selectedOptions: MultiValue<OptionType>) => {
                                    let newSelectedOptions = selectedOptions.map(x => x);
                                    setSelectedEmployees(newSelectedOptions);
                                }}
                            />}
                        </div>
                    </fieldset>
                </form>
            </CustomModal>

        </>
    )
}


export default ToDoModule;