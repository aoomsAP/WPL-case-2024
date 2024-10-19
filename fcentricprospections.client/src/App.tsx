import { createBrowserRouter, Outlet, RouterProvider, useParams } from 'react-router-dom';
import { Homepage} from './pages/homePage';
import { ShopPage} from './pages/shopIdPage';
import { DataProvider } from './contexts/dataContext';
import styles from './App.module.css'

const Root = () => {
    return (
        <>
        <header className={styles.header}></header>

        <Outlet></Outlet>

        <footer className={styles.footer}>

        {/* Footer content can go here */}

        </footer>
        </>
    );
}

const Home =()=> {
    return(
        <>
        <Homepage></Homepage>
        </>
    );
} 

const Page2 = () => {
    return (
        <div>Page 2</div>
    );
}

const Detail = () => {
    const { id } = useParams<{ id: string }>(); // Ensure correct types for TypeScript


    return (
            <ShopPage id={id} />
    );
};


const App = () => {
    const router = createBrowserRouter([
        {
            path: "/",
            element: <Root/>,
            children: [
                {
                    path: "",
                    element: <Home/>
                },
                {
                    path: 'shop/:id',
                    element: <Detail />
                },
                {
                    path: "page2",
                    element: <Page2/>
                }
            ]
        }
    ]);

    return (
        <DataProvider>
            <RouterProvider router={router} />
        </DataProvider>
    )
}

export default App;