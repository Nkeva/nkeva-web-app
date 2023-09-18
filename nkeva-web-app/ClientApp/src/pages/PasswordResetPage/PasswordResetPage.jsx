import React from "react";
import cl from "./.module.css";
import Space from "../../components/Space/Space";
import { useNavigate } from "react-router-dom";
import { UserAPI } from "../../services/api/users";

const PasswordResetPage = () => {

    const [currentWindow, setCurrentWindow] = React.useState("email");
    const [isLoading, setLoadingState] = React.useState(false);

    const navigate = useNavigate();

    async function SendEmail() {
        setLoadingState(true);
        if ((await UserAPI.sendResetUserPasswordEmail(document.getElementsByClassName(cl.email_input)[0].value)).ok) {
            setCurrentWindow("email-is-sent-message");
        }
        setLoadingState(false);
    }

    async function ResetPassword() {
        setLoadingState(true);
        setCurrentWindow("password-is-changed-message");
        setLoadingState(false);
    }

    function RenderWindow() {
        switch (currentWindow) {
            case "email":
                return (
                    <div className={cl.front}>
                        <p className={cl.reset_password_description}>
                            To reset the password, submit the email address of your account.
                            If the email address will be found in our database,
                            an email will be sent to your email address with a link to
                            the page where you will be able to set your new password.
                        </p>
                        <Space height="15px" />
                        <hr />
                        <Space height="15px" />
                        <h1 className={cl.info_header}>Search by email address</h1>
                        <Space height="10px" />
                        <input type="text" className={cl.email_input} placeholder="Email address" />
                        <Space height="20px" />
                        <hr />
                        <Space height="15px" />
                        <div className={cl.search_email_button} onClick={SendEmail}>
                            <span className={cl.search_email_button_text}>Search</span>
                        </div>
                    </div>
                );
            case "password":
                return (
                    <div className={cl.front}>
                        <p className={cl.reset_password_description}>
                            Now you can reset the password.
                            Submit a new password and then repeat it
                            until the session is not expired.
                            Do not forget your password so as not to reset it again.
                        </p>
                        <Space height="15px" />
                        <hr />
                        <Space height="15px" />
                        <h1 className={cl.info_header}>Set new password</h1>
                        <Space height="10px" />
                        <input type="password" className={cl.password_input} placeholder="Password" />
                        <Space height="20px" />
                        <hr />
                        <Space height="15px" />
                        <h1 className={cl.info_header}>Repeat new password</h1>
                        <Space height="10px" />
                        <input type="password" className={cl.password_repeat_input} placeholder="Password" />
                        <Space height="20px" />
                        <hr />
                        <Space height="15px" />
                        <div className={cl.set_password_button} onClick={ResetPassword}>
                            <span className={cl.set_password_button_text}>Apply</span>
                        </div>
                    </div>
                );
            case "email-is-sent-message":
                return (
                    <div className={cl.front}>
                        <p className={cl.reset_password_description}>
                            An email has sent to the email address.
                            Follow the instructions that are written in the email.
                            You have 30 minutes to reset the password.
                        </p>
                        <Space height="30px" />
                        <div className={cl.ok_button} onClick={() => navigate('/')}>
                            <span className={cl.ok_button_text}>Ok</span>
                        </div>
                    </div>
                );
            case "password-is-changed-message":
                return (
                    <div className={cl.front}>
                        <p className={cl.reset_password_description}>
                            The password is changed. You can enter your account using it.
                            Do not forget your password.
                        </p>
                        <Space height="30px" />
                        <div className={cl.ok_button} onClick={() => navigate('/')}>
                            <span className={cl.ok_button_text}>Ok</span>
                        </div>
                    </div>
                );
            default:
                return (
                    <div className={cl.front}>
                        <h1 className={cl.search_email_header}>WINDOW ERROR</h1>
                    </div>
                );
        }
    }

    React.useEffect(() => {
        document.body.style.backgroundColor = "#212121";
    });

    return (
        <div className={cl.main}>
            {RenderWindow()}
        </div>
    );
}

export default PasswordResetPage;