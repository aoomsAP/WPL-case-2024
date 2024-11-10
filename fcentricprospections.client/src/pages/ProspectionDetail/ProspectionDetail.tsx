import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import {
  IBrand,
  ICompetitorBrand,
  IContactType,
  IProspectionBrand,
  IProspectionBrandInterest,
  IProspectionCompetitorBrand,
  IProspectionDetail,
  IVisitType,
  Shop,
} from "../../types";
import styles from "./ProspectionDetail.module.css";
import { ShopDetailCard } from "../../components/ShopDetailCard/ShopDetailCards";
import { ContactTypeCard } from "../../components/ContactTypeCard/ContactTypeCard";
import { VisitTypeCard } from "../../components/VisitTypeCard/VisitTypeCard";
import { GeneralSituation } from "../../components/GeneralSituationCard/GeneralSituationCard";
import { BrandList } from "../../components/BrandList/BrandList";
import { TextSection } from "../../components/TextSection/TextSection";
import { CompetitorBrandList } from "../../components/CompetitorBrandList/CompetitorBrandList";
import { BrandInterestList } from "../../components/BrandInterestList/BrandInterestList";

export const ProspectionDetail = () => {
  const [prospectionDetail, setProspectionDetail] = useState<IProspectionDetail>();
  const [shopDetail, setShopDetail] = useState<Shop>();
  const [contactType, setContactType] = useState<IContactType>();
  const [visitType, setVisitType] = useState<IVisitType>();
  const [prospectionBrands, setProspectionBrands] = useState<IProspectionBrand[]>([]);
  const [prospectionCompetitorBrands, setProspectionCompetitorBrands] = useState<IProspectionCompetitorBrand[]>([]);
  const [brands, setBrands] = useState<IBrand[]>([])
  const [competitorBrands, setCompetitorBrands] = useState<ICompetitorBrand[]>([])
  const [prospectionBrandInterests, setProspectionBrandInterests] = useState<IProspectionBrandInterest[]>([])
  const { shopId, prospectionId } = useParams(); // Extract the IDs from the URL for the prospection as the store

  async function loadProspection(prospectionId: string): Promise<IProspectionDetail> {
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

  async function loadShopDetail(shopId: string): Promise<Shop> {
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

  async function loadContactType(contactTypeId: string): Promise<IContactType> {
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

  async function loadVisitType(visitTypeId: string): Promise<IVisitType> {
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

  async function loadProspectionBrands(prospectionId: string): Promise<IProspectionBrand[]> {
    let result: IProspectionBrand[] = [];

    try {
      const response = await fetch(
        `/api/prospections/${prospectionId}/brands`,
        {
          method: "GET", // Specify the method if it's not 'GET' by default
          headers: {
            "Content-Type": "application/json", // Define the expected content type
          },
        }
      );

      const json: IProspectionBrand[] = await response.json();
      result = json;
    } catch (error) {
      console.log(error);
    }

    return result;
  }

  async function loadBrands(): Promise<IBrand[]> {
    let result = [] as IBrand[];

    try {
      const response = await fetch(`/api/brands`, {
        method: "GET", // Specify the method if it's not 'GET' by default
        headers: {
          "Content-Type": "application/json", // Define the expected content type
        },
      });

      result = await response.json();
    } catch (error) {
      console.log(error);
    }
    return result;
  }

  async function loadProspectionCompetitorBrands(prospectionId: string): Promise<IProspectionCompetitorBrand[]> {
    let result: IProspectionCompetitorBrand[] = [];

    try {
      const response = await fetch(
        `/api/prospections/${prospectionId}/competitorbrands`,
        {
          method: "GET", // Specify the method if it's not 'GET' by default
          headers: {
            "Content-Type": "application/json", // Define the expected content type
          },
        }
      );

      const json: IProspectionCompetitorBrand[] = await response.json();
      result = json;
    } catch (error) {
      console.log(error);
    }
    return result;
  }

  async function loadCompetitorBrands(): Promise<ICompetitorBrand[]> {
    let result = [] as ICompetitorBrand[];

    try {
      const response = await fetch(`/api/competitorbrands`, {
        method: "GET", // Specify the method if it's not 'GET' by default
        headers: {
          "Content-Type": "application/json", // Define the expected content type
        },
      });

      result = await response.json();
    } catch (error) {
      console.log(error);
    }
    return result;
  }

  async function loadProspectionBrandInterests(prospectionId: string): Promise<IProspectionBrandInterest[]> {
    let result: IProspectionBrandInterest[] = [];

    try {
      const response = await fetch(
        `/api/prospections/${prospectionId}/brandinterests`,
        {
          method: "GET", // Specify the method if it's not 'GET' by default
          headers: {
            "Content-Type": "application/json", // Define the expected content type
          },
        }
      );

      const json: IProspectionBrandInterest[] = await response.json();
      result = json;
    } catch (error) {
      console.log(error);
    }

    return result;
  }

  useEffect(() => {
    const getAllData = async () => {
      if (prospectionId && shopId) {
        let [prospectionData, shopData] = await Promise.all([
          loadProspection(prospectionId),
          loadShopDetail(shopId),
        ]);

        if (prospectionData) {
          let [contactTypeData,visitTypeData,prospectionBrandsData,prospectionCompetitorBrandsData,brandsData,competitorBrandsData,prospectionBrandInterestData] = await Promise.all([
            loadContactType(prospectionData.contactPersonTypeId),
            loadVisitType(prospectionData.visitTypeId),
            loadProspectionBrands(prospectionId),
            loadProspectionCompetitorBrands(prospectionId),
            loadBrands(),
            loadCompetitorBrands(),
            loadProspectionBrandInterests(prospectionId)
          ]);

          setProspectionDetail(prospectionData);
          setShopDetail(shopData);
          setContactType(contactTypeData);
          setVisitType(visitTypeData);
          setProspectionBrands(prospectionBrandsData);
          setProspectionCompetitorBrands(prospectionCompetitorBrandsData);
          setBrands(brandsData);
          setCompetitorBrands(competitorBrandsData);
          setProspectionBrandInterests(prospectionBrandInterestData);
        }
      }
    };

    getAllData();
  }, []);

  return (
    <main className={styles.main}>
      <h1 className={styles.h1}>
        Prospectie ({prospectionDetail?.date.slice(0, 10)})
      </h1>

      {shopDetail && <ShopDetailCard shop={shopDetail} />}
      
      {contactType && prospectionDetail && (
        <ContactTypeCard contactType={contactType} contactPersonName={prospectionDetail.contactPersonName} />
      )}
      
      {visitType && prospectionDetail && <VisitTypeCard visitType={visitType} visitContext={prospectionDetail?.visitContext} />}
      
      <BrandList prospectionBrands={prospectionBrands} brands={brands}/>
      
      <CompetitorBrandList prospectionCompetitorBrands={prospectionCompetitorBrands} brands={competitorBrands} />

      {prospectionDetail && <GeneralSituation detail={prospectionDetail} />}

      <BrandInterestList prospectionBrandInterests={prospectionBrandInterests} brands={brands} />

      <TextSection title="Trends & Noden" text={prospectionDetail?.trends} />
      <TextSection title="Extra Opmerkingen/Feedback" text={prospectionDetail?.extra} />
    </main>
  );
};
