import React, { useState } from "react";

interface IRadioGroupProps {
  label: string;
  radioInputItems: string[];
  defaultChecked: string[];
  name: string;
  // onChange: (checkedItems: string[]) => void;
}

const RadioGroup: React.FunctionComponent<IRadioGroupProps> = ({
  label,
  radioInputItems,
  defaultChecked,
  name,
}) => {
  const [checked, setChecked] = useState<string[]>(defaultChecked);
  return (
    <div className="mb-4 flex items-center">
      <label className="mr-12 text-lg font-semibold">{label}</label>
      <div className="flex flex-col">
        {radioInputItems.map((item: string) => (
          <div>
            <label className="mr-12 text-lg font-semibold">
              <input
                key={item}
                type="radio"
                value={item}
                checked={checked.includes(item)}
                className="h-4 w-4 border-gray-300 bg-gray-100 text-blue-600 focus:ring-2 focus:ring-blue-500 dark:border-gray-600 dark:bg-gray-700 dark:ring-offset-gray-800 dark:focus:ring-blue-600"
              />
              {item}
            </label>
          </div>
        ))}
      </div>
    </div>
  );
};

export default RadioGroup;
