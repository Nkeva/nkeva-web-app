import React from "react";
import Space from "../Space/Space";
import cl from './.module.css';

const CustomTextarea = ({ placeholder = '', fontFamily = 'robotic', content = '', contentSize = '18px', width = '50px', height = 'default', maxWidth = 'none', minWidth = 'none', maxHeight = 'none', minHeight = 'none', headerText = '', headerSize = '10px', headerWeight = 'normal', headerColor = 'black', isHeaderCentered = false, onChange }) => {

    return (
        <div className={cl.main} style={{
            maxWidth: maxWidth,
            minWidth: minWidth,
            maxHeight: maxHeight,
            minHeight: minHeight
        }}>
            <p className={cl.header} style={{
                textAlign: isHeaderCentered ? 'center' : 'left',
                fontSize: headerSize,
                fontWeight: headerWeight,
                color: headerColor
            }}>{headerText}</p>
            <Space height="5px" />
            <textarea
                className={cl.cont}
                onChange={(e) => onChange(e)}
                defaultValue={content}
                placeholder={placeholder}
                style={{
                    width: width,
                    height: height,
                    fontSize: contentSize,
                    fontFamily: fontFamily
                }} />
        </div>
    );
}

export default CustomTextarea;