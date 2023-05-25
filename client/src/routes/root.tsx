import { IPerson } from "../services/interfaces";
import { useLoaderData } from "react-router-dom";
import Td from "../components/td";

const Root = () => {
  const people = useLoaderData() as IPerson[];

  return (
    <main className="flex h-full justify-center bg-slate-50 py-16">
      <div className="w-[1200px]">
        <h1 className="my-8 text-3xl font-bold">
          My Amazing Favourite American Sports App
        </h1>
        <table className="w-full border-solid border-black text-center shadow-lg">
          <thead className="text-bold h-14 bg-slate-300">
            <tr>
              <th>Name</th>
              <th>Enabled</th>
              <th>Valid</th>
              <th>Authorised</th>
              <th>Palindrome</th>
              <th>Favourite Sports</th>
            </tr>
          </thead>
          <tbody>
            {people.map((person: IPerson, index: number) => (
              <tr
                key={person.id}
                className={` ${
                  index % 2 == 1
                    ? "bg-gray-200 hover:bg-gray-300"
                    : "hover:bg-gray-300"
                } cursor-pointer transition-colors`}
              >
                <Td to={`/person/${person.id}`}>
                  {person.firstName} {person.lastName}
                </Td>
                <Td to={`/person/${person.id}`}>{`${person.enabled}`}</Td>
                <Td to={`/person/${person.id}`}>{`${person.valid}`}</Td>
                <Td to={`/person/${person.id}`}>{`${person.authorised}`}</Td>
                <Td to={`/person/${person.id}`}>{`${person.palindrome}`}</Td>
                <Td
                  to={`/person/${person.id}`}
                  className="w-[275px]"
                >{`${person.favouriteSports
                  .map((x) => x.name)
                  .join(", ")}`}</Td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </main>
  );
};

export default Root;
