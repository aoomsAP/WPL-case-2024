export interface IShop {
  id: string; // Example property, replace with real ones
  name: string; // Example property
  city: string;
}

export interface IShopDetail {
  id: number;
  name: string;
  address: Address;
  customer: string;
  owner: string;
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
  visitDate: Date,
  shopId: number,
}

export interface IProspectionDetail {
  id?: number,
  shopId: number,
  userId?: number,
  employeeId?: number,
  visitDate: Date,
  dateCreated?: Date,
  dateLastUpdated?: Date,
  contactTypeId: number,
  contactName?: string,
  contactEmail?: string,
  contactPhone?: string,
  visitTypeId: number,
  visitContext?: string,
  newBrands?: string,
  bestBrands?: string,
  worstBrands?: string,
  terminatedBrands?: string,
  trends?: string,
  extra?: string
}

export interface IProspectionBrand {
  id?: number,
  brandId: number,
  brandName: string,
  sellout?: number,
  selloutRemark?: string,
}

export interface IProspectionCompetitorBrand {
  id?: number,
  competitorBrandId: number,
  competitorBrandName: string,
}

export interface IProspectionBrandInterest {
  id?: number,
  brandId: number,
  brandName: string,
  remark?: string,
}

export interface IUser {
  id : string,
  login : string,
  blocked :  boolean,  
}

export interface IEmployee {
  id : string,
  firstName :  string,
  userId? : string,
  hideForAgenda :  boolean,
  name : string,
  dateCreated : Date,
}

export interface IAppointment {
  id : string,
  startDate : Date,
  endDate : Date,
  appointmentState : string,
  name : string,
  employeeId : number
  remarks?: string,
}

export interface IToDo {
  id?: number,
  remarks?: string,
  employeeId?: number,
  employeeName?: string,
  toDoStatusId?: number,
  toDoStatus?: string,
  name?: string,
  dateCreated?: Date,
  userCreatedId?: number,
}

export interface IProspectionToDo {
  id?: number,
  prospectionId: number,
  toDoId: number,
  remarks?: string,
  employeeId?: number,
  toDoStatusId?: number,
  toDoStatus?: string,
  name?: string,
}

export type OptionType = {
  label: string
  value: string
}