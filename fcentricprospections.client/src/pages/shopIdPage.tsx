

interface ShopPageProps {
    id: string | undefined; // The id will be passed as a number
}

 export const ShopPage = ({ id }: ShopPageProps) =>{
    
    return(
        <>
            <li>{id}</li>
        </>
    );
}