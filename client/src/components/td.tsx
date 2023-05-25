import React from "react";
import { Link } from "react-router-dom";

interface ITdProps {
  to?: string;
}

const Td: React.FC<ITdProps & React.HTMLProps<HTMLTableCellElement>> = (
  props
) => {
  const ContentTag = props.to ? Link : "div";
  return (
    <td {...props}>
      <ContentTag
        to={props.to as string}
        className="flex h-14 flex-1 items-center justify-center"
      >
        {props.children}
      </ContentTag>
    </td>
  );
};

export default Td;
