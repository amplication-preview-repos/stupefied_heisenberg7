import { SortOrder } from "../../util/SortOrder";

export type NewsOrderByInput = {
  content?: SortOrder;
  createdAt?: SortOrder;
  id?: SortOrder;
  publishDate?: SortOrder;
  title?: SortOrder;
  updatedAt?: SortOrder;
};
