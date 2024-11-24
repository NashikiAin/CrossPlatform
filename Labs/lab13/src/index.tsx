import React from "react";
import ReactDOM, { createRoot } from "react-dom/client";
import { Auth0Provider } from "@auth0/auth0-react";
import App from "./App";
import "bootstrap/dist/css/bootstrap.min.css";

const root = createRoot(document.getElementById("root")!);

root.render(
    <Auth0Provider
        domain="dev-h8orlpa10u7tnfzz.us.auth0.com"
        clientId="7Cnppg4gLKQS8zncipWYtQ5PgCuwbfdF"
        authorizationParams={{
            redirect_uri: window.location.origin + '/callback',
        }}
    >
        <App />
    </Auth0Provider>,
);
