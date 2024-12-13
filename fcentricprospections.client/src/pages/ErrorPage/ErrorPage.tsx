import { useContext } from "react";
import { UserContext } from "../../contexts/UserContext";


const ErrorPage = () => {

    const {}= useContext(UserContext);
   

    return(
        <main>
        <section>Oeps iets ging mis</section>
        
        </main>
    );
}

export default ErrorPage;

