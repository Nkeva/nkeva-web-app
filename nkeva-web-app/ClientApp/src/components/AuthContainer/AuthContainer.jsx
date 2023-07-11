import React from "react";
import cl from "./.module.css";

const ModalWindow = ({ children }) => {

    return (
        <div className={cl.back} >
            <div className={cl.front}>
                {children}
            </div>
        </div>
    );
}

export default ModalWindow;