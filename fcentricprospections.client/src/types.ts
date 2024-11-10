export interface IShop {
  id: string; // Example property, replace with real ones
  name: string; // Example property
}

export interface Address {
  id: number;
  street1: string;
  street2: string;
  postalcode: string;
  city: string;
  country: string;
}

export interface Shop {
  id: number;
  name: string;
  address: Address;
  customer: string;
}

export interface Prospection {
  id: string;
  data: string;
  text: string;
  date: string;
}

export interface IProspectionDetail {
  id: string;
  shopId: number;
  userId: number;
  date: string;
  dateLastUpdated: string;
  contactPersonTypeId: string;
  contactPersonName: string;
  visitTypeId: string;
  visitContext: string;
  bestBrands: string;
  worstBrands: string;
  brandsOut: string;
  trends: string;
  extra: string;
}

export interface Shop2 {
  id: string;
  shopName: string;
  prospections: Prospection[];
}

export interface IContactType {
  id: string;
  name: string;
}

export interface IVisitType {
  id: string;
  name: string;
}

export interface IProspectionBrand {
  id: string;
  prospectionId: string;
  brandId: string;
  sellout: number;
  salesRepresentative: string;
  commercialSupport: string;
}

export interface IProspectionCompetitorBrand {
 id: string;
 prospectionId: string;
 competitorBrandId: string;
}

export interface IProspectionBrandInterest {
  id: string;
  prospectionId: string;
  brandId: string;
  sales: string
}

export interface IBrand {
  id: string;
  name: string;
}

export interface ICompetitorBrand {
  id: string;
  name: string;
}

export interface IProspectionBrandInterest {
  id: string;
  name: string;

}