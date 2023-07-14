import React from "react";
import cl from './.module.css';

const CustomImage = ({ src = undefined, alt = undefined, width = "0px", height = "0px", opacity = "1", filter = "" }) => {

    return (
        <div className={cl.cont} style={{ width: width, height: height }}>
            <img className={cl.image} src={src} alt={alt} style={{filter: filter, opacity: opacity}} />
        </div>
    );
}

export default CustomImage;