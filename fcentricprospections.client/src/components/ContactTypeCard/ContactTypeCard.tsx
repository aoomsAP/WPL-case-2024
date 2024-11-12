import React from 'react';
import { IContactType } from '../../types';
import styles from "./ContactTypeCard.module.css"

interface ContactTypeCardProps {
  contactType: IContactType;
  contactPersonName: string;
}

export const ContactTypeCard: React.FC<ContactTypeCardProps> = ({ contactType, contactPersonName }) => (
  <article className={styles.contactTypeCard}>
    <h3>Contact type</h3>
    <p>{contactType.name}</p>
    <h3>Contactpersoon</h3>
    <p>{contactPersonName}</p>
  </article>
);