import http from "@shared/http";
import { ISportDetails } from "./interfaces";

export const getSports = async (): Promise<ISportDetails[]> => {
  const response = await http.get<ISportDetails[]>("sports");

  return response.data;
};
