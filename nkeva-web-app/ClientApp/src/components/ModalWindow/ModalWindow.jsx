import React from "react";
import cl from "./.module.css";

const ModalWindow = ({ backgroundColor = "#00000000", frontColor = "#00000000", padding = "0px", isVisible = true, children }) => {

    return (
        <div className={cl.back} style={{ display: isVisible ? 'block' : 'none', backgroundColor: backgroundColor }} >
            <div className={cl.panel} style={{ backgroundColor: frontColor, padding: padding }}>
                {children}
            </div>
        </div>
    );
}

export default ModalWindow;