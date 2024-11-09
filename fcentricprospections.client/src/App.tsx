import { createBrowserRouter, Link, Outlet, RouterProvider } from 'react-router-dom';
import { Homepage } from './pages/Home/homepage';
import { ShopPage, ShopPageContent } from './pages/ShopId/shopIdPage';
import { DataProvider } from './contexts/dataContext';
import styles from './App.module.css'
import { Prospectie } from './pages/ShopNewProspection/shopIdNewProspectionPage';
import { ShopOverview } from './pages/ShopProspectionOverView/shopOverview'
import { ProspectionDetail } from './pages/ProspectionDetail/ProspectionDetail';
import { AiFillHome } from "react-icons/ai";
import { ProspectionDataProvider } from './contexts/ProspectionDataContext';

const Root = () => {
    return (
        <>
            <header className={styles.header}>
                <Link to={"/"}><button className={styles.button}>{<AiFillHome className={styles.home} />}</button></Link>
            </header>

            <Outlet></Outlet>

            <footer className={styles.footer}>

                {/* Footer content can go here */}

            </footer>
        </>
    );
}

const ProspectionPage = () => {

    return (
        <ShopDataProvider>
            <ProspectionDataProvider>
                <Prospectie />
            </ProspectionDataProvider>
        </ShopDataProvider>
    )
}

const ShopPage = () =>{
    return (
        <ShopDataProvider>
            <ShopPageContent/>
        </ShopDataProvider>
    )
}


const App = () => {
    const router = createBrowserRouter([
        {
            path: "/",
            element: <Root />,
            children: [
                {
                    path: "",
                    element: <Homepage />
                },
                {
                    path: 'shop/:id',
                    element: <ShopPageContent />
                },
                {
                    path: "shop/:id/prospection/new",
                    element: <ProspectionPage />
                }
                ,
                {
                    path: "shop/:id/overview",
                    element: <ShopOverview />
                }
                ,
                {
                    path: "shop/:id/overview/:prospectionId",
                    element: <ProspectionDetail />
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