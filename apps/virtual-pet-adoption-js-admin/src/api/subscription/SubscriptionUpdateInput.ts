import { PetWhereUniqueInput } from "../pet/PetWhereUniqueInput";
import { UserWhereUniqueInput } from "../user/UserWhereUniqueInput";

export type SubscriptionUpdateInput = {
  endDate?: Date | null;
  pet?: PetWhereUniqueInput | null;
  startDate?: Date | null;
  status?: "Option1" | null;
  user?: UserWhereUniqueInput | null;
};
