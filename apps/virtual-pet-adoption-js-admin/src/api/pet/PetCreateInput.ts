import { InputJsonValue } from "../../types";
import { SubscriptionCreateNestedManyWithoutPetsInput } from "./SubscriptionCreateNestedManyWithoutPetsInput";

export type PetCreateInput = {
  bio?: string | null;
  dateOfBirth?: Date | null;
  healthCondition?: string | null;
  location?: string | null;
  mainGalleryPhotos?: InputJsonValue;
  name?: string | null;
  numberOfOwners?: number | null;
  personalityTraits?: Array<"Option1">;
  subscriptions?: SubscriptionCreateNestedManyWithoutPetsInput;
};
