import { JsonValue } from "type-fest";
import { Subscription } from "../subscription/Subscription";

export type Pet = {
  bio: string | null;
  createdAt: Date;
  dateOfBirth: Date | null;
  healthCondition: string | null;
  id: string;
  location: string | null;
  mainGalleryPhotos: JsonValue;
  name: string | null;
  numberOfOwners: number | null;
  personalityTraits?: Array<"Option1">;
  subscriptions?: Array<Subscription>;
  updatedAt: Date;
};
