import React, { useState, useEffect } from "react"
import { IBrand, ICompetitorBrand, IContactType, IProspectionBrand, IProspectionBrandInterest, IProspectionCompetitorBrand, IProspectionDetail, IProspectionToDo, IVisitType } from "../types";

interface ProspectionDetailContext {
  prospectionId: string | undefined,
  setProspectionId: (prospectionId: string) => void,
  prospectionDetail: IProspectionDetail | undefined,
  setProspectionDetail: (prospectionDetail: IProspectionDetail) => void,
  brands: IBrand[];
  setBrands: (brands: IBrand[]) => void;
  competitorBrands: ICompetitorBrand[];
  setCompetitorBrands: (competitorBrands: ICompetitorBrand[]) => void;
  contactType: IContactType | undefined,
  setContactType: (contactType: IContactType) => void,
  visitType: IVisitType | undefined,
  setVisitType: (visitType: IVisitType) => void,
  prospectionBrands: IProspectionBrand[],
  setProspectionBrands: (prospectionBrands: IProspectionBrand[]) => void,
  prospectionCompetitorBrands: IProspectionCompetitorBrand[],
  setProspectionCompetitorBrands: (prospectionCompetitorBrands: IProspectionCompetitorBrand[]) => void,
  prospectionBrandInterests: IProspectionBrandInterest[],
  setProspectionBrandInterests: (prospectionBrandInterests: IProspectionBrandInterest[]) => void,
  prospectionToDos: IProspectionToDo[],
  setProspectionToDos: (prospectionToDos: IProspectionToDo[]) => void,
}

export const ProspectionDetailContext = React.createContext<ProspectionDetailContext>({
  prospectionId: "",
  setProspectionId: () => { },
  prospectionDetail: {} as IProspectionDetail | undefined,
  setProspectionDetail: () => { },
  brands: [],
  setBrands: () => { },
  competitorBrands: [],
  setCompetitorBrands: () => { },
  contactType: {} as IContactType | undefined,
  setContactType: () => { },
  visitType: {} as IVisitType | undefined,
  setVisitType: () => { },
  prospectionBrands: [],
  setProspectionBrands: () => { },
  prospectionCompetitorBrands: [],
  setProspectionCompetitorBrands: () => { },
  prospectionBrandInterests: [],
  setProspectionBrandInterests: () => { },
  prospectionToDos: [],
  setProspectionToDos: () => { },
});

export const ProspectionDetailProvider = ({ children }: { children: React.ReactNode }) => {

  // states

  const [prospectionId, setProspectionId] = useState<string>();
  const [prospectionDetail, setProspectionDetail] = useState<IProspectionDetail | undefined>();
  const [contactType, setContactType] = useState<IContactType>();
  const [visitType, setVisitType] = useState<IVisitType>();
  const [brands, setBrands] = useState<IBrand[]>([])
  const [competitorBrands, setCompetitorBrands] = useState<ICompetitorBrand[]>([])
  const [prospectionBrands, setProspectionBrands] = useState<IProspectionBrand[]>([]);
  const [prospectionCompetitorBrands, setProspectionCompetitorBrands] = useState<IProspectionCompetitorBrand[]>([]);
  const [prospectionBrandInterests, setProspectionBrandInterests] = useState<IProspectionBrandInterest[]>([])
  const [prospectionToDos, setProspectionToDos] = useState<IProspectionToDo[]>([])

  // functions

  async function loadProspection(prospectionId: string): Promise<IProspectionDetail> {
    let result: IProspectionDetail = {} as IProspectionDetail;
    try {
      const response = await fetch(`/api/prospections/${prospectionId}`, {
        method: "GET",
        headers: { "Content-Type": "application/json" },
      });

      result = await response.json();
      setProspectionDetail(result);
    } catch (error) {
      console.log("Error fetching prospection data:", error);
    }
    return result;
  }

  async function loadContactType(contactTypeId: number) {
    try {
      const response = await fetch(`/api/contacttypes`, {
        method: "GET",
        headers: { "Content-Type": "application/json" },
      });

      const json: IContactType[] = await response.json();
      let contactType = json.find((c) => c.id == contactTypeId);
      if (contactType != undefined) {
        setContactType(contactType);
      }
    } catch (error) {
      console.log(error);
    }
  }

  async function loadVisitType(visitTypeId: number) {
    try {
      const response = await fetch(`/api/visittypes`, {
        method: "GET",
        headers: { "Content-Type": "application/json" },
      });

      const json: IVisitType[] = await response.json();
      let visitType = json.find((c) => c.id == visitTypeId);
      if (visitType != undefined) {
        setVisitType(visitType);
      }
    } catch (error) {
      console.log(error);
    }
  }

  async function loadProspectionBrands(prospectionId: string) {
    try {
      const response = await fetch(
        `/api/prospections/${prospectionId}/brands`,
        {
          method: "GET",
          headers: { "Content-Type": "application/json" },
        }
      );

      const json: IProspectionBrand[] = await response.json();

      setProspectionBrands(json);
    } catch (error) {
      console.log(error);
    }
  }

  async function loadBrands() {
    try {
      const response = await fetch(`/api/brands`, {
        method: "GET",
        headers: { "Content-Type": "application/json" },
      });

      const result = await response.json();
      setBrands(result);
    } catch (error) {
      console.log(error);
    }
  }

  async function loadProspectionCompetitorBrands(prospectionId: string) {
    try {
      const response = await fetch(
        `/api/prospections/${prospectionId}/competitorbrands`,
        {
          method: "GET",
          headers: { "Content-Type": "application/json" },
        }
      );

      const json: IProspectionCompetitorBrand[] = await response.json();
      setProspectionCompetitorBrands(json);
    } catch (error) {
      console.log(error);
    }
  }

  async function loadCompetitorBrands() {
    let result = [] as ICompetitorBrand[];

    try {
      const response = await fetch(`/api/competitorbrands`, {
        method: "GET",
        headers: { "Content-Type": "application/json" },
      });

      result = await response.json();

      setCompetitorBrands(result);
    } catch (error) {
      console.log(error);
    }
  }

  async function loadProspectionBrandInterests(prospectionId: string) {
    let result: IProspectionBrandInterest[] = [];

    try {
      const response = await fetch(
        `/api/prospections/${prospectionId}/brandinterests`,
        {
          method: "GET",
          headers: { "Content-Type": "application/json" },
        }
      );

      const json: IProspectionBrandInterest[] = await response.json();
      result = json;

      setProspectionBrandInterests(result);

    } catch (error) {
      console.log(error);
    }
  }

  async function loadProspectionToDos(prospectionId: string) {
    try {
      const response = await fetch(
        `/api/prospections/${prospectionId}/todos`,
        {
          method: "GET",
          headers: { "Content-Type": "application/json" },
        }
      );

      const json: IProspectionToDo[] = await response.json();

      setProspectionToDos(json);

    } catch (error) {
      console.log(error);
    }
  }

  useEffect(() => {
    const getAllData = async () => {
      if (prospectionId) {
        let prospectionData = await loadProspection(prospectionId);

        if (prospectionData) {
          await Promise.all([
            loadContactType(prospectionData.contactTypeId),
            loadVisitType(prospectionData.visitTypeId),
            loadBrands(),
            loadCompetitorBrands(),
            loadProspectionBrands(prospectionId),
            loadProspectionCompetitorBrands(prospectionId),
            loadProspectionBrandInterests(prospectionId),
            loadProspectionToDos(prospectionId),
          ])
        }
      }
    };

    getAllData();
  }, [prospectionId]);

  return (
    <ProspectionDetailContext.Provider value={{
      prospectionId: prospectionId,
      setProspectionId: setProspectionId,
      prospectionDetail: prospectionDetail,
      setProspectionDetail: setProspectionDetail,
      brands: brands,
      setBrands: setBrands,
      competitorBrands: competitorBrands,
      setCompetitorBrands: setCompetitorBrands,
      contactType: contactType,
      setContactType: setContactType,
      visitType: visitType,
      setVisitType: setVisitType,
      prospectionBrands: prospectionBrands,
      setProspectionBrands: setProspectionBrands,
      prospectionCompetitorBrands: prospectionCompetitorBrands,
      setProspectionCompetitorBrands: setProspectionCompetitorBrands,
      prospectionBrandInterests: prospectionBrandInterests,
      setProspectionBrandInterests: setProspectionBrandInterests,
      prospectionToDos: prospectionToDos,
      setProspectionToDos: setProspectionToDos,
    }}>
      {children}
    </ProspectionDetailContext.Provider>
  )
}