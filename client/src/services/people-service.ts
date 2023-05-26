import http from "@shared/http";
import { IPerson, IPersonUpdate } from "./interfaces";

export const getPeople = async (): Promise<IPerson[]> => {
  const response = await http.get<IPerson[]>("people");

  return response?.data;
};

export const getPerson = async (id: string): Promise<IPerson> => {
  const response = await http.get<IPerson>(`people/${id}`);

  return response.data;
};

export const updatePerson = async (
  id: number,
  personUpdate: IPersonUpdate
): Promise<void> => {
  const response = await http.put(`/people/${id}`, personUpdate);

  return response.data;
};
