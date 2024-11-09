import { useParams, useLocation, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import {
  IContactType,
  IProspectionDetail,
  IVisitType,
  Prospection,
  Shop,
} from "../../types";
import styles from "./ProspectionDetail.module.css";

export const ProspectionDetail = () => {
  const [loading, setLoading] = useState(true);
  const [prospectionDetail, setProspectionDetail] =
    useState<IProspectionDetail>();
  const [shopDetail, setShopDetail] = useState<Shop>();
  const [contactType, setContactType] = useState<IContactType>();
  const [visitType, setVisitType] = useState<IVisitType>();
  const { shopId, prospectionId } = useParams(); // Extract the IDs from the URL for the prospection as the store
  const navigate = useNavigate();

  // Load prospection detail data
  async function loadProspection(prospectionId: string) {
    try {
      const response = await fetch(`/api/prospections/${prospectionId}`, {
        method: "GET", // Specify the method if it's not 'GET' by default
        headers: {
          "Content-Type": "application/json", // Define the expected content type
        },
      });
      console.log(response);
      const json: IProspectionDetail = await response.json();

      setProspectionDetail(json);
    } catch (error) {
      console.log(error); // to do navigatie naar een error pagina
    }
  }

  // Load shop detail data
  async function loadShopDetail(shopId: string) {
    try {
      const response = await fetch(`/api/shops/${shopId}`, {
        method: "GET", // Specify the method if it's not 'GET' by default
        headers: {
          "Content-Type": "application/json", // Define the expected content type
        },
      });

      const responseProspection = await fetch(
        `/api/shops/${shopId}/prospections`,
        {
          method: "GET", // Specify the method if it's not 'GET' by default
          headers: {
            "Content-Type": "application/json", // Define the expected content type
          },
        }
      );

      if (!response.ok) {
        throw new Error("Failed to fetch shop data");
      }

      const json: Shop = await response.json();
      setShopDetail(json);

      if (!responseProspection.ok) {
        throw new Error("Failed to ftech prospection data");
      }
    } catch (error) {
      console.error("Error fetching shop data:", error);
    }
  }

  // load contactType object by contactTypeId
  async function loadContactType(contactTypeId: string) {
    try {
      const response = await fetch(`/api/contacttypes`, {
        method: "GET", // Specify the method if it's not 'GET' by default
        headers: {
          "Content-Type": "application/json", // Define the expected content type
        },
      });
      console.log(response);
      const json: IContactType[] = await response.json();

      setContactType(json.find((c) => c.id == contactTypeId));
    } catch (error) {
      console.log(error); // to do navigatie naar een error pagina
    }
  }

  // load visitType object by visitTypeId
  async function loadVisitType(visitTypeId: string) {
    try {
      const response = await fetch(`/api/visittypes`, {
        method: "GET", // Specify the method if it's not 'GET' by default
        headers: {
          "Content-Type": "application/json", // Define the expected content type
        },
      });
      console.log(response);
      const json: IVisitType[] = await response.json();

      setVisitType(json.find((v) => v.id == visitTypeId));
    } catch (error) {
      console.log(error); // to do navigatie naar een error pagina
    }
  }

  useEffect(() => {

  });



  // if (!state) {
  //     return <div>Loading...</div>;
  // }
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

// function useState(): [any, any] {
//     throw new Error("Function not implemented.");
// }
