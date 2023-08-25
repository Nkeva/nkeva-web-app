import React from "react";
import cl from "./.module.css";
import Space from "../../components/Space/Space";
import { AuthAPI } from "../../services/api/auth";
import { useNavigate } from "react-router-dom";
import { LanguageManager } from "../../services/LanguageManager";

const AuthorizationPage = () => {

    const navigate = useNavigate();

    const langMenuRef = React.useRef();

    const [isLoggingIn, setLoggingIn] = React.useState(false);
    const [errorText, setErrorText] = React.useState(undefined);
    const [isLangMenuVisible, setLangMenuVisibility] = React.useState(false);

    function ChangeLang(lang) {
        LanguageManager.setLang(lang);
        setLangMenuVisibility(false);
    }

    async function LoginRequest(email, password) {
        setLoggingIn(true);
        await AuthAPI.login(email, password).then(res => {
            switch (res.status) {
                case 200:
                    navigate('/account', { replace: true });
                    break;
                case 400 || 401:
                    setErrorText("invalid email or password");
                    break;
                case 500:
                    setErrorText("internal server error");
                    break;
                default:
                    setErrorText("authorization failed");
                    break;
            }
        });
        setLoggingIn(false);
    }

    function RenderError() {
        if (errorText) {
            return (
                <>
                    <div className={cl.error}>
                        <div className={cl.error_text_area}>
                            <span className={cl.error_header}>Error:</span>
                            <span className={cl.error_text}>{errorText}</span>
                        </div>
                        <div className={cl.error_close_area}>
                            <img className={cl.error_close_sign} onClick={() => setErrorText(undefined)} />
                        </div>
                    </div>
                    <Space height="15px" />
                </>
            );
        }
    }

    function WindowClickEvent(event) {
        if (isLangMenuVisible && !langMenuRef.current.contains(event.target)) {
            setLangMenuVisibility(false);
        }
    }

    function WindowKeyPressEvent(event) {
        var emailInput = document.getElementsByClassName(cl.email_input)[0];
        var passwordInput = document.getElementsByClassName(cl.password_input)[0];

        if (event.key === "Enter" && (document.activeElement === emailInput || document.activeElement === passwordInput)) {
            LoginRequest(
                emailInput.value,
                passwordInput.value
            );
        }
    }

    React.useEffect(() => {
        document.body.style.backgroundColor = "#212121";

        window.addEventListener("click", WindowClickEvent);
        window.addEventListener("keypress", WindowKeyPressEvent);

        return () => {
            window.removeEventListener("click", WindowClickEvent);
            window.removeEventListener("keypress", WindowKeyPressEvent);
        };
    });

    return (
        <div className={cl.main} >
            <div className={cl.front}>
                <div className={cl.log_in_panel}>
                    <div className={cl.log_in_header}>
                        <img className={cl.logo} alt="nkeva logo" />
                        <h1 className={cl.logo_text}>School</h1>
                    </div>
                    <Space height="20px" />
                    <form className={cl.log_inputs}>
                        {RenderError()}
                        <input className={cl.email_input} type="email" placeholder={LanguageManager.get("auth.email-input-placeholder")} />
                        <br /><Space height="15px" />
                        <input className={cl.password_input} type="password" placeholder={LanguageManager.get("auth.password-input-placeholder")} />
                        <br /><Space height="15px" />
                        <div className={cl.log_in_button} onClick={() => LoginRequest(
                            document.getElementsByClassName(cl.email_input)[0].value,
                            document.getElementsByClassName(cl.password_input)[0].value
                        )}>
                            {
                                isLoggingIn
                                    ? <p className={cl.log_in_button_text}>...</p>
                                    : <p className={cl.log_in_button_text}>{LanguageManager.get("auth.log-in-button")}</p>
                            }
                        </div>
                    </form>
                    <Space height="20px" />
                    <a className={cl.lost_password_link}>{LanguageManager.get("auth.lost-password-link")}</a>
                </div>
                <div className={cl.line}></div>
                <div className={cl.sign_in_panel}>
                    <div className={cl.sign_in_cont}>
                        <p className={cl.sign_in_header}>{LanguageManager.get("auth.sign-in-header")}</p>
                        <Space height="10px" />
                        <div className={cl.sign_in_button}>
                            <img className={cl.google_img} alt="google email" />
                            <span className={cl.sign_in_text}>@gmail.com</span>
                        </div>
                        <Space height="50px" />
                        <div className={cl.parent_access}>
                            <p className={cl.parent_access_text}>{LanguageManager.get("auth.access-like-parent-button")}</p>
                        </div>
                        <Space height="20px" />
                        <div className={cl.extra}>
                            <div className={cl.lang} ref={langMenuRef}>
                                <div className={cl.current_lang} onClick={() => setLangMenuVisibility(prev => !prev)}>
                                    <span className={cl.current_lang_name}>{LanguageManager.get('auth.current-lang')}</span>
                                    <Space width="5px" />
                                    <img className={cl.arrow_img} alt="language arrow" />
                                </div>
                                <div className={cl.lang_menu} style={{ display: isLangMenuVisible ? 'block' : 'none' }}>
                                    <p className={`${cl.lang_name} ${cl.en_lang_name}`} onClick={() => ChangeLang('en')}>English (EN)</p>
                                    <p className={`${cl.lang_name} ${cl.ua_lang_name}`} onClick={() => ChangeLang('ua')}>Українська (UA)</p>
                                </div>
                            </div>
                            <Space width="20px" />
                            <div className={cl.cookies}>
                                <img className={cl.question_img} alt="question mark" />
                                <Space width="5px" />
                                <span className={cl.cookies_text}>{LanguageManager.get("auth.cookies-notice-link")}</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default AuthorizationPage;
