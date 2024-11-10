import React from 'react';
import { IProspectionDetail } from '../../types';

interface GeneralSituationProps {
  detail: IProspectionDetail;
}

export const GeneralSituation: React.FC<GeneralSituationProps> = ({ detail }) => (
  <section className="general-situation">
    <p>Algemene situatie winkel</p>
    <p>Beste merken: {detail.bestBrands}</p>
    <p>Slechtste merken: {detail.worstBrands}</p>
    <p>Merken out: {detail.brandsOut}</p>
  </section>
);
