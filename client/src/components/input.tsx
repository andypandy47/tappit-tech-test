import React from "react";

interface IInputProps {
  label: string;
}

const Input: React.FunctionComponent<
  IInputProps & React.InputHTMLAttributes<HTMLInputElement>
> = (props) => {
  return (
    <div className="flex items-center">
      <label className="w-48 text-lg font-semibold" htmlFor={props.name}>
        {props.label}
      </label>
      <input
        type="text"
        {...props}
        className={`${props.className} flex-1 border border-solid border-black`}
        name={props.name}
        id={props.name}
      />
    </div>
  );
};

export default Input;
