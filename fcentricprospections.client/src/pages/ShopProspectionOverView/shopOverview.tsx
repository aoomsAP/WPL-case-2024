import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import styles from './shopOverview.module.css'
import { Shop2 } from "../../types";


export const ShopOverview = () => {

    const { id} = useParams<{id : string}>();  

    const [prospectieList , setProspectieList] = useState<Shop2>();

    useEffect(() => {
        setProspectieList(dummyData.find((data) => data.id === id));
        /*Doe een call om de voorgaande prospecties op te halen*/ 
    }, [id])

    return(
        <main className={styles.main}>
        <h1>{prospectieList?.shopName}</h1>

        <h2>Voorgaande prospecties</h2>

        <section className={styles.section}>
                {prospectieList?.prospections.map((item) => (
                    <button key={`${prospectieList.id}-${item.id}`}>
                        <Link 
                            to={`/shop/${id}/overview/prospection${item.id}`} 
                            state={{ prospection: item, shopName: prospectieList.shopName }}
                        >
                            {item.data}
                        </Link>
                    </button>
                ))}
            </section>
        
    
        </main>
    );
}

/* Temporary Code */
  
const dummyData: Shop2[] = [
    {
      id: '1',
      shopName: 'Coffee Shop',
      prospections: [
        { id: '1', data: '2024-01-10', text: 'Prospection about new coffee beans supplier.' },
        { id: '2', data: '2024-02-15', text: 'Evaluated potential partnership with local bakery.' }
      ]
    },
    {
      id: '2',
      shopName: 'Bookstore',
      prospections: [
        { id: '1', data: '2024-03-01', text: 'Reviewed book distributor contracts.' },
        { id: '2', data: '2024-03-20', text: 'Prospected new reading event collaborations.' }
      ]
    },
    {
      id: '3',
      shopName: 'Grocery Store',
      prospections: [
        { id: '1', data: '2024-04-12', text: 'Sourced organic vegetable suppliers.' },
        { id: '2', data: '2024-05-05', text: 'Explored partnership with local farms.' }
      ]
    },
    {
      id: '4',
      shopName: 'Clothing Boutique',
      prospections: [
        { id: '1', data: '2024-06-08', text: 'Reached out to fashion designers for collaboration.' },
        { id: '2', data: '2024-06-25', text: 'Prospected new sustainable fabric vendors.' }
      ]
    },
    {
      id: '5',
      shopName: 'Electronics Store',
      prospections: [
        { id: '1', data: '2024-07-10', text: 'Explored new gadget distribution deals.' },
        { id: '2', data: '2024-07-22', text: 'Evaluated inventory management software.' }
      ]
    },
    {
      id: '6',
      shopName: 'Flower Shop',
      prospections: [
        { id: '1', data: '2024-08-14', text: 'Reviewed floral supplier offers.' },
        { id: '2', data: '2024-09-01', text: 'Prospected for wedding event collaborations.' }
      ]
    },
    {
      id: '7',
      shopName: 'Music Store',
      prospections: [
        { id: '1', data: '2024-09-18', text: 'Sourced new instruments from manufacturers.' },
        { id: '2', data: '2024-10-02', text: 'Contacted local artists for in-store performances.' }
      ]
    },
    {
      id: '8',
      shopName: 'Hardware Store',
      prospections: [
        { id: '1', data: '2024-10-05', text: 'Evaluated tool supplier pricing.' },
        { id: '2', data: '2024-10-20', text: 'Explored partnerships with home improvement contractors.' }
      ]
    },
    {
      id: '9',
      shopName: 'Jewelry Store',
      prospections: [
        { id: '1', data: '2024-11-01', text: 'Reviewed gem suppliers for new collection.' },
        { id: '2', data: '2024-11-10', text: 'Prospected luxury brand partnerships.' }
      ]
    },
    {
      id: '10',
      shopName: 'Art Gallery',
      prospections: [
        { id: '1', data: '2024-12-05', text: 'Contacted artists for upcoming exhibition.' },
        { id: '2', data: '2024-12-20', text: 'Explored collaboration with museums for artwork loans.' }
      ]
    }
  ];