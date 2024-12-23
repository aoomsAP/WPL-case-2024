import { useContext } from "react";
import { UserContext } from "../../contexts/UserContext";

const ErrorPage = () => {

    const { } = useContext(UserContext);

    return (
        <main>
            <section>Oeps, er ging iets mis.</section>

        </main>
    );
}

export default ErrorPage;

