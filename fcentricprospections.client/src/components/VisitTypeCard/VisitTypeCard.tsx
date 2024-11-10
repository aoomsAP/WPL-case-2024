import React from 'react';
import { IVisitType } from '../../types';

interface VisitTypeCardProps {
  visitType: IVisitType;
  visitContext: string
}

export const VisitTypeCard: React.FC<VisitTypeCardProps> = ({ visitType, visitContext }) => (
  <article className="visittype-card">
    <h3>Visit type</h3>
    <p>{visitType.name}</p>
    <h3>Visit Context</h3>
    <p>{visitContext}</p>
  </article >
);
