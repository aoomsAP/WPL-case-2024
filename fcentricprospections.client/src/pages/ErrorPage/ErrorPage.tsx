import { useContext } from "react";
import { UserContext } from "../../contexts/UserContext";

const ErrorPage = () => {

    const { } = useContext(UserContext);

    return (
        <main>
            <h1>Fout</h1>
            <section>
                <p>Oeps, er ging iets mis. Probeer opnieuw in te loggen of probeer het later opnieuw.</p>
            </section>
        </main>
    );
}

export default ErrorPage;

