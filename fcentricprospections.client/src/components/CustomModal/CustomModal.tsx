import React from "react";
import styles from "./CustomModal.module.css";

interface CustomModalProps {
    visible: boolean;
    onRequestClose: () => void;
    submitTitle: string;
    onSecondButtonPress?: () => void;
    secondButtonTitle?: string;
    children: React.ReactNode;
    modalClassName?: string;
    headerTitle?: string;
    headerTitleClassName?: string;
    footerClassName?: string;
    error?: boolean;
    errorMsg?: string;
    formId?: string;
}

function CustomModal({
    visible,
    onRequestClose,
    submitTitle,
    onSecondButtonPress,
    secondButtonTitle,
    children,
    modalClassName = "",
    headerTitle,
    headerTitleClassName = "",
    footerClassName = "",
    error,
    errorMsg,
    formId,
}: CustomModalProps) {

    if (!visible) return null;

    return (
        <div className={styles.overlay} onClick={onRequestClose}>
            {/* Modal Container */}
            <div
                className={`${styles.modal} ${modalClassName}`}
                onClick={(e) => e.stopPropagation()} // Prevent click inside modal from closing
            >
                {/* Header */}
                <div className={`${styles.header} ${headerTitleClassName}`}>
                    {headerTitle && <h3 className={styles.title}>{headerTitle}</h3>}
                    <button
                        className={styles.close}
                        onClick={onRequestClose}
                        aria-label="Close Modal"
                    >
                        X
                    </button>
                </div>

                {/* Body */}
                <div className={styles.body}>{children}</div>

                {/* Footer */}
                <div className={`${styles.footer} ${footerClassName}`}>
                    {error && errorMsg && (
                        <p className={styles.errorMessage}>{errorMsg}</p>
                    )}
                    <div className={styles.buttonContainer}>
                        {secondButtonTitle && onSecondButtonPress && (
                            <button

                                onClick={onSecondButtonPress}
                                className={`${styles.button} ${styles.secondaryButton}`}
                            >
                                {secondButtonTitle}
                            </button>
                        )}
                        <button
                            form={formId}
                            type="submit"
                            className={`${styles.button} ${styles.primaryButton}`}
                        >
                            {submitTitle}
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default CustomModal;
