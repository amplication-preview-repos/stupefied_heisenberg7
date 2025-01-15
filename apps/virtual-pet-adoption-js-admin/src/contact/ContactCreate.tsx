import * as React from "react";
import {
  Create,
  SimpleForm,
  CreateProps,
  TextInput,
  DateTimeInput,
} from "react-admin";

export const ContactCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput label="Email" source="email" type="email" />
        <TextInput label="Message" multiline source="message" />
        <DateTimeInput label="SentAt" source="sentAt" />
      </SimpleForm>
    </Create>
  );
};
