import * as React from "react";
import { List, Datagrid, ListProps, TextField, DateField } from "react-admin";
import Pagination from "../Components/Pagination";

export const PetList = (props: ListProps): React.ReactElement => {
  return (
    <List {...props} title={"Pets"} perPage={50} pagination={<Pagination />}>
      <Datagrid rowClick="show" bulkActionButtons={false}>
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
        <DateField source="updatedAt" label="Updated At" />{" "}
      </Datagrid>
    </List>
  );
};
