import { News as TNews } from "../api/news/News";

export const NEWS_TITLE_FIELD = "title";

export const NewsTitle = (record: TNews): string => {
  return record.title?.toString() || String(record.id);
};
