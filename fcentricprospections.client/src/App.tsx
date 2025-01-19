// react utilities
import { useContext } from 'react';
import { createBrowserRouter, Outlet, RouterProvider, useLocation, useNavigate } from 'react-router-dom';
// styles
import styles from './App.module.css'
// contexts
import { ShopDetailProvider } from './contexts/ShopDetailContext';
import { ProspectionDetailProvider } from './contexts/ProspectionDetailContext';
import { UserContext, UserProvider } from './contexts/UserContext';
import { NewShopProvider } from './contexts/NewShopContext';
import { NewProspectionProvider } from './contexts/NewProspectionContext';
// pages
import UserPage from './pages/UserPage/UserPage';
import { Homepage } from './pages/HomePage/HomePage';
import { NewProspection } from './pages/NewProspection/NewProspection';
import { ProspectionOverview } from './pages/ProspectionOverview/ProspectionOverview'
import { ProspectionDetail } from './pages/ProspectionDetail/ProspectionDetail';
import { ShopDetail } from './pages/ShopDetail/ShopDetail';
import { CalendarPage } from './pages/CalendarPage/CalendarPage';
import NewShop from './pages/NewShop/NewShop';
import ErrorPage from './pages/ErrorPage/ErrorPage';
// icons
import { TfiAgenda, TfiArrowLeft, TfiHome } from "react-icons/tfi";
import { ShopListProvider } from './contexts/ShopListContext';
import { useLeaveWarning } from './hooks/useLeaveWarning';

const Root = () => {

    const location = useLocation();
    const navigate = useNavigate();

    const { user } = useContext(UserContext);

    // If we're on the NewProspection or NewShop page, trigger warning before navigating away
    const blockNavigation = useLeaveWarning(
        true && (location.pathname.includes('new')),
        "Niet-opgeslagen wijzigingen zullen verloren gaan. Toch verdergaan?",
    );

    // Handler to navigate with block logic
    const handleNavigation = (to: any) => {
        // If we're on on the NewProspection or NewShop page, block navigation
        if (location.pathname.includes('new')) {
            blockNavigation({ pathname: to });
        } else {
            navigate(to);  // Proceed with navigation
        }
    };

    return (
        <>
            <header className={styles.header}>
                <button title="Home" className={styles.header__button} onClick={() => handleNavigation("/")}>
                    {<TfiHome className={styles.header__icon} />}
                </button>

                {/* Show Agenda button only if user is set */}
                {(user && location.pathname !== "/") && (
                    <button title="Agenda" className={styles.header__button} onClick={() => handleNavigation("/agenda")}>
                        <TfiAgenda className={styles.header__icon} />
                    </button>
                )}

                {/* If location isn't "Home", show "Back" button */}
                {location.pathname !== "/" &&
                    <button title="Terug" className={styles.header__button} onClick={() => handleNavigation(-1)}>
                        {<TfiArrowLeft className={styles.header__icon} />}
                    </button>
                }
            </header>

            <Outlet></Outlet>

            <footer>
                <div></div>
            </footer>
        </>
    );
}

// Page/Provider wrappers

const NewShopPage = () => {
    return (
        <NewProspectionProvider>
            <NewShopProvider>
                <NewShop />
            </NewShopProvider>
        </NewProspectionProvider >
    )
}

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
                    path: "",
                    element: <UserPage />
                },
                {
                    path: "/home",
                    element: <Homepage />
                },
                {
                    path: "/agenda",
                    element: <CalendarPage />
                },
                {
                    path: "newshop",
                    element: <NewShopPage />
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
                },
                {
                    path: "*",
                    element: <ErrorPage />
                }
            ]
        }
    ]);

    return (
        <ShopListProvider>
            <UserProvider>
                <RouterProvider router={router} />
            </UserProvider>
        </ShopListProvider>
    )
}

export default App;