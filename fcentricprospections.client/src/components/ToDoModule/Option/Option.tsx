// inspired by https://gist.github.com/lucassshanks/078d458b189dabbc2da8fb22167dc1e1

import { useState } from "react";
import { OptionProps } from "react-select";
import { OptionType } from "../../../types";

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
                backgroundColor: isSelected ? '#abbde9' : isPressed ? '#B2D4FF' : '#DDEBFF',
            }
            : {}),
        color: isSelected ? 'white' : undefined,
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