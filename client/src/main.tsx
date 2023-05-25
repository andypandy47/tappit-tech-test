import React from "react";
import ReactDOM from "react-dom";
import "./index.css";

import Root from "./routes/root";
import ErrorPage from "./error-page";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import EditPerson from "./routes/edit-person";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Root />,
    errorElement: <ErrorPage />,
  },
  {
    path: "/person/:id",
    element: <EditPerson />,
    errorElement: <ErrorPage />,
  },
]);

ReactDOM.render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
  document.getElementById("root")
);
