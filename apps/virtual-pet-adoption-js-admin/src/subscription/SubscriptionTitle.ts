import { Subscription as TSubscription } from "../api/subscription/Subscription";

export const SUBSCRIPTION_TITLE_FIELD = "id";

export const SubscriptionTitle = (record: TSubscription): string => {
  return record.id?.toString() || String(record.id);
};
