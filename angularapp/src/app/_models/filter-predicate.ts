import { User } from './user';

export interface FilterPredicate {
  [key: string]: (data: User, filter: string) => boolean;
}
