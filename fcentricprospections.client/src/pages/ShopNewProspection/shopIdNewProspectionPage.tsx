import styles from '../../App.module.css';

export const Prospectie = () => {

    const handleSubmit = (event : any) => {
        event.preventDefault(); 
        console.log('Form submitted'); {/* Nog te verwijderen later*/}
      };

    return (
      <main className={styles.main}>
        <h1>Voer details in</h1>
        <form className={styles.prospectionform} onSubmit={handleSubmit}>
          {/* Date input */}
          <label htmlFor="date">Kies Datum:</label>
          <input type="date" id="date" name="datum" />
  
          {/* Text area input */}
          <label htmlFor="text">Schrijf hier:</label>
          <textarea id="text" name="text" rows={4} cols={40} placeholder="Type je text hier"></textarea>

          {/* Submit Button */}
        <button type="submit">Verstuur</button>

        </form>

    
      </main>
    );
  };
  