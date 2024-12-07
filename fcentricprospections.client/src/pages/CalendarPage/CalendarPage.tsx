import { useContext, useEffect, useState, useRef } from 'react';
import { UserContext } from '../../contexts/UserContext';
import FullCalendar from "@fullcalendar/react";
import dayGridPlugin from "@fullcalendar/daygrid";
import timeGridPlugin from "@fullcalendar/timegrid";
import { EmployeeSelect } from './EmployeeSelect';
import { EventInput } from '@fullcalendar/core';
import { Oval } from 'react-loader-spinner';
import style from './CalenderPage.module.css';
import listPlugin from '@fullcalendar/list';

export const CalendarPage = () => {
    const { appointments } = useContext(UserContext);
    const [events, setEvents] = useState<EventInput[]>([]);
    const calendarRef = useRef<FullCalendar | null>(null);
    const dimensions = getWindowDimensions();

    function getWindowDimensions() {
        const { innerWidth: width, innerHeight: height } = window;
        return {
          width,
          height
        };
      }
    
    useEffect(() => {
        const userEvents = appointments.map((appointment) => ({
            title: appointment.name ? appointment.name : (appointment.remarks ? appointment.remarks : "Geen details"),
            start: appointment.startDate,
            end: appointment.endDate,
            color: "steelblue",
        }));
        setEvents(userEvents);
    }, [appointments]);

    const handleWindowResize = (arg: { view: { type: string } }) => {
        console.log(`The calendar adjusted to a window resize. Current view: ${arg.view.type}`);
    };

    return (
        <div className={style.calendarContainer}>
            {events.length > 1 ? (
                <>
                    <div className={style.topControls}>
                        <EmployeeSelect setEvents={setEvents} />
                    </div>
                    <FullCalendar
                        ref={calendarRef}
                        plugins={[dayGridPlugin, timeGridPlugin , listPlugin ]}
                        initialView={ dimensions.width > 700 ? "dayGridMonth" : "listMonth"}
                        weekends={false}
                        navLinks={true}
                        headerToolbar={{
                            left: "prev,next today",
                            center: "title",
                            right:`${dimensions.height > 700 ? 'dayGridMonth,timeGridWeek,timeGridDay' : 'dayGridMonth,listMonth,timeGridDay'}`
                        }}
                        slotDuration="00:30:00"
                        progressiveEventRendering
                        events={events}
                        aspectRatio={1.5}
                        contentHeight="auto"
                        handleWindowResize={true} // Enable automatic resize
                        windowResize={handleWindowResize} // Callback on resize
                    />
                </>
            ) : (
                <Oval />
            )}
        </div>
    );
};


