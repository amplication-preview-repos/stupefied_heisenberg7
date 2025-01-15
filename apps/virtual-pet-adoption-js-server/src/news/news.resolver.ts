import * as graphql from "@nestjs/graphql";
import { NewsResolverBase } from "./base/news.resolver.base";
import { News } from "./base/News";
import { NewsService } from "./news.service";

@graphql.Resolver(() => News)
export class NewsResolver extends NewsResolverBase {
  constructor(protected readonly service: NewsService) {
    super(service);
  }
}
