import styles from '../../App.module.css';

export const Prospectie = () => {

    const handleSubmit = (event : any) => {
        event.preventDefault(); 
        console.log('Form submitted');
      };

    return (
      <main className={styles.main}>
        <h1>Enter Details</h1>
        <form className={styles.prospectionform} onSubmit={handleSubmit}>
          {/* Date input */}
          <label htmlFor="date">Select Date:</label>
          <input type="date" id="date" name="date" />
  
          {/* Text area input */}
          <label htmlFor="text">Enter Text:</label>
          <textarea id="text" name="text" rows={4} cols={40} placeholder="Type your text here"></textarea>

          {/* Submit Button */}
        <button type="submit">Submit</button>

        </form>

    
      </main>
    );
  };
  