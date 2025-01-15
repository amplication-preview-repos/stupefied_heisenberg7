import { NewsWhereInput } from "./NewsWhereInput";

export type NewsListRelationFilter = {
  every?: NewsWhereInput;
  some?: NewsWhereInput;
  none?: NewsWhereInput;
};
