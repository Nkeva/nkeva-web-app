import React from "react";
import { BrowserRouter, Route, Routes} from "react-router-dom";
import AuthorizationPage from "./pages/AuthorizationPage/AuthorizationPage";
import LayoutMenu from "./components/LayoutMenu/LayoutMenu";
import AccountPage from "./pages/AccountPage/AccountPage";
import { AuthAPI } from "./services/api/auth";
import PasswordResetPage from "./pages/PasswordResetPage/PasswordResetPage";

const App = () => {

    React.useEffect(() => {
        AuthAPI.check().then((res) => {
            if (res.status === 401) {
                if (window.location.pathname !== "/") {
                    window.location.replace("/");
                }
            }
        });
    });

    return (
        <BrowserRouter>
            <Routes>
                <Route index element={<AuthorizationPage />} />
                <Route path="reset-password" element={<PasswordResetPage />} />
                <Route path="account" element={<LayoutMenu />}>
                    <Route index element={<AccountPage />} />
                    <Route path="courses" element={<></>} />
                    <Route path="schedule" element={<></>} />
                    <Route path="chats" element={<></>} />
                    <Route path="grades" element={<></>} />
                    <Route path="anime" element={<></>} />
                    <Route path="friends" element={<></>} />
                </Route>
            </Routes>
        </BrowserRouter>
    );
}

export default App;