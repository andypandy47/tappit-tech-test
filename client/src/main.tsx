import React from "react";
import ReactDOM from "react-dom";
import "./index.css";

import Root from "./routes/root";
import ErrorPage from "./error-page";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import EditPerson from "./routes/edit-person";
import { getPeople, getPerson } from "./services/people-service";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Root />,
    errorElement: <ErrorPage />,
    loader: getPeople,
  },
  {
    path: "/person/:id",
    element: <EditPerson />,
    errorElement: <ErrorPage />,
    loader: ({ params }) => getPerson(params["id"] as string),
  },
]);

ReactDOM.render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
  document.getElementById("root")
);
