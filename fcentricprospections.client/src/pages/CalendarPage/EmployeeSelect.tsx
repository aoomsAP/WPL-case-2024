import { useContext, useEffect, useState } from "react";
import { UserContext } from "../../contexts/UserContext";
import { IAppointment, IEmployee, OptionType } from "../../types";
import Select, { createFilter, MultiValue, SingleValue } from 'react-select';
import MenuList from "../../components/ToDoModule/MenuList/MenuList";
import Option from "../../components/ToDoModule/Option/Option";

export const EmployeeSelect = () => {

    const { employees, loadAppointmentShown, appointments, setShownAppointments } = useContext(UserContext);

    async function changeCalendar(employeeId: string) {
        const newAppointments: IAppointment[] = await loadAppointmentShown(employeeId);
        setShownAppointments([...appointments, ...newAppointments])
    };

    const [employeesOptions, setEmployeesOptions] = useState<OptionType[]>([]);

    // Map employees to options for react-select
    useEffect(() => {
        const isValidEmployee = (employee: IEmployee) =>
            !!employee && !!employee.id && !!employee.name;

        let employeesOptions: OptionType[] = employees
            .filter(isValidEmployee)
            .map((employee) => ({
                value: employee.id,
                label: employee.name
            }));
        setEmployeesOptions(employeesOptions);
    }, [employees])

    return (
        <div style={{ marginBottom: "2rem", zIndex: 999 }}>
            <label htmlFor="employee">Vergelijk met de kalender van een collega:</label>
            {employeesOptions && <Select
                className="basic-single"
                classNamePrefix="select"
                defaultValue={employeesOptions[0]}
                placeholder={""}
                isClearable={true}
                isSearchable={true}
                name="employees"
                options={employeesOptions}
                onChange={(newValue: SingleValue<OptionType>) => {
                    if (newValue?.value) {
                        changeCalendar(newValue.value) // value = employeeId
                    }
                }}
            />}

            {/* {employeesOptions && <Select<OptionType, true>
                className="basic-multi-select"
                classNamePrefix="select"
                isMulti
                isClearable={true}
                isSearchable={true}
                name="employees"
                filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
                maxMenuHeight={200} // Limit height to improve rendering
                options={employeesOptions}
                components={{ // Custom components to make use of react-window to improve rendering
                    MenuList,
                    Option,
                }}
                onChange={(selectedOptions: MultiValue<OptionType>) => {
                    let newAppointments: IAppointment[] = [];
                    selectedOptions
                        .forEach(async (x: OptionType) => {
                            const addedCalendar: IAppointment[] = await loadAppointmentShown(x.value);
                            newAppointments = [...newAppointments, ...addedCalendar];
                        });
                    setShownAppointments([...appointments, ...newAppointments]);
                }}
            />} */}

        </div>
    );
}