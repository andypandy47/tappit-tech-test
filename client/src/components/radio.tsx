import React from "react";

interface IRadioProps {}

const Radio: React.FunctionComponent<
  IRadioProps & React.InputHTMLAttributes<HTMLInputElement>
> = (props) => {
  return (
    <div>
      <label className="mr-8 text-lg font-semibold" htmlFor={props.name}>
        <input
          value={props.value ?? props.name}
          className="mr-8 h-4 w-4 border-gray-300 bg-gray-100 text-blue-600 focus:ring-2 focus:ring-blue-500"
          id={props.id ?? props.name}
          {...props}
        />
        {props.name}
      </label>
    </div>
  );
};

export default Radio;
