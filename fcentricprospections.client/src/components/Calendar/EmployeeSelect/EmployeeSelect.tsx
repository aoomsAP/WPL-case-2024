import { useContext, useEffect, useState } from "react";
import { UserContext } from "../../../contexts/UserContext";
import { IAppointment, IEmployee, OptionType } from "../../../types";
import Select, { createFilter, MultiValue, StylesConfig } from 'react-select';
import MenuList from "../../ReactSelect/MenuList/MenuList";
import Option, { customTheme } from "../../ReactSelect/Option/Option";
import { EventInput } from '@fullcalendar/core';
import CustomLoader from "../../LoaderSpinner/CustomLoader";
import styles from "./EmployeeSelect.module.css";
import chroma from 'chroma-js'

interface EmployeeSelectProps {
    setEvents: (events: EventInput[]) => void;
}

export const EmployeeSelect = ({ setEvents }: EmployeeSelectProps) => {

    const { employee, employees, loadAppointmentShown, appointments } = useContext(UserContext);

    const [employeesOptions, setEmployeesOptions] = useState<OptionType[]>([]);
    const [selectedEmployees, setSelectedEmployees] = useState<OptionType[]>([]);
    const [appLoading, setAppLoading] = useState<boolean>(false);

    const colors = [
        "rgb(255, 99, 71)",   // Tomato
        "rgb(60, 179, 113)",  // Medium Sea Green
        "rgb(30, 144, 255)",  // Dodger Blue
        "rgb(255, 165, 0)",   // Orange
        "rgb(106, 90, 205)",  // Slate Blue
        "rgb(255, 105, 180)"  // Hot Pink
    ];

    async function updateEvents() {
        // Start with the user's own appointments
        let allEvents = appointments.map((appointment) => ({
            title: appointment.name ? appointment.name : (appointment.remarks ? appointment.remarks : "Geen details"),
            start: appointment.startDate,
            end: appointment.endDate,
            color: "yellow",
        }));

        // Add appointments for every currently selected employee
        setAppLoading(true);
        for (let [index, employee] of selectedEmployees.entries()) {
            const newAppointments: IAppointment[] = await loadAppointmentShown(+employee.value);
            const newEvents = newAppointments.map((appointment) => ({
                title: appointment.name ? appointment.name : (appointment.remarks ? appointment.remarks : "Geen details"),
                start: appointment.startDate,
                end: appointment.endDate,
                // Set event to color of the respective selected employee index
                color: index < colors.length ? colors[index] : "rgb(128,128,128)",
            }));
            allEvents = [...allEvents, ...newEvents];
        }
        setAppLoading(false);
        setEvents(allEvents);
    }

    // For every change in selected employees, update events
    useEffect(() => {
        updateEvents();
    }, [selectedEmployees])

    // Map employees to OptionType[] for react-select
    useEffect(() => {
        // Employee has to exist & have all values, and can't be the same as the logged in employee
        const isValidEmployee = (e: IEmployee) =>
            !!e && !!e.id && !!e.name && e.id != employee?.id;

        let employeesOptions: OptionType[] = employees
            .filter(isValidEmployee)
            .sort((a, b) => a.name.localeCompare(b.name))
            .map((employee) => ({
                value: employee.id.toString(),
                label: employee.name,
            }));
        setEmployeesOptions(employeesOptions);
    }, [employees])


    // Styling
    // https://react-select.com/styles

    function rgbToArray(rgbString: string): [number, number, number] | null {
        const regex = /rgb\((\d+),\s*(\d+),\s*(\d+)\)/;
        const match = rgbString.match(regex);
        if (match) {
            return [parseInt(match[1]), parseInt(match[2]), parseInt(match[3])];
        }
        return null;
    }

    const colourStyles: StylesConfig<OptionType, true> = {
        multiValue: (styles, { data }) => {
            // Turn rgb value into array of numbers, so the chroma library can make use of it
            const rgbArray = rgbToArray(data.color ?? "rgb(128,128,128)") ?? [0, 0, 0];
            const color = chroma(rgbArray);
            return {
                ...styles,

                // Lighter color for background color of selected option
                backgroundColor: color.alpha(0.1).css(),
            };
        },
        multiValueLabel: (styles, { data }) => {
            // Turn rgb value into array of numbers, so the chroma library can make use of it
            const rgbArray = rgbToArray(data.color ?? "rgb(128,128,128)") ?? [0, 0, 0];
            const darkColor = chroma(rgbArray).darken(2).css();
            return {
                ...styles,

                // Darker text color for better legibility
                color: darkColor,
            };
        },
        multiValueRemove: (styles, { data }) => ({
            ...styles,
            color: data.color,
            ':hover': {
                backgroundColor: data.color,
                color: 'white',
            },
        }),
    };

    return (
        <section className={styles.calendarSection}>
            {appointments.length < 1 &&
                <p>Geen afspraken teruggevonden voor deze gebruiker.</p>
            }

            <label htmlFor="employee">
                {appointments.length < 1
                    ? "Raadpleeg de kalender van een collega:"
                    : "Vergelijk met de kalender van een collega:"
                }
            </label>

            {employeesOptions && <Select<OptionType, true>
                theme={customTheme}
                className="basic-multi-select"
                classNamePrefix="select"
                isMulti
                isClearable={true}
                isSearchable={true}
                value={selectedEmployees}
                isDisabled={employeesOptions.length > 0 ? false : true}
                placeholder={employeesOptions.length > 0 ? "Selecteer..." : <CustomLoader />}
                name="employees"
                filterOption={createFilter({ ignoreCase: true, ignoreAccents: true })}
                maxMenuHeight={200} // Limit height to improve rendering
                options={employeesOptions}
                components={{ // Custom components to make use of react-window to improve rendering
                    MenuList,
                    Option,
                }}
                styles={colourStyles}
                onChange={(selectedOptions: MultiValue<OptionType>) => {
                    // Dynamically assign colors based on selection order
                    const newSelectedOptions = selectedOptions.map((option, index) => ({
                        ...option,
                        color: index < colors.length ? colors[index] : "rgb(128,128,128)", // Assign color
                    }));

                    // Update state with the full OptionType array, including assigned colors
                    setSelectedEmployees(newSelectedOptions);
                }}
            />}

            {appLoading &&
                <div className={styles.loading}>
                    <p>Agenda wordt geladen...</p>
                    <CustomLoader />
                </div>
            }

        </section>
    );
}