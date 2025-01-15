import * as React from "react";

import {
  Show,
  SimpleShowLayout,
  ShowProps,
  TextField,
  DateField,
  ReferenceManyField,
  Datagrid,
  ReferenceField,
} from "react-admin";

import { PET_TITLE_FIELD } from "./PetTitle";
import { USER_TITLE_FIELD } from "../user/UserTitle";

export const PetShow = (props: ShowProps): React.ReactElement => {
  return (
    <Show {...props}>
      <SimpleShowLayout>
        <TextField label="Bio" source="bio" />
        <DateField source="createdAt" label="Created At" />
        <TextField label="DateOfBirth" source="dateOfBirth" />
        <TextField label="HealthCondition" source="healthCondition" />
        <TextField label="ID" source="id" />
        <TextField label="Location" source="location" />
        <TextField label="MainGalleryPhotos" source="mainGalleryPhotos" />
        <TextField label="Name" source="name" />
        <TextField label="NumberOfOwners" source="numberOfOwners" />
        <TextField label="PersonalityTraits" source="personalityTraits" />
        <DateField source="updatedAt" label="Updated At" />
        <ReferenceManyField
          reference="Subscription"
          target="petId"
          label="Subscriptions"
        >
          <Datagrid rowClick="show" bulkActionButtons={false}>
            <DateField source="createdAt" label="Created At" />
            <TextField label="EndDate" source="endDate" />
            <TextField label="ID" source="id" />
            <ReferenceField label="Pet" source="pet.id" reference="Pet">
              <TextField source={PET_TITLE_FIELD} />
            </ReferenceField>
            <TextField label="StartDate" source="startDate" />
            <TextField label="Status" source="status" />
            <DateField source="updatedAt" label="Updated At" />
            <ReferenceField label="User" source="user.id" reference="User">
              <TextField source={USER_TITLE_FIELD} />
            </ReferenceField>
          </Datagrid>
        </ReferenceManyField>
      </SimpleShowLayout>
    </Show>
  );
};
