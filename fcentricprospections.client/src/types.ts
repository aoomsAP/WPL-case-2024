
export interface IShop {
  id: string; // Example property, replace with real ones
  name: string; // Example property
}

export interface Address{
  id : number,
  street1 : string,
  street2 : string,
  postalcode : string,
  city : string,
  country : string,
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
   export interface Shop2{
       id : string,
       shopName : string,
       prospections : Prospection[]
   }

