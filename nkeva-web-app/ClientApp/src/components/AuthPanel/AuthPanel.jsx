import React from "react";
import CustomHeader from "../CustomHeader/CustomHeader";
import Space from "../Space/Space";
import cl from "./.module.css";

const AuthPanel = ({ children }) => {

    return (
        <div className={cl.main}>
            <div className={cl.log_in_panel}>
                <div className={cl.log_in_header}>
                    <img className={cl.logo} alt="nkeva logo" />
                    <CustomHeader text="School" textColor="#FFFFFF" textSize="56px" />
                </div>
                <Space height="20px" />
                <form className={cl.log_inputs}>
                    <input className={cl.email_input} type="email" placeholder="Email" />
                    <br /><Space height="15px" />
                    <input className={cl.password_input} type="password" placeholder="Password" />
                    <br /><Space height="15px" />
                    <div className={cl.log_in_button}>
                        <p>Log in</p>
                    </div>
                </form>
                <Space height="20px" />
                <a href="/" className={cl.lost_password_link}>Lost password?</a>
            </div>
            <div className={cl.line_back}>
                <div className={cl.line}>
                </div>
            </div>
            <div className={cl.sign_in_panel}>
                <p className={cl.sign_in_header}>Sign in with</p>
                <Space height="10px" />
                <div className={cl.sign_in_button}>
                    <img className={cl.google_img} alt="google email" />
                    <span className={cl.sign_in_text}>@gmail.com</span>
                </div>
                <Space height="50px" />
                <div className={cl.parrent_assecc}>
                    <p className={cl.parrent_assecc_text}>Access like parrent</p>
                </div>
                <Space height="20px" />
                <div className={cl.extra}>
                    <div className={cl.lang}>
                        <span className={cl.lang_name}>English (EN)</span>
                        <Space width="5px" />
                        <img className={cl.arrow_img} alt="language arrow" />
                    </div>
                    <Space width="20px" />
                    <div className={cl.cookies}>
                        <img className={cl.question_img} alt="guestion mark" />
                        <Space width="5px" />
                        <span className={cl.cookies_text}>Cookies notice</span>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default AuthPanel;