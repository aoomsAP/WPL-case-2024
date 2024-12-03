import { FixedSizeList as List, ListChildComponentProps } from "react-window";
import { MenuListProps } from "react-select";
import { OptionType } from "../../../types";

const MenuList = (props: MenuListProps<OptionType, false>) => {
    const itemHeight = 35; // Define the height of each item
    const { options, children, maxHeight } = props;

    // If children is null or undefined, return early to avoid errors
    if (!children || !Array.isArray(children)) {
        return null;
    }

    return (
        <div style={{ paddingTop: 4 }}>
            <List
                height={Math.min(maxHeight, options.length * itemHeight)} // Ensure the height doesn't exceed available options
                itemCount={children.length} // The number of items to render
                itemSize={itemHeight} // Height of each item
                width="100%"
            >
                {({ index, style }: ListChildComponentProps) => (
                    <div style={style}>{children[index]}</div>
                )}
            </List>
        </div>
    );
};

export default MenuList;
