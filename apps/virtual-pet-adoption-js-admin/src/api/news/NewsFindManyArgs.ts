import { NewsWhereInput } from "./NewsWhereInput";
import { NewsOrderByInput } from "./NewsOrderByInput";

export type NewsFindManyArgs = {
  where?: NewsWhereInput;
  orderBy?: Array<NewsOrderByInput>;
  skip?: number;
  take?: number;
};
