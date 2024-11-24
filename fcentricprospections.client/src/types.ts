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
  employeeId?: number,
  date: Date,
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
  brandId: number,
  brandName: string,
}

export interface IProspectionBrandInterest {
  id?: number,
  brandId: number,
  brandName: string,
  remark?: string,
}

export interface IToDo {
  id?: number,
  remarks?: string,
  employeeId?: number,
  ToDoStatusId?: number,
  toDoStatus?: string,
  name?: string,
}

export interface IProspectionToDo {
  id?: number,
  prospectionId: number,
  toDoId: number,
  remarks?: string,
  employeeId?: number,
  ToDoStatusId?: number,
  toDoStatus?: string,
  name?: string,
}