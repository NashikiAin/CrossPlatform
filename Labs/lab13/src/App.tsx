import React, { useState } from "react";
import { LogoutOptions, useAuth0 } from "@auth0/auth0-react";
import Home from "./Views/Home";
import FindShortPath from "./Views/FindShortPath";
import Utils from "./Views/Utils";
import CalcMaxCoins from "./Views/CalcMaxCoins";
import UserProfile from "./Views/UserProfile";
import RegisterPage from "./Views/RegisterPage";


const App: React.FC = () => {
    const t = true;
    const { loginWithRedirect, logout, isAuthenticated, user, isLoading } = useAuth0();
    const [selectedMenu, setSelectedMenu] = useState<string>("Home"); 

    const handleLogin = () => loginWithRedirect();
    const handleLogout = () => logout({ returnTo: window.location.origin } as LogoutOptions);

    if (isLoading) {
        return <div>Loading...</div>;
    }
    
    const renderComponent = () => {
        switch (selectedMenu) {
            case "Home":
                return <Home />;
            case "Utils":
                return <Utils />;
            case "FindShortPath":
                 return <FindShortPath />;
            case "CalcMaxCoins":
                 return <CalcMaxCoins />;
            case "Profile":
                return <UserProfile />;
            case "Register":
                return <RegisterPage />;
            default:
                return <Home />;
        }
    };

    return (
        <div>
            <header>
                <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
                    <div className="container-fluid">
                        <div className="navbar-brand">Lab5</div>
                        <button
                            className="navbar-toggler"
                            type="button"
                            data-bs-toggle="collapse"
                            data-bs-target=".navbar-collapse"
                            aria-controls="navbarSupportedContent"
                            aria-expanded="false"
                            aria-label="Toggle navigation"
                        >
                            <span className="navbar-toggler-icon"></span>
                        </button>
                        <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                            <ul className="navbar-nav flex-grow-1">
                                <li className="nav-item">
                                    <button
                                        className={`btn nav-link text-dark ${selectedMenu === "Home" ? "active" : ""}`}
                                        onClick={() => setSelectedMenu("Home")}
                                    >
                                        Home
                                    </button>
                                </li>
                                {t ? (
                                    <>
                                        <li>
                                            <button
                                                className={`btn nav-link text-dark ${selectedMenu === "Profile" ? "active" : ""}`}
                                                onClick={() => setSelectedMenu("Profile")}
                                            >
                                                Hello {user?.name}!
                                            </button>
                                        </li>
                                        <li>
                                            <button
                                                className={`btn nav-link text-dark ${selectedMenu === "Utils" ? "active" : ""}`}
                                                onClick={() => setSelectedMenu("Utils")}
                                            >
                                                Utils (lab1)
                                            </button>
                                        </li>
                                        <li>
                                            <button
                                                className={`btn nav-link text-dark ${selectedMenu === "CalcMaxCoins" ? "active" : ""}`}
                                                onClick={() => setSelectedMenu("CalcMaxCoins")}
                                            >
                                                CalcMaxCoins (lab2)
                                            </button>
                                        </li>
                                        <li>
                                            <button
                                                className={`btn nav-link text-dark ${selectedMenu === "FindShortPath" ? "active" : ""}`}
                                                onClick={() => setSelectedMenu("FindShortPath")}
                                            >
                                                FindShortPath (lab3)
                                            </button>
                                        </li>
                                        <li>
                                            <button className="btn nav-link text-dark" onClick={handleLogout}>
                                                Logout
                                            </button>
                                        </li>
                                    </>
                                ) : (
                                    <>
                                        <li>
                                            <button className="btn nav-link text-dark" onClick={handleLogin}>
                                                Login
                                            </button>
                                        </li>
                                        <li>
                                            <button
                                                className={`btn nav-link text-dark ${selectedMenu === "Register" ? "active" : ""}`}
                                                onClick={() => setSelectedMenu("Register")}
                                            >
                                                Registration
                                            </button>
                                        </li>
                                    </>
                                )}
                            </ul>
                        </div>
                    </div>
                </nav>
            </header>
            <div className="container">
                <main role="main" className="pb-3">
                    {renderComponent()}
                </main>
            </div>
        </div>
    );
};

export default App;
