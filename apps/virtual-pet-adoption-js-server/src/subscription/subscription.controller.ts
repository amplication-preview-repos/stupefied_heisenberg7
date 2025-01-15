import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { SubscriptionService } from "./subscription.service";
import { SubscriptionControllerBase } from "./base/subscription.controller.base";

@swagger.ApiTags("subscriptions")
@common.Controller("subscriptions")
export class SubscriptionController extends SubscriptionControllerBase {
  constructor(protected readonly service: SubscriptionService) {
    super(service);
  }
}
