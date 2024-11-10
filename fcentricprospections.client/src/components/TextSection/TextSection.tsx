import React from 'react';

interface TextSectionProps {
  title: string;
  text?: string;
}

export const TextSection: React.FC<TextSectionProps> = ({ title, text }) => (
  <section className="text-section">
    <p>{title}</p>
    <p>{text || "N/A"}</p>
  </section>
);
