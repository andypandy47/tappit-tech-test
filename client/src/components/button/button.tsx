import React from "react";
import "./button.css";
import { Link } from "react-router-dom";

interface IButtonProps {
  primary?: boolean;
  danger?: boolean;
  type?: "submit" | "reset" | "button";
  to?: string;
  onClick?: React.MouseEventHandler<HTMLButtonElement>;
}

const Button: React.FunctionComponent<
  React.PropsWithChildren<IButtonProps>
> = ({ children, primary, danger, type, to, onClick }) => {
  return (
    <>
      {to ? (
        <Link to={to}>
          <button
            type={type}
            className={`btn-base ${primary ? "btn-primary" : ""}${
              danger ? "btn-danger" : ""
            }`}
            onClick={onClick}
          >
            {children}
          </button>
        </Link>
      ) : (
        <button
          type={type}
          className={`btn-base ${primary ? "btn-primary" : ""}${
            danger ? "btn-danger" : ""
          }`}
          onClick={onClick}
        >
          {children}
        </button>
      )}
    </>
  );
};

export default Button;
