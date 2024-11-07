import { useEffect, useState } from 'react';
import styles from './shopIdpage.module.css';
import {Shop, Prospection} from '../../types'
import { Link, useParams } from 'react-router-dom';
import { FaAngleRight } from "react-icons/fa";

export const ShopPage = () => {
  const { id } = useParams<{ id: string }>(); // Ensure correct types for TypeScript
   
  const [shopData , setShopData] = useState<Shop | undefined>(undefined);

  const [shopProspections , setShopProspections] = useState<Prospection[] >([]);

  const LoadShopDetail = async(id : string)=>{

    try {
      const response = await fetch(`/api/shops/${id}`, {
          method: 'GET',  // Specify the method if it's not 'GET' by default
          headers: {
              'Content-Type': 'application/json',  // Define the expected content type                   
          },
      });

      const responseProspection = await fetch(`/api/shops/${id}/prospections`,{
          method: 'GET',  // Specify the method if it's not 'GET' by default
          headers: {
              'Content-Type': 'application/json',  // Define the expected content type                   
          },
      })

      


      if (!response.ok) {
        throw new Error('Failed to fetch shop data');
      }

      const json: Shop = await response.json();
      setShopData(json);

      if(!responseProspection.ok){
        throw new Error('Failed to ftech prospection data')
      }
      const json2: Prospection[] = await responseProspection.json();
      setShopProspections(json2)

      
  }catch (error) {
    console.error('Error fetching shop data:', error);
  }}

  useEffect(()=>{
    if(id)
    LoadShopDetail(id);

  },[id])




  return (
    <>
      <main className={styles.main}>
       <section className={styles.infoSection}>

        <h1 className={styles.h1}>{shopData?.name}</h1>

        <h2>Adres: {shopData?.address.street1} </h2>

        <h2>Klant: {shopData?.customer}</h2>

       </section>

        <section className={styles.prospectionSection}>
        <button className={styles.button}>
          <Link className={styles.a} to={`/shop/${id}/new`}>Nieuwe Prospectie</Link>
        </button>
        <ul>
          {shopProspections.map(prospection => (<li className={styles.li}  key={prospection.id}>  {/* Ensure each `li` has a unique `key` */}
                            <Link className={styles.prospectionA} to={`/shop/${id}/overview/prospection${prospection.id}`}>Prospectie {prospection.date.slice(0,10)}<FaAngleRight className={styles.icon} /> </Link></li>))}
        </ul>
        <button className={styles.button}>
          <Link className={styles.a} to={`/shop/${id}/overview`}>Overzicht van alle Prospecties</Link>
        </button>
        </section>
       
      </main>
    </>
  );
};

