import React, { useState } from "react";

interface IRadioGroupProps {
  label: string;
  radioInputItems: string[];
  defaultChecked: string[];
  name: string;
}

const RadioGroup: React.FunctionComponent<
  React.PropsWithChildren<IRadioGroupProps>
> = ({ label, children }) => {
  return (
    <div className="mb-4 flex ">
      <label className="w-48 text-lg font-semibold">{label}</label>
      <div className="space-y-2">{children}</div>
    </div>
  );
};

export default RadioGroup;
