import React from 'react';
import { IVisitType } from '../../types';

interface VisitTypeCardProps {
  visitType: IVisitType;
  visitContext: string
}

export const VisitTypeCard: React.FC<VisitTypeCardProps> = ({ visitType, visitContext }) => (
  <section className="card">
    <p>Visit type: {visitType.name}</p>
    <p>Visit Context</p>
    <p>visitContext</p>
  </section>
);
