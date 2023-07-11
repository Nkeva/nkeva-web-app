import React, { useEffect } from "react";
import AuthContainer from "../components/AuthContainer/AuthContainer";
import AuthPanel from "../components/AuthPanel/AuthPanel";

const AuthorizationPage = () => {

    useEffect(() => {
        document.body.style.backgroundColor = "#212121";
    });

    return (
        <div>
            <AuthContainer>
                <AuthPanel />
            </AuthContainer>
        </div>
    );
}

export default AuthorizationPage;
