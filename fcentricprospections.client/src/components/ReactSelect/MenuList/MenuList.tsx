// Custom menu list for React-Select MULTI for improved efficiency and styling
// inspired by https://gist.github.com/lucassshanks/078d458b189dabbc2da8fb22167dc1e1
// react-window virtualizes lists and only renders the data visible in the viewport

import { FixedSizeList as List, ListChildComponentProps } from "react-window";
import { MenuListProps } from "react-select";
import { OptionType } from "../../../types";

const MenuList = (props: MenuListProps<OptionType, true>) => {
  const itemHeight = 50;
  const { options, children, maxHeight, getValue } = props
    const [value] = getValue()
    const initialOffset = options.indexOf(value) * itemHeight
  
    return Array.isArray(children) ? (
      <div style={{ paddingTop: 4 }}>
        <List
          height={maxHeight}
          itemCount={children.length}
          itemSize={itemHeight}
          initialScrollOffset={initialOffset}
          width="100%"
        >
          {({ index, style }: ListChildComponentProps) => <div style={{ ...style }}>{children[index]}</div>}
        </List>
      </div>
    ) : null
  }

export default MenuList;
