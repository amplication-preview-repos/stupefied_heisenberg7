import { StringNullableFilter } from "../../util/StringNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";

export type ContactWhereInput = {
  email?: StringNullableFilter;
  id?: StringFilter;
  message?: StringNullableFilter;
  sentAt?: DateTimeNullableFilter;
};
