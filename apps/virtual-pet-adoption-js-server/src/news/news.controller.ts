import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { NewsService } from "./news.service";
import { NewsControllerBase } from "./base/news.controller.base";

@swagger.ApiTags("news")
@common.Controller("news")
export class NewsController extends NewsControllerBase {
  constructor(protected readonly service: NewsService) {
    super(service);
  }
}
