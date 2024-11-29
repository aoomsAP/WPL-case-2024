import { IContactType } from '../../types';
import styles from "./ContactTypeCard.module.css"

interface ContactTypeCardProps {
  contactType: IContactType;
  contactPersonName: string;
  contactEmail : string;
  contactPhone : string;
}

export const ContactTypeCard = ({ contactType, contactPersonName,contactEmail , contactPhone } : ContactTypeCardProps) => (
  <article className={styles.contactTypeCard}>
    <h3>Contact type</h3>
    <p>{contactType.name}</p>
    <h3>Contactpersoon</h3>
    <p>{contactPersonName}</p>
    <h3>Contact Email</h3>
    <p>{contactEmail}</p>
    <h3>Contact Telefoon</h3>
    <p>{contactPhone}</p>
  </article>
);