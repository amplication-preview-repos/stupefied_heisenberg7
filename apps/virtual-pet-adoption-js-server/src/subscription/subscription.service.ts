import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { SubscriptionServiceBase } from "./base/subscription.service.base";

@Injectable()
export class SubscriptionService extends SubscriptionServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
