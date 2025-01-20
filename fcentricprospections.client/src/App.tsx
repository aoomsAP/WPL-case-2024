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
import { ShopListProvider } from './contexts/ShopListContext';
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
import { RxExit } from "react-icons/rx";
// components
import Breadcrumbs from './components/Breadcrumbs/Breadcrumbs';

const Root = () => {

    const location = useLocation();
    const navigate = useNavigate();

    const { user, setUserId } = useContext(UserContext);

    return (
        <>
            <header className={styles.header}>
                <nav className={styles.nav}>
                    <button title="Home" className={styles.nav__button} onClick={() => navigate("/home")}>
                        {<TfiHome className={styles.nav__icon} />}
                    </button>

                    {/* Show Agenda button only if user is set */}
                    {(user && location.pathname !== "/") && (
                        <button title="Agenda" className={styles.nav__button} onClick={() => navigate("/agenda")}>
                            <TfiAgenda className={styles.nav__icon} />
                        </button>
                    )}

                    {/* If location isn't "Home", show "Back" button */}
                    {location.pathname !== "/" &&
                        <button title="Terug" className={styles.nav__button} onClick={() => navigate(-1)}>
                            {<TfiArrowLeft className={styles.nav__icon} />}
                        </button>
                    }

                    {/* Logout */}
                    {user &&
                        <button
                            title="Logout"
                            className={`${styles.nav__icon} ${styles.logout}`}
                            onClick={() => {
                                setUserId(undefined);
                                setTimeout(() => navigate("/"), 0);
                            }}
                        >
                            {<RxExit className={styles.nav__icon} />}
                        </button>
                    }
                </nav>

                <Breadcrumbs />
            </header>

            <Outlet></Outlet>

            <footer>
                <div></div>
            </footer>
        </>
    );
}

const ShopWrapper = () => {
    return <Outlet />;
};

const App = () => {
    const router = createBrowserRouter([
        {
            path: "/",
            element: <Root />,
            children: [
                {
                    path: "/",
                    index: true,
                    element: <UserPage />,
                },
                {
                    path: "/home",
                    element: <Homepage />,
                },
                {
                    path: "/agenda",
                    element: <CalendarPage />,
                },
                {
                    path: "/shop",
                    element: <ShopWrapper />, // Empty fallback for /shop
                    children: [
                        {
                            path: "new",
                            element:
                                <NewProspectionProvider>
                                    <NewShopProvider>
                                        <NewShop />
                                    </NewShopProvider>
                                </NewProspectionProvider >,
                        },
                        {
                            path: ":shopId",
                            element:
                                <ShopDetailProvider>
                                    <Outlet />
                                </ShopDetailProvider>,
                            children: [
                                {
                                    index: true,
                                    element: <ShopDetail />,
                                },
                                {
                                    path: "prospections",
                                    element: <Outlet />,
                                    children: [
                                        {
                                            index: true,
                                            element: <ProspectionOverview />
                                        },
                                        {
                                            path: "new",
                                            element:
                                                <NewProspectionProvider>
                                                    <NewProspection />
                                                </NewProspectionProvider>
                                        },
                                        {
                                            path: ":prospectionId",
                                            element:
                                                <ProspectionDetailProvider>
                                                    <ProspectionDetail />
                                                </ProspectionDetailProvider>
                                        },
                                    ]
                                }
                            ]
                        }
                    ]
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