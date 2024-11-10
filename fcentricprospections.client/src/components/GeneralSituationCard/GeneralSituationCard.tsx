import React from 'react';
import { IProspectionDetail } from '../../types';
import styles from "./GeneralSituationCard.module.css"

interface GeneralSituationProps {
  detail: IProspectionDetail;
}

export const GeneralSituation: React.FC<GeneralSituationProps> = ({ detail }) => (
  <section className={styles.generalSituation}>
    <h2>Algemene situatie winkel</h2>
    <div>
      <h3>Beste merken</h3>
      <p>{detail.bestBrands}</p>
      <h3>Slechtste merken</h3>
      <p>{detail.worstBrands}</p>
      <h3>Merken out</h3> 
      <p>{detail.brandsOut}</p>
    </div>
  </section>
);
