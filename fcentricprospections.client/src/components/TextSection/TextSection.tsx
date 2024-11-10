import React from 'react';
import styles from "./TextSection.module.css"

interface TextSectionProps {
  title: string;
  text?: string;
}

export const TextSection: React.FC<TextSectionProps> = ({ title, text }) => (
  <section className={styles.textSection}>
    <h2>{title}</h2>
    <p>{text || "N/A"}</p>
  </section>
);
