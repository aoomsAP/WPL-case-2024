import React from 'react';
import { IVisitType } from '../../types';

interface VisitTypeCardProps {
  visitType: IVisitType;
  visitContext: string | undefined
}

export const VisitTypeCard: React.FC<VisitTypeCardProps> = ({ visitType, visitContext }) => (
  <article className="visittype-card">
    <h3>Bezoek type</h3>
    <p>{visitType.name}</p>
    <h3>Reden van bezoek</h3>
    <p>{(visitContext && visitContext.length > 1) ? visitContext : "N/A"}</p>
  </article >
);
