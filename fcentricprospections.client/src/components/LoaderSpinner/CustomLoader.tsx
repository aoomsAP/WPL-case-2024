import { Oval } from 'react-loader-spinner';

interface CustomLoaderProps {
    size?: string|number,
}

export default function CustomLoader({
    size = "1rem",
}: CustomLoaderProps) {

    return (
        <Oval
            visible={true}
            height={size}
            width={size}
            color="black"
            secondaryColor="grey"
            strokeWidth={3}
            ariaLabel="oval-loading"
        />
    )
}