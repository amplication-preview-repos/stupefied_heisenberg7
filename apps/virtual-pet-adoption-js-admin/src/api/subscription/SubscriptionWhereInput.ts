import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { PetWhereUniqueInput } from "../pet/PetWhereUniqueInput";
import { UserWhereUniqueInput } from "../user/UserWhereUniqueInput";

export type SubscriptionWhereInput = {
  endDate?: DateTimeNullableFilter;
  id?: StringFilter;
  pet?: PetWhereUniqueInput;
  startDate?: DateTimeNullableFilter;
  status?: "Option1";
  user?: UserWhereUniqueInput;
};
