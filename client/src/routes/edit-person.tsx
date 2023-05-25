import React, { useState } from "react";
import { IPerson } from "../services/interfaces";
import { useLoaderData } from "react-router-dom";
import Input from "../components/input";
import Toggle from "../components/toggle";
import RadioGroup from "../components/radio-group";
import { sports } from "../services/constants";

const EditPerson = () => {
  const [person, setPerson] = useState<IPerson>(useLoaderData() as IPerson);

  return (
    <main className="flex h-full justify-start bg-slate-50 py-16">
      <div className="ml-40 flex w-[800px] flex-col">
        <h1 className="my-8 text-3xl font-bold">Update person details</h1>
        <form className="space-y-8">
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
            onChange={(e) => setPerson({ ...person, enabled: !person.enabled })}
            name="enabled"
          />
          <Toggle
            label="Valid"
            defaultChecked={person.valid}
            onChange={(e) => setPerson({ ...person, valid: !person.valid })}
            name="valid"
          />
          <Toggle
            label="Authorised"
            defaultChecked={person.authorised}
            onChange={(e) =>
              setPerson({ ...person, authorised: !person.authorised })
            }
            name="authorised"
          />
          <RadioGroup
            name="favourite-sports"
            label="Favourite Sports"
            radioInputItems={sports}
            defaultChecked={person.favouriteSports.map((x) => x.name)}
          />
        </form>
      </div>
    </main>
  );
};

export default EditPerson;
