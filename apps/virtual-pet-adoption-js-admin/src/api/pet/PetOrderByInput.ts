import { SortOrder } from "../../util/SortOrder";

export type PetOrderByInput = {
  bio?: SortOrder;
  createdAt?: SortOrder;
  dateOfBirth?: SortOrder;
  healthCondition?: SortOrder;
  id?: SortOrder;
  location?: SortOrder;
  mainGalleryPhotos?: SortOrder;
  name?: SortOrder;
  numberOfOwners?: SortOrder;
  personalityTraits?: SortOrder;
  updatedAt?: SortOrder;
};
