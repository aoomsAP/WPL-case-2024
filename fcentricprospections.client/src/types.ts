export interface IShop {
  id: number;
  name: string;
  city: string;
}

export interface IShopDetail {
  id: number;
  name: string;
  address: IAddress;
  customer: string;
  owner: string;
  shopTypeId: number,
}

export interface IAddress {
  id: number;
  street1: string;
  street2?: string;
  postalcode?: string;
  city: string;
  country: string;
}

export interface ICountry {
  id: number,
  name: string,
}

export interface ICity {
  id: number,
  name: string,
  postalCode: string,
  countryId: number,
}

export interface IAddressCreate {
  id?: number;
  street1: string;
  street2?: string;
  postalCode?: string;
  cityId: number;
  userCreatedId: number,
  dateCreated: Date,
}

export interface IContactCreate {
  id?: number;
  addressId: number,
  name?: string,
  userCreatedId: number,
  dateCreated: Date,
}

export interface IShopCreate {
  id?: number;
  name?: string,
  userCreatedId: number,
  dateCreated: Date,
  isParallelSales: boolean,
  contactId: number,
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
  userCreatedId?: number,
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
  id: number,
  login: string,
  blocked: boolean,
}

export interface IEmployee {
  id: number,
  firstName?: string,
  userId?: number,
  hideForAgenda?: boolean,
  name: string,
  dateCreated?: Date,
}

export interface IAppointment {
  id: number,
  startDate: Date,
  endDate: Date,
  appointmentState: string,
  name: string,
  employeeId: number
  remarks?: string,
}

export interface IToDo {
  id?: number | string,
  remarks?: string,
  employees?: IEmployee[],
  toDoStatusId?: number,
  toDoStatus?: string,
  toDoTypeId?: number,
  toDoType?: string,
  name?: string,
  dateCreated?: Date,
  userCreatedId?: number,
}

export interface IToDoEmployee {
  id?: number,
  toDoId: number | string,
  employeeId: number,
  name?: string,
}

export interface IProspectionToDo {
  id?: number | string,
  prospectionId: number,
  toDoId: number | string,
  remarks?: string,
  toDoStatusId?: number,
  toDoStatus?: string,
  toDoTypeId?: number,
  toDoType?: string,
  name?: string,
}

export type OptionType = {
  label: string
  value: string
  color?: string,
}

export interface IContactInfo {
  contactId: number,
  contactTypeId: number,
  contactTypeName: string,
  name?: string,
  email?: string,
  phoneNumber?: string,
}