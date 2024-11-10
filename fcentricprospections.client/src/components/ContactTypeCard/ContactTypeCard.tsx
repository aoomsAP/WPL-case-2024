import React from 'react';
import { IContactType } from '../../types';

interface ContactTypeCardProps {
  contactType: IContactType;
  contactPersonName: string;
}

export const ContactTypeCard: React.FC<ContactTypeCardProps> = ({ contactType, contactPersonName }) => (
  <section className="card">
    <p>Contact type: {contactType.name}</p>
    <p>Contactnaam: {contactPersonName}</p>
  </section>
);