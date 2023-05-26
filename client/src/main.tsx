import React from "react";
import { createRoot } from "react-dom/client";
import { RouterProvider, createBrowserRouter } from "react-router-dom";

import "./index.css";
import Root from "@routes/root";
import ErrorPage from "@routes/error-page";
import EditPerson from "@routes/edit-person";
import { getPeople, getPerson } from "@services/people-service";
import { getSports } from "@services/sports-service";
import routes from "@routes/routes";

const router = createBrowserRouter([
  {
    path: routes.home,
    element: <Root />,
    errorElement: <ErrorPage />,
    loader: getPeople,
  },
  {
    path: routes.person,
    element: <EditPerson />,
    errorElement: <ErrorPage />,
    loader: async ({ params }) => {
      const person = await getPerson(params["id"] as string);
      const sports = await getSports();

      return { person, sports };
    },
  },
]);

createRoot(document.getElementById("root") as Element).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
