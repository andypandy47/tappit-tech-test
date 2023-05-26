import React from "react";

interface IToggleProps {
  label: string;
}

const Toggle: React.FunctionComponent<
  IToggleProps & React.InputHTMLAttributes<HTMLInputElement>
> = (props) => {
  return (
    <div className="flex items-center">
      <label className="w-48 text-lg font-semibold" htmlFor={props.name}>
        {props.label}
      </label>
      <label className="relative inline-flex cursor-pointer items-center">
        <input
          type="checkbox"
          value=""
          {...props}
          id={props.id ?? props.name}
          className="peer sr-only"
        />
        <div className="peer h-6 w-11 rounded-full bg-gray-600 after:absolute after:left-[2px] after:top-[2px] after:h-5 after:w-5 after:rounded-full after:border after:border-gray-300 after:bg-white after:transition-all after:content-[''] peer-checked:bg-green-600 peer-checked:after:translate-x-full peer-checked:after:border-white peer-focus:ring-2 peer-focus:ring-blue-400"></div>
      </label>
    </div>
  );
};

export default Toggle;
