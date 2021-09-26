import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Book } from '../_models/book';

@Injectable({
  providedIn: 'root',
})
export class BooksService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getBooks() {
    return this.http.get<Book[]>(this.baseUrl + 'books');
  }

  getBook(id: number) {
    return this.http.get<Book>(this.baseUrl + 'books/' + id);
  }

  addNewBook(model: any) {
    return this.http.post(this.baseUrl + 'books/add-book', model);
  }

  updateBook(id: number, book: Book) {
    return this.http.put(this.baseUrl + 'books/' + id + '/edit-book', book);
  }
}
