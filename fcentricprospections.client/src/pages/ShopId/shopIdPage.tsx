import { useEffect, useState } from 'react';
import styles from './shopIdpage.module.css';
import {Shop} from '../../types'
import { Link, useParams } from 'react-router-dom';

export const ShopPage = () => {
  const { id } = useParams<{ id: string }>(); // Ensure correct types for TypeScript
   
  const [shopData , setShopData] = useState<Shop>();

  useEffect(()=>{

    setShopData(dummyData.find((data)=> data.id === id ))

  },[id])




  return (
    <>
      <main className={styles.main}>
        <h1>{shopData?.shopName}</h1>
        <h2>Adres: {shopData?.address} </h2>
        <h2>Naam van de klant: {shopData?.customerName}</h2>
        <button key={id}>
          <Link to={`/shop/${id}/new`}>Nieuwe prospectie</Link>
        </button>

      </main>
    </>
  );
};




/* Temporary Code */

  
  const dummyData: Shop[] = [
    { id: '1', shopName: 'Coffee Shop', address: '123 Coffee Lane', customerName: 'Alice Smith' },
    { id: '2', shopName: 'Bookstore', address: '456 Book Ave', customerName: 'Bob Johnson' },
    { id: '3', shopName: 'Grocery Store', address: '789 Grocery Blvd', customerName: 'Charlie Davis' },
    { id: '4', shopName: 'Clothing Boutique', address: '101 Fashion St', customerName: 'Diana Moore' },
    { id: '5', shopName: 'Electronics Store', address: '202 Tech Park', customerName: 'Eve Turner' },
    { id: '6', shopName: 'Flower Shop', address: '303 Blooming Rd', customerName: 'Frank White' },
    { id: '7', shopName: 'Music Store', address: '404 Melody Ave', customerName: 'Grace Hill' },
    { id: '8', shopName: 'Hardware Store', address: '505 Builder St', customerName: 'Henry King' },
    { id: '9', shopName: 'Jewelry Store', address: '606 Gemstone Blvd', customerName: 'Ivy Carter' },
    { id: '10', shopName: 'Art Gallery', address: '707 Canvas Lane', customerName: 'Jack Lee' },
  ];
  
