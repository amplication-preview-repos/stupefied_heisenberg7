import { SubscriptionWhereInput } from "./SubscriptionWhereInput";
import { SubscriptionOrderByInput } from "./SubscriptionOrderByInput";

export type SubscriptionFindManyArgs = {
  where?: SubscriptionWhereInput;
  orderBy?: Array<SubscriptionOrderByInput>;
  skip?: number;
  take?: number;
};
