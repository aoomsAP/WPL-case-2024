import { IContactType } from '../../../types';
import styles from "./ContactTypeCard.module.css"

interface ContactTypeCardProps {
  contactType: IContactType;
  contactPersonName: string | undefined;
  contactEmail: string | undefined;
  contactPhone: string | undefined;
}

export const ContactTypeCard = ({ contactType, contactPersonName, contactEmail, contactPhone }: ContactTypeCardProps) => (
  <article className={styles.card}>
    <h3 className={styles.title}>Contact</h3>
    <p><strong>Contact type:&nbsp;</strong>
      {(contactType.name && contactType.name.length > 1) ? contactType.name : "N/A"}
    </p>
    <p><strong>Contactpersoon:&nbsp;</strong>
      {(contactPersonName && contactPersonName.length > 1) ? contactPersonName : "N/A"}
    </p>
    <p><strong>Email:&nbsp;</strong>
      {(contactEmail && contactEmail.length > 1) ? contactEmail : "N/A"}
    </p>
    <p><strong>Telefoonnummer:&nbsp;</strong>
      {(contactPhone && contactPhone.length > 1) ? contactPhone : "N/A"}
    </p>
  </article>
);