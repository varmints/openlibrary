import { Book } from './book';

export interface Member {
  id: number;
  username: string;
  books: Book[];
}
