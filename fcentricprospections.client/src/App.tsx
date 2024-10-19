import { createBrowserRouter, Outlet, RouterProvider, useParams } from 'react-router-dom';
import { Homepage} from './pages/homepage';
import { ShopPage} from './pages/shopidpage';
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

const Page2 = () => {
    return (
        <div>Page 2</div>
    );
}

const Detail = () => {
    
    let { id } = useParams();
    return (
        <ShopPage id={id} />
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
                    path: "detail/:id",
                    element: <Detail/>
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