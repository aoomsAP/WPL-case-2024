import { createBrowserRouter, Outlet, RouterProvider } from 'react-router-dom';
import { Homepage } from './pages/homepage';
import { DataProvider } from './contexts/dataContext';

const Root = () => {
    return (
        <>
        <Outlet></Outlet>
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
const Page1 = () => {
    return (
        <div>Page 1</div>
    );
}

const Page2 = () => {
    return (
        <div>Page 2</div>
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
                    element: <Home/>
                },
                {
                    path: "page1",
                    element: <Page1/>
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