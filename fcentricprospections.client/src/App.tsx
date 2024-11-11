import { createBrowserRouter, Link, Outlet, RouterProvider, useLocation, useNavigate } from 'react-router-dom';
import { Homepage } from './pages/Home/homepage';
import { ShopListProvider } from './contexts/ShopListContext';
import { NewProspection } from './pages/NewProspection/NewProspection';
import { ProspectionOverview } from './pages/ProspectionOverview/ProspectionOverview'
import { ProspectionDetail } from './pages/ProspectionDetail/ProspectionDetail';
import { AiFillHome, AiOutlineArrowLeft } from "react-icons/ai";
import { ProspectionDataProvider } from './contexts/ProspectionDataContext';
import styles from './App.module.css'
import { ShopPage } from './pages/ShopPage/ShopPage';

const Root = () => {

    const location = useLocation();
    const navigate = useNavigate();

    return (
        <>
            <header className={styles.header}>
                <Link to={"/"}>
                    <button className={styles.button}>
                        {<AiFillHome className={styles.homeIcon} />}
                    </button>
                </Link>

                {/* If location isn't "Home", show "Back" button */}
                {location.pathname !== "/" &&
                    <button title="Back" className={styles.button} onClick={() => navigate(-1)}>
                        {<AiOutlineArrowLeft className={styles.homeIcon} />}
                    </button>
                }
            </header>

            <Outlet></Outlet>

            <footer className={styles.footer}>

                {/* Footer content can go here */}

            </footer>
        </>
    );
}

// Extra layer to wrap in prospection data context
const NewProspectionPage = () => {

    return (
        <ProspectionDataProvider>
            <NewProspection />
        </ProspectionDataProvider>
    )
}

// Extra layer to wrap in prospection data context
const ProspectionOverviewPage = () => {
    return (
        <ProspectionDataProvider>
            <ProspectionOverview/>
        </ProspectionDataProvider>
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
                    path: "shop/:shopId",
                    element: <ShopPage />
                },
                {
                    path: "shop/:shopId/prospections/new",
                    element: <NewProspectionPage />
                },
                {
                    path: "shop/:shopId/prospections",
                    element: <ProspectionOverviewPage />
                },
                {
                    path: "shop/:shopId/prospections/:prospectionId",
                    element: <ProspectionDetail />
                }
            ]
        }
    ]);

    return (
        <ShopListProvider>
            <RouterProvider router={router} />
        </ShopListProvider>
    )
}

export default App;