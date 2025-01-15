import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { NewsServiceBase } from "./base/news.service.base";

@Injectable()
export class NewsService extends NewsServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
