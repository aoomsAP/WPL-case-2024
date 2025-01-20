// Custom option for React-Select for improved efficiency and styling
// inspired by https://gist.github.com/lucassshanks/078d458b189dabbc2da8fb22167dc1e1

import { useState } from "react";
import { OptionProps } from "react-select";
import { OptionType } from "../../../types";

// Custom theme/styling for React-Select https://www.metered.ca/blog/react-select-the-complete-guide/
export const customTheme = (theme: any) => ({
  ...theme,
  borderRadius: 0,
  colors: {
    ...theme.colors,
    primary25: 'rgba(247, 247, 247)', // change Background color of options on hover
    primary: 'lightgray', // change the Background color of the selected option
  },
});

const Option = (props: OptionProps<OptionType>) => {
    const { children, innerProps, getStyles, isSelected } = props
    delete props.innerProps.onMouseMove
    delete props.innerProps.onMouseOver
    const [isHovered, setIsHovered] = useState(false)
    const [isPressed, setIsPressed] = useState(false)

    // Emulate default react-select styles
    const customStyles = {
        ...getStyles('option', props),
        ...(isSelected || isHovered || isPressed
            ? {
                backgroundColor: isSelected ? 'yellow' : isPressed ? 'rgb(235, 235, 235)' : 'rgba(247, 247, 247)',
            }
            : {}),
        color: isSelected ? 'black' : undefined,
    }

    return (
        <div
            style={customStyles as React.CSSProperties}
            role="button"
            id={innerProps.id}
            tabIndex={innerProps.tabIndex}
            onMouseEnter={() => setIsHovered(true)}
            onMouseLeave={() => setIsHovered(false)}
            onMouseDown={() => setIsPressed(true)}
            onMouseUp={() => setIsPressed(false)}
            onClick={innerProps.onClick}
            onKeyDown={innerProps.onKeyDown}
        >
            {children}
        </div>
    )
}

export default Option;