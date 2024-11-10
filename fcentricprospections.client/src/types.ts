
export interface IShop {
  id: string; // Example property, replace with real ones
  name: string; // Example property
}

export interface Address {
  id: number,
  street1: string,
  street2: string,
  postalcode: string,
  city: string,
  country: string,
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
  date: string
}
export interface Shop2 {
  id: string,
  shopName: string,
  prospections: Prospection[]
}




export interface IContactType {
  id: number,
  name: string,
}

export interface IVisitType {
  id: number,
  name: string,
}

export interface IBrand {
  id: number,
  name: string,
}

export interface ICompetitorBrand {
  id: number,
  name: string,
}

export interface IProspection {
  id?: number,
  shopId: number,
  userId?: number,
  date?: Date,
  dateLastUpdated?: Date,
  contactPersonTypeId?: number,
  contactPersonName?: string,
  visitTypeId?: number,
  visitContext?: string,
  bestBrands?: string,
  worstBrands?: string,
  brandsOut?: string,
  trends?: string,
  extra?: string
}

export interface IProspectionBrand {
  id?: number,
  brandId: number,
  brandName: string,
  sellout?: number,
  salesRepresentative?: string,
  commercialSupport?: string,
}

export interface IProspectionCompetitorBrand {
  id?: number,
  brandId: number,
  brandName: string,
}

export interface IProspectionBrandInterest {
  id?: number,
  brandId: number,
  brandName: string,
  sales?: string,
}