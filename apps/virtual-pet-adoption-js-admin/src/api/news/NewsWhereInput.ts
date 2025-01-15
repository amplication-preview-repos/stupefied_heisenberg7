import { StringNullableFilter } from "../../util/StringNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";

export type NewsWhereInput = {
  content?: StringNullableFilter;
  id?: StringFilter;
  publishDate?: DateTimeNullableFilter;
  title?: StringNullableFilter;
};
