import { Component, OnInit } from '@angular/core';
import { BooksService } from 'src/app/_services/books.service';

@Component({
  selector: 'app-book-adding',
  templateUrl: './book-adding.component.html',
  styleUrls: ['./book-adding.component.scss'],
})
export class BookAddingComponent implements OnInit {
  model: any = {};

  constructor(private booksService: BooksService) {}

  ngOnInit(): void {}

  addNewBook() {
    this.booksService.addNewBook(this.model).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
