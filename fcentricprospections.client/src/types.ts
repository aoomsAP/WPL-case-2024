export interface IShop {
  id: string; // Example property, replace with real ones
  name: string; // Example property
}

export interface IShopDetail {
  id: number;
  name: string;
  address: Address;
  customer: string;
}

export interface Address {
  id: number;
  street1: string;
  street2: string;
  postalcode: string;
  city: string;
  country: string;
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
  id: number,
  date: Date,
  shopId: number,
}

export interface IProspectionDetail {
  id?: number,
  shopId: number,
  userId?: number,
  date: Date,
  dateLastUpdated?: Date,
  contactPersonTypeId: number,
  contactPersonName?: string,
  visitTypeId: number,
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

export interface IUser{
  id : string,
  login : string,
  blocked :  boolean,  
}

export interface IEmployee{
  id : string,
  firstName :  string,
  userId? : string,
  hideForAgenda :  boolean,
  name : string,
  dateCreated : Date,
}

export interface IAppointment{
  id : string,
  startDate : Date,
  endDate : Date,
  appointmentState : string,
  name : string,
  employeeId : number
}
