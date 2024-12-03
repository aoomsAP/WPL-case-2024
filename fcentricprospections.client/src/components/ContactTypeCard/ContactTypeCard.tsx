import { IContactType } from '../../types';
import styles from "./ContactTypeCard.module.css"

interface ContactTypeCardProps {
  contactType: IContactType;
  contactPersonName: string | undefined;
  contactEmail: string | undefined;
  contactPhone: string | undefined;
}

export const ContactTypeCard = ({ contactType, contactPersonName, contactEmail, contactPhone }: ContactTypeCardProps) => (
  <article className={styles.contactTypeCard}>
    <h3>Contact type</h3>
    <p>{(contactType.name && contactType.name.length > 1) ? contactType.name : "N/A"}</p>
    <h3>Contactpersoon</h3>
    <p>{(contactPersonName && contactPersonName.length > 1) ? contactPersonName : "N/A"}</p>
    <h3>Contact Email</h3>
    <p>{(contactEmail && contactEmail.length > 1) ? contactEmail : "N/A"}</p>
    <h3>Contact Telefoon</h3>
    <p>{(contactPhone && contactPhone.length > 1) ? contactPhone : "N/A"}</p>
  </article>
);