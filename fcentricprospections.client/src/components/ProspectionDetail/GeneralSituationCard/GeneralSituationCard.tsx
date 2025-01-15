import React from 'react';
import { IProspectionDetail } from '../../../types';
import styles from "./GeneralSituationCard.module.css"

interface GeneralSituationProps {
  detail: IProspectionDetail;
}

export const GeneralSituation: React.FC<GeneralSituationProps> = ({ detail }) => (
  <>
    <article className={styles.card}>
      <h3>Beste merken</h3>
      <p>{detail.bestBrands || "N/A"}</p>
    </article>
    <article className={styles.card}>
      <h3>Slechtste merken</h3>
      <p>{detail.worstBrands || "N/A"}</p>
    </article>
    <article className={styles.card}>
      <h3>Merken out</h3>
      <p>{detail.terminatedBrands || "N/A"}</p>
    </article>
  </>

);
