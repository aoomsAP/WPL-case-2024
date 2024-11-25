import { createBrowserRouter, Link, Outlet, RouterProvider, useLocation, useNavigate } from 'react-router-dom';
import { Homepage } from './pages/HomePage/HomePage';
import { NewProspection } from './pages/NewProspection/NewProspection';
import { ProspectionOverview } from './pages/ProspectionOverview/ProspectionOverview'
import { ProspectionDetail } from './pages/ProspectionDetail/ProspectionDetail';
import { AiFillHome, AiOutlineArrowLeft } from "react-icons/ai";
import { NewProspectionProvider } from './contexts/NewProspectionContext';
import styles from './App.module.css'
import { ShopDetail } from './pages/ShopDetail/ShopDetail';
import { ShopDetailProvider } from './contexts/ShopDetailContext';
import { ProspectionDetailProvider } from './contexts/ProspectionDetailContext';
import { UserProvider } from './contexts/UserContext';
import UserPage from './pages/UserPage/UserPage';

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

// Page/Provider wrappers

const ShopDetailPage = () => {
    return (
        <ShopDetailProvider>
            <ShopDetail />
        </ShopDetailProvider>
    )
}

const ProspectionOverviewPage = () => {
    return (
        <ShopDetailProvider>
            <ProspectionOverview />
        </ShopDetailProvider>
    )
}

const NewProspectionPage = () => {
    return (
        <ShopDetailProvider>
            <NewProspectionProvider>
                <NewProspection />
            </NewProspectionProvider>
        </ShopDetailProvider>
    )
}

const ProspectionDetailPage = () => {
    return (
        <ShopDetailProvider>
            <ProspectionDetailProvider>
                <ProspectionDetail />
            </ProspectionDetailProvider>
        </ShopDetailProvider>
    )
}


const App = () => {
    const router = createBrowserRouter([
        {
            path: "/",
            element: <Root />,
            children: [
                {
                    path : "",
                    element: <UserPage/>
                },
                {
                    path: "/home",
                    element: <Homepage />
                },
                {
                    path: "shop/:shopId",
                    element: <ShopDetailPage />
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
                    element: <ProspectionDetailPage />
                }
            ]
        }
    ]);

    return (
        <UserProvider>
            <RouterProvider router={router} />
        </UserProvider>
    )
}

export default App;