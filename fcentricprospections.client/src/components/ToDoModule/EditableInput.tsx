import { useState, useRef, useEffect } from "react";
import { AiFillEdit } from "react-icons/ai";
import styles from "./EditableInput.module.css";

interface EditableInputProps {
    type: "textarea" | "input";
    value: string;
    onChange: (value: string) => void;
    disabled: boolean,
}

const EditableInput = ({ type, value, onChange, disabled }: EditableInputProps) => {
    const inputRef = useRef<HTMLInputElement | null>(null); // Specify the type for inputRef
    const textareaRef = useRef<HTMLTextAreaElement | null>(null); // Specify the type for textareaRef
    const [inputVisible, setInputVisible] = useState(false);
    const [text, setText] = useState(value);

    function onClickOutSide(e: MouseEvent) {
        switch (type) {
            case "textarea":
                // Check if user is clicking outside of <textarea>
                if (textareaRef.current && !textareaRef.current.contains(e.target as Node)) {
                    setInputVisible(false); // Disable text input
                }
                break;
            case "input":
                // Check if user is clicking outside of <input>
                if (inputRef.current && !inputRef.current.contains(e.target as Node)) {
                    setInputVisible(false); // Disable text input
                }
                break;
            default: return;
        }
    }

    useEffect(() => {
        if (inputVisible) {
            document.addEventListener("mousedown", onClickOutSide);
        }

        return () => {
            document.removeEventListener("mousedown", onClickOutSide);
        };
    }, [inputVisible]);

    return (
        <>
            {(inputVisible && !disabled) ? (

                <>
                    {type === "input" &&
                        <input className={styles.input_container}
                            ref={inputRef} // Set the Ref
                            value={text} // Now input value uses local state
                            onChange={(e) => {
                                setText(e.target.value);
                                onChange(e.target.value); // Call onChange with the updated value
                            }}
                        />
                    }
                    {type === "textarea" &&
                        <textarea className={styles.input_container}
                            ref={textareaRef} // Set the Ref
                            value={text} // Now input value uses local state
                            onChange={(e) => {
                                setText(e.target.value);
                                onChange(e.target.value); // Call onChange with the updated value
                            }}
                        />
                    }
                </>
            )

                : (

                    <div className={`${styles.input_container} ${!disabled ? styles.edit_cursor : ""}`}
                        onClick={() => setInputVisible(true)}>
                        {!disabled && <AiFillEdit className={styles.edit_icon} />}
                        <p>{text}</p>
                    </div>

                )}
        </>
    );
};

export default EditableInput;