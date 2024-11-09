
interface BrandTagProps {
    brandname: string;
    key: number
}

const BrandTag = ({ brandname, key }: BrandTagProps) => {

    

    return (
        <div key={key}>
            {brandname} <span onClick={ }>X</span>
        </div>
    );
}

export default BrandTag;