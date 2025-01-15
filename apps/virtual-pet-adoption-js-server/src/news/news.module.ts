import { Module } from "@nestjs/common";
import { NewsModuleBase } from "./base/news.module.base";
import { NewsService } from "./news.service";
import { NewsController } from "./news.controller";
import { NewsResolver } from "./news.resolver";

@Module({
  imports: [NewsModuleBase],
  controllers: [NewsController],
  providers: [NewsService, NewsResolver],
  exports: [NewsService],
})
export class NewsModule {}
