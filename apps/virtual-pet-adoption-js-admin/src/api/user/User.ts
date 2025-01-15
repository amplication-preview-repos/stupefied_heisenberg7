import { JsonValue } from "type-fest";
import { Subscription } from "../subscription/Subscription";

export type User = {
  createdAt: Date;
  email: string | null;
  firstName: string | null;
  id: string;
  lastName: string | null;
  roles: JsonValue;
  subscriptionLevel?: "Option1" | null;
  subscriptionStatus?: "Option1" | null;
  subscriptions?: Array<Subscription>;
  updatedAt: Date;
  username: string;
};
