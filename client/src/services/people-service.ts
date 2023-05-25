import { IPerson } from "./interfaces";

const baseUrl = "https://localhost:5001";

export const getPeople = async (): Promise<IPerson[]> => {
  const response = await fetch(`${baseUrl}/people`);

  const people = (await response.json()) as IPerson[];

  return people;
};

export const getPerson = async (id: string): Promise<IPerson> => {
  const response = await fetch(`${baseUrl}/people/${id}`);

  if (!response.ok) {
    throw new Error(`${response.status}: ${response.statusText}`);
  }

  const person = (await response.json()) as IPerson;

  return person;
};
