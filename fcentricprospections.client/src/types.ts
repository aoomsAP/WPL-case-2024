

export interface IShop {
  id: string; // Example property, replace with real ones
  name: string; // Example property
}


export interface Shop {
    id: string;
    shopName: string; // Change 'name' to 'shopName' to match ShopData
    address: string;
    customerName: string;
  }

  export interface Prospection {
      id: string;
      data: string;
      text: string;
  }
   export interface Shop2{
       id : string,
       shopName : string,
       prospections : Prospection[]
   }