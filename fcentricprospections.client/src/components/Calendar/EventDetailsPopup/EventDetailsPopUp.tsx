import { memo } from "react";
import styles from "./EventDetailsPopup.module.css";

export const EventDetailsPopup = memo(
  ({ event, onClose }: { event: any; onClose: () => void }) => {
    if (!event) return null;

    return (
      <>
        {/* Overlay */}
        <div className={styles.event_popup_overlay} onClick={onClose}></div>
        
        {/* Popup Content */}
        <div className={styles.event_popup} role="dialog" aria-modal="true" aria-labelledby="event-title">
          <h3 id="event-title">{event.title || "Geen details"}</h3>
          <p>
            <strong>Start:</strong>{" "}
            {new Date(event.start).toLocaleString("nl-NL")}
          </p>
          <p>
            <strong>Eind:</strong>{" "}
            {new Date(event.end).toLocaleString("nl-NL")}
          </p>
        </div>
      </>
    );
  }
);

export default EventDetailsPopup;