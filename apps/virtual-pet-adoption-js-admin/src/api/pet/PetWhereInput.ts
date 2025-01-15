import { StringNullableFilter } from "../../util/StringNullableFilter";
import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { JsonFilter } from "../../util/JsonFilter";
import { IntNullableFilter } from "../../util/IntNullableFilter";
import { SubscriptionListRelationFilter } from "../subscription/SubscriptionListRelationFilter";

export type PetWhereInput = {
  bio?: StringNullableFilter;
  dateOfBirth?: DateTimeNullableFilter;
  healthCondition?: StringNullableFilter;
  id?: StringFilter;
  location?: StringNullableFilter;
  mainGalleryPhotos?: JsonFilter;
  name?: StringNullableFilter;
  numberOfOwners?: IntNullableFilter;
  subscriptions?: SubscriptionListRelationFilter;
};
