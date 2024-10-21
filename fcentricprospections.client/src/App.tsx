import { createBrowserRouter, Outlet, RouterProvider} from 'react-router-dom';
import { Homepage} from './pages/Home/homepage';
import { ShopPage} from './pages/ShopId/shopIdPage';
import { DataProvider } from './contexts/dataContext';
import styles from './App.module.css'
import { Prospectie } from './pages/ShopNewProspection/shopIdNewProspectionPage';

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



const Page2 = () => {
    return (
        <Prospectie/>
    );
}


const App = () => {
    const router = createBrowserRouter([
        {
            path: "/",
            element: <Root/>,
            children: [
                {
                    path: "",
                    element: <Homepage/>
                },
                {
                    path: 'shop/:id',
                    element: <ShopPage/>
                },
                {
                    path: "shop/:id/new",
                    element: <Prospectie/>
                }
                ,
                {
                    path: "shop/:id/overview",
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