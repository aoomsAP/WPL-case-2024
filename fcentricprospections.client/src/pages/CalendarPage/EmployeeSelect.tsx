import { useContext, useEffect, useState } from "react";
import { UserContext } from "../../contexts/UserContext";
import { IAppointment, IEmployee, OptionType } from "../../types";
import Select, { createFilter, MultiValue } from 'react-select';
import MenuList from "../../components/CustomReactSelect/MenuList/MenuList";
import Option, {customTheme} from "../../components/CustomReactSelect/Option/Option";
import { EventInput } from '@fullcalendar/core';
import { Oval } from "react-loader-spinner";
import style from './CalenderPage.module.css'

interface EmployeeSelectProps {
    setEvents: (events: EventInput[]) => void;
}

export const EmployeeSelect = ({ setEvents }: EmployeeSelectProps) => {

    const { employees, loadAppointmentShown, appointments } = useContext(UserContext);

    const [employeesOptions, setEmployeesOptions] = useState<OptionType[]>([]);
    const [selectedEmployees, setSelectedEmployees] = useState<string[]>([]); // ids of selected employees
    const [appLoading, setAppLoading] = useState<boolean>(false);

    // TO DO: write more efficiently: filter first, then only add NEWLY selected employee appointments
    async function updateEvents() {
        // Start with the user's own appointments
        let allEvents = appointments.map((appointment) => ({
            title: appointment.name ? appointment.name : (appointment.remarks ? appointment.remarks : "Geen details"),
            start: appointment.startDate,
            end: appointment.endDate,
            color: "yellow",
        }));

        const colors = ["crimson", "purple", "mediumvioletred", "orangered", "indigo", "darkred"];

        // Add appointments for every currently selected employee
        setAppLoading(true);
        for (let [index, id] of selectedEmployees.entries()) {
            const newAppointments: IAppointment[] = await loadAppointmentShown(+id);
            const newEvents = newAppointments.map((appointment) => ({
                title: appointment.name ? appointment.name : (appointment.remarks ? appointment.remarks : "Geen details"),
                start: appointment.startDate,
                end: appointment.endDate,
                color: index < colors.length ? colors[index] : "grey",
            }));
            allEvents = [...allEvents, ...newEvents];
        }
        setAppLoading(false);
        setEvents(allEvents);
    }

    // For every selected employee, update events
    useEffect(() => {
        updateEvents();
    }, [selectedEmployees])

    // Map employees to OptionType[] for react-select
    useEffect(() => {
        const isValidEmployee = (employee: IEmployee) =>
            !!employee && !!employee.id && !!employee.name;

        let employeesOptions: OptionType[] = employees
            .filter(isValidEmployee)
            .map((employee) => ({
                value: employee.id.toString(),
                label: employee.name
            }));
        setEmployeesOptions(employeesOptions);
    }, [employees])

    return (
        <div className={style.Search}>
            <label  htmlFor="employee">Vergelijk met de kalender van een collega:</label>

            {employeesOptions && <Select<OptionType, true>
                theme={customTheme}
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
                    let newSelectedOptions = selectedOptions.map(x => x.value); // value = employeeId
                    setSelectedEmployees(newSelectedOptions);
                }}
            />}

            {(appLoading || !appointments) &&
                <div  style={{ padding: "1rem" }}>
                    <Oval width={36} height={36} />
                </div>
            }

        </div>
    );
}