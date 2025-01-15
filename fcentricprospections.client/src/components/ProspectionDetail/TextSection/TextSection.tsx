import React from 'react';
import styles from "./TextSection.module.css"

interface TextSectionProps {
  title: string;
  text?: string;
}

export const TextSection: React.FC<TextSectionProps> = ({ title, text }) => (
  <article className={styles.card}>
    <h3 className={styles.title}>{title}</h3>
    <p>{text || "N/A"}</p>
  </article>
);
