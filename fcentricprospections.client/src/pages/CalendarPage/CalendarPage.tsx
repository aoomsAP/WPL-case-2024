import { useContext, useEffect, useState } from 'react';
import { UserContext } from '../../contexts/UserContext';
import FullCalendar from "@fullcalendar/react";
import dayGridPlugin from "@fullcalendar/daygrid";
import timeGridPlugin from "@fullcalendar/timegrid";
import { EmployeeSelect } from './EmployeeSelect';
import { EventInput } from '@fullcalendar/core';

export const CalendarPage = () => {

    const { appointments } = useContext(UserContext);

    const [events, setEvents] = useState<EventInput[]>([]);

    useEffect(() => {
        const userEvents = appointments.map((appointment) => ({
            title: appointment.name ? appointment.name : (appointment.remarks ? appointment.remarks : "Geen details"),
            start: appointment.startDate,
            end: appointment.endDate,
            color: "steelblue", // User colors
        }));
        setEvents(userEvents);
    }, [appointments])

    return (
        <>
            <EmployeeSelect setEvents={setEvents} />

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
                progressiveEventRendering
                events={events}
            />
        </>
    );
}
