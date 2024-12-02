import { FixedSizeList as List, ListChildComponentProps } from "react-window";
import { MenuListProps } from "react-select";
import { OptionType } from "../../../types";

const MenuListSingle = (props: MenuListProps<OptionType, false>) => {
  const itemHeight = 35;
  const { options, children, maxHeight, getValue } = props;

  // Get the selected value
  const [value] = getValue(); 
  const initialOffset = value ? options.indexOf(value) * itemHeight : 0;

  // Ensure children is an array or handle null/undefined
  const childrenArray = Array.isArray(children) ? children : [];

  return (
    <div style={{ paddingTop: 4 }}>
      <List
        height={maxHeight}
        itemCount={options.length} // Use the length of options for single select
        itemSize={itemHeight}
        initialScrollOffset={initialOffset}
        width="100%"
      >
        {({ index, style }: ListChildComponentProps) => (
          <div style={{ ...style }}>
            {/* Ensure we're accessing children correctly */}
            {childrenArray[index] ?? null} {/* Safely access children */}
          </div>
        )}
      </List>
    </div>
  );
};

export default MenuListSingle;
