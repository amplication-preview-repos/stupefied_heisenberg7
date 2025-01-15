import { NewsWhereUniqueInput } from "./NewsWhereUniqueInput";
import { NewsUpdateInput } from "./NewsUpdateInput";

export type UpdateNewsArgs = {
  where: NewsWhereUniqueInput;
  data: NewsUpdateInput;
};
