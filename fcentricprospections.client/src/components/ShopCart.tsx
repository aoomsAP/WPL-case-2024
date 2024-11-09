import { Shop } from "../types";


interface ShopCartProps{
    data: Shop;
}

const ShopCart = ({data} : ShopCartProps) =>{
   
    


    return(
        <>
        <p>{data.name}</p>
        <p>{data.customer}</p>
        <p>{data.address.street1}</p>
        </>
    )
}


export default ShopCart;