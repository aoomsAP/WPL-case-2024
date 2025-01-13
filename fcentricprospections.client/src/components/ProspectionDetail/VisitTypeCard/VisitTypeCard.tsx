import React from 'react';
import { IVisitType } from '../../../types';
import styles from "./VisitTypeCard.module.css"

interface VisitTypeCardProps {
  visitType: IVisitType;
  visitContext: string | undefined
}

export const VisitTypeCard: React.FC<VisitTypeCardProps> = ({ visitType, visitContext }) => (

  <article className={styles.card}>
    <h3 className={styles.title}>Bezoek</h3>
    <p><strong>Bezoek type:&nbsp;</strong>
      {visitType.name}
    </p>
    <p><strong>Reden van bezoek:&nbsp;</strong>
      {(visitContext && visitContext.length > 1) ? visitContext : "N/A"}
    </p>
  </article>
);
