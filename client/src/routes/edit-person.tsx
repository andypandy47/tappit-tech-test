import { useState } from "react";
import { useLoaderData, useNavigate } from "react-router-dom";
import Input from "@components/input";
import Toggle from "@components/toggle";
import RadioGroup from "@components/radio-group";
import {
  IPerson,
  IPersonUpdate,
  ISport,
  ISportDetails,
} from "@services/interfaces";
import Button from "@components/button/button";
import Radio from "@components/radio";
import { updatePerson } from "@services/people-service";
import routes from "./routes";

const EditPerson = () => {
  const { person: personDetails, sports } = useLoaderData() as {
    person: IPerson;
    sports: ISportDetails[];
  };
  const [person, setPerson] = useState<IPerson>(personDetails);
  const [favouriteSports, setFavouriteSports] = useState<Map<number, boolean>>(
    new Map(
      sports.map((x) => [
        x.sportId,
        person.favouriteSports.findIndex((y) => y.sportId === x.sportId) !== -1,
      ])
    )
  );
  const navigate = useNavigate();

  const handleFavouriteSportsChange = (sport: ISport, checked: boolean) => {
    const newFavouriteSports = new Map(favouriteSports);
    newFavouriteSports.set(sport.sportId, checked);

    setFavouriteSports(newFavouriteSports);
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const updatedSports = Array.from(favouriteSports.keys()).filter((x) =>
      favouriteSports.get(x)
    );

    const personUpdate: IPersonUpdate = {
      firstName: person.firstName,
      lastName: person.lastName,
      enabled: person.enabled,
      valid: person.valid,
      authorised: person.authorised,
      favouriteSports: updatedSports,
    };

    try {
      await updatePerson(person.id, personUpdate);
    } catch (error) {
      console.log(error);
      return;
    }

    navigate(routes.home);
  };

  return (
    <main className="flex h-full justify-start bg-slate-50 py-16">
      <div className="ml-40 flex w-[800px] flex-col">
        <h1 className="my-8 text-3xl font-bold">Update person details</h1>
        <form className="space-y-8" onSubmit={handleSubmit}>
          <Input
            label="First Name"
            value={person.firstName}
            onChange={(e) =>
              setPerson({ ...person, firstName: e.target.value })
            }
            className="p-2"
            name="first-name"
          />
          <Input
            label="Last Name"
            value={person.lastName}
            onChange={(e) => setPerson({ ...person, lastName: e.target.value })}
            className="p-2"
            name="last-name"
          />
          <Toggle
            label="Enabled"
            defaultChecked={person.enabled}
            onChange={() => setPerson({ ...person, enabled: !person.enabled })}
            name="enabled"
          />
          <Toggle
            label="Valid"
            defaultChecked={person.valid}
            onChange={() => setPerson({ ...person, valid: !person.valid })}
            name="valid"
          />
          <Toggle
            label="Authorised"
            defaultChecked={person.authorised}
            onChange={() =>
              setPerson({ ...person, authorised: !person.authorised })
            }
            name="authorised"
          />
          <RadioGroup
            name="favourite-sports"
            label="Favourite Sports"
            radioInputItems={sports.map((x) => x.name)}
            defaultChecked={person.favouriteSports.map((x) => x.name)}
          >
            {sports.map((sport) => (
              <Radio
                key={sport.name}
                type="checkbox"
                name={sport.name}
                defaultChecked={favouriteSports.get(sport.sportId)}
                onChange={(e) =>
                  handleFavouriteSportsChange(sport, e.target.checked)
                }
              />
            ))}
          </RadioGroup>
          <div className="flex justify-between pl-48">
            <Button danger type="button" to="/">
              Cancel
            </Button>
            <Button primary type="submit">
              Submit
            </Button>
          </div>
        </form>
      </div>
    </main>
  );
};

export default EditPerson;
