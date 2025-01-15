import { InputJsonValue } from "../../types";
import { SubscriptionCreateNestedManyWithoutUsersInput } from "./SubscriptionCreateNestedManyWithoutUsersInput";

export type UserCreateInput = {
  email?: string | null;
  firstName?: string | null;
  lastName?: string | null;
  password: string;
  roles: InputJsonValue;
  subscriptionLevel?: "Option1" | null;
  subscriptionStatus?: "Option1" | null;
  subscriptions?: SubscriptionCreateNestedManyWithoutUsersInput;
  username: string;
};
