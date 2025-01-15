import * as React from "react";

import {
  Edit,
  SimpleForm,
  EditProps,
  TextInput,
  DateTimeInput,
  NumberInput,
  SelectArrayInput,
  ReferenceArrayInput,
} from "react-admin";

import { SubscriptionTitle } from "../subscription/SubscriptionTitle";

export const PetEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput label="Bio" multiline source="bio" />
        <DateTimeInput label="DateOfBirth" source="dateOfBirth" />
        <TextInput label="HealthCondition" source="healthCondition" />
        <TextInput label="Location" source="location" />
        <div />
        <TextInput label="Name" source="name" />
        <NumberInput step={1} label="NumberOfOwners" source="numberOfOwners" />
        <SelectArrayInput
          label="PersonalityTraits"
          source="personalityTraits"
          choices={[{ label: "Option 1", value: "Option1" }]}
          optionText="label"
          optionValue="value"
        />
        <ReferenceArrayInput source="subscriptions" reference="Subscription">
          <SelectArrayInput
            optionText={SubscriptionTitle}
            parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
            format={(value: any) => value && value.map((v: any) => v.id)}
          />
        </ReferenceArrayInput>
      </SimpleForm>
    </Edit>
  );
};
