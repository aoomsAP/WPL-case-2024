import { useContext, useEffect, useState, useRef } from 'react';
import { UserContext } from '../../contexts/UserContext';
import FullCalendar from "@fullcalendar/react";
import dayGridPlugin from "@fullcalendar/daygrid";
import timeGridPlugin from "@fullcalendar/timegrid";
import { EmployeeSelect } from './EmployeeSelect';
import { EventInput } from '@fullcalendar/core';
import styles from './CalenderPage.module.css';
import listPlugin from '@fullcalendar/list';
import nlLocale from '@fullcalendar/core/locales/nl';
import CustomLoader from '../../components/LoaderSpinner/CustomLoader';

export const CalendarPage = () => {
    const { appointments, userCalendarLoading } = useContext(UserContext);

    const [events, setEvents] = useState<EventInput[]>([]);
    const [windowWidth, setWindowWidth] = useState<number>(window.innerWidth);

    const calendarRef = useRef<FullCalendar | null>(null);

    function isAllDay(startDate: Date, endDate: Date): boolean {
        const businessStartHour = 9; // 9 AM
        const businessEndHour = 18; // 6 PM
        return (
            startDate.getHours() <= businessStartHour &&
            endDate.getHours() >= businessEndHour &&
            startDate < endDate
        );
    }

    useEffect(() => {
        const userEvents = appointments.map((appointment) => ({
            title: appointment.name ? appointment.name : (appointment.remarks ? appointment.remarks : "Geen details"),
            start: appointment.startDate,
            end: appointment.endDate,
            color: "yellow",
            allDay: isAllDay(new Date(appointment.startDate), new Date(appointment.endDate))
        }));
        setEvents(userEvents);
    }, [appointments]);

    const handleWindowResize = (_: { view: { type: string } }) => {
        setWindowWidth(window.innerWidth);
    };

    if (userCalendarLoading) {
        <main>
            <section className={styles.loading}>
                <p>Agenda wordt geladen...</p>
                <CustomLoader />
            </section>
        </main>
    }
    else {
        return (
            <main className={styles.main}>
                <div className={styles.employeeSelect}>
                    <EmployeeSelect setEvents={setEvents} />
                </div>

                <FullCalendar
                    ref={calendarRef}
                    plugins={[dayGridPlugin, timeGridPlugin, listPlugin]}
                    initialView={windowWidth > 700 ? "dayGridMonth" : "listMonth"}
                    weekends={false}
                    navLinks={true}
                    locale={nlLocale} // NL localization (date & time formatting)
                    headerToolbar={{
                        left: "prev,next today",
                        center: "title",
                        right: `${windowWidth > 700 ? 'dayGridMonth,timeGridWeek,timeGridDay' : 'dayGridMonth,listMonth,timeGridDay'}`
                    }}
                    slotMinTime="07:00:00" // Start timegrid from 7am
                    slotDuration="00:30:00"
                    progressiveEventRendering
                    events={events}
                    aspectRatio={1.5}
                    contentHeight="auto"
                    handleWindowResize={true} // Enable automatic resize
                    windowResize={handleWindowResize} // Callback on resize
                />
            </main>
        );
    }
};


