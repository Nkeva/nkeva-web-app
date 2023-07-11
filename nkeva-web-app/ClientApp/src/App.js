import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import AuthorizationPage from "./pages/AuthorizationPage";

const App = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/auth" element={<AuthorizationPage />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;