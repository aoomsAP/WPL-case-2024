import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import {
  IContactType,
  IProspectionDetail,
  IVisitType,
  Shop,
} from "../../types";
import styles from "./ProspectionDetail.module.css";

export const ProspectionDetail = () => {
  const [prospectionDetail, setProspectionDetail] = useState<IProspectionDetail>();
  const [shopDetail, setShopDetail] = useState<Shop>();
  const [contactType, setContactType] = useState<IContactType>();
  const [visitType, setVisitType] = useState<IVisitType>();
  const { shopId, prospectionId } = useParams(); // Extract the IDs from the URL for the prospection as the store



async function loadProspection(prospectionId: string):Promise<IProspectionDetail> {
    let result: IProspectionDetail = {} as IProspectionDetail;
    try {
      const response = await fetch(`/api/prospections/${prospectionId}`, {
        method: "GET", // Specify the method if it's not 'GET' by default
        headers: {
          "Content-Type": "application/json", // Define the expected content type
        },
      });

     result = await response.json();
      
    } catch (error) {
      console.log("Error fetching prospection data:", error);
    }

    return result;
  }

async function loadShopDetail(shopId: string):Promise<Shop> {

    let result = {} as Shop;

    try {
      const response = await fetch(`/api/shops/${shopId}`, {
        method: "GET", // Specify the method if it's not 'GET' by default
        headers: {
          "Content-Type": "application/json", // Define the expected content type
        },
      });

      const json: Shop = await response.json();
      result = json;

    } catch (error) {
      console.error("Error fetching shop data:", error);
    }

    return result;
  }

  async function loadContactType(contactTypeId: string):Promise<IContactType> {
    let result = {} as IContactType;

    try {
      const response = await fetch(`/api/contacttypes`, {
        method: "GET", // Specify the method if it's not 'GET' by default
        headers: {
          "Content-Type": "application/json", // Define the expected content type
        },
      });

      const json: IContactType[] = await response.json();
        let contantType = json.find((c) => c.id == contactTypeId);
      if (contantType != undefined) {
        result = contantType;
      }
        

    } catch (error) {
      console.log(error);
    }

    return result;
  }


async function loadVisitType(visitTypeId: string):Promise<IVisitType> {
    let result = {} as IVisitType;

    try {
      const response = await fetch(`/api/visittypes`, {
        method: "GET", // Specify the method if it's not 'GET' by default
        headers: {
          "Content-Type": "application/json", // Define the expected content type
        },
      });

      const json: IVisitType[] = await response.json();
        let visitType = json.find((c) => c.id == visitTypeId);
      if (visitType != undefined) {
        result = visitType;
      }
    } catch (error) {
      console.log(error);
    }

    return result;
  }

  useEffect(() => {
   
    const getAllData = async () => {
        if(prospectionId && shopId) {
       
            let [result1, result2] = await Promise.all([loadProspection(prospectionId), loadShopDetail(shopId)])

            if (result1) {
                let [result3, result4] = await Promise.all([loadContactType(result1.contactPersonTypeId), loadVisitType(result1.visitTypeId)])
                
                setProspectionDetail(result1);
                setShopDetail(result2);
                setContactType(result3);
                setVisitType(result4);
            }
         
        }
    }
     
    getAllData();
    

  }, []);


  console.log(prospectionDetail);

  return (
    <main className={styles.main}>
      <h1 className={styles.h1}>Prospection Details</h1>
      <h2>Winkel: {shopDetail?.name}</h2>
      <p>Klant: {shopDetail?.customer}</p>
      <p>Adres: {shopDetail?.address.street1}</p>
      <section className={styles.section}>
        <h3>Contact Type:</h3>
        <p>{contactType?.name}</p>
        <p>Gesprekspartner:{prospectionDetail?.contactPersonName}</p>
        <h3>Visit Type:</h3>
        <p>{visitType?.name}</p>
      </section>
    </main>
  );
};


