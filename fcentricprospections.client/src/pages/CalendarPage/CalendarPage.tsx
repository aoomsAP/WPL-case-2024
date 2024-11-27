import { useContext } from 'react';
import { UserContext } from '../../contexts/UserContext';
import FullCalendar from "@fullcalendar/react";
import dayGridPlugin from "@fullcalendar/daygrid";
import timeGridPlugin from "@fullcalendar/timegrid";
import { EmployeeSelect } from './EmployeeSelect';

export const CalendarPage = () => {

    const { shownAppointments, appointments } = useContext(UserContext);

    const events = appointments.map((appointment) => ({
        title: appointment.name ? appointment.name : (appointment.remarks ? appointment.remarks : "Geen details"),
        start: appointment.startDate,
        end: appointment.endDate,
        color: "steelblue", // Changes the background color
    }));

    console.log(appointments);

    return (
        <>
            {/* <EmployeeSelect /> */}

            <FullCalendar
                plugins={[dayGridPlugin, timeGridPlugin]}
                initialView="dayGridMonth"
                weekends={false}
                navLinks={true}
                headerToolbar={{
                    left: "prev,next today", // Navigation buttons
                    center: "title", // Title in the center
                    right: "dayGridMonth,timeGridWeek,timeGridDay", // View toggle buttons
                }}
                slotDuration="00:30:00"
                events={events}
            />
        </>
    );
}
