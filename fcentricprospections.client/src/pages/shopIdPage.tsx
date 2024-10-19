import styles from './shopIdpage.module.css';

interface ShopPageProps {
  id: string | undefined;
}

export const ShopPage = ({ id }: ShopPageProps) => {
   
  return (
    <>
      <main className={styles.main}>
        <h1>De naam van de shop:</h1>
        <h2>Adres van de shop: </h2>
        <h2>Naam van de klant:</h2>
        <li>{id}</li>
      </main>
    </>
  );
};


/* Temporary Code */
interface Shop {
    id: string;
    shopName: string; // Change 'name' to 'shopName' to match ShopData
    address: string;
    customerName: string;
  }
  
  const dummyData: Shop[] = [
    { id: '1', shopName: 'Coffee Shop', address: '123 Coffee Lane', customerName: 'Alice Smith' },
    { id: '2', shopName: 'Bookstore', address: '456 Book Ave', customerName: 'Bob Johnson' },
    { id: '3', shopName: 'Grocery Store', address: '789 Grocery Blvd', customerName: 'Charlie Davis' },
    { id: '4', shopName: 'Clothing Boutique', address: '101 Fashion St', customerName: 'Diana Moore' },
    { id: '5', shopName: 'Electronics Store', address: '202 Tech Park', customerName: 'Eve Turner' },
    { id: '6', shopName: 'Flower Shop', address: '303 Blooming Rd', customerName: 'Frank White' },
    { id: '7', shopName: 'Music Store', address: '404 Melody Ave', customerName: 'Grace Hill' },
    { id: '8', shopName: 'Hardware Store', address: '505 Builder St', customerName: 'Henry King' },
    { id: '9', shopName: 'Jewelry Store', address: '606 Gemstone Blvd', customerName: 'Ivy Carter' },
    { id: '10', shopName: 'Art Gallery', address: '707 Canvas Lane', customerName: 'Jack Lee' },
  ];
  
