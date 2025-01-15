import * as graphql from "@nestjs/graphql";
import { SubscriptionResolverBase } from "./base/subscription.resolver.base";
import { Subscription } from "./base/Subscription";
import { SubscriptionService } from "./subscription.service";

@graphql.Resolver(() => Subscription)
export class SubscriptionResolver extends SubscriptionResolverBase {
  constructor(protected readonly service: SubscriptionService) {
    super(service);
  }
}
