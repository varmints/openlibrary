import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from 'src/app/_models/book';
import { BooksService } from 'src/app/_services/books.service';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.scss'],
})
export class BookDetailComponent implements OnInit {
  book!: Book;

  constructor(
    private bookService: BooksService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadBook();
  }

  loadBook() {
    this.bookService
      .getBook(Number(this.route.snapshot.paramMap.get('id')))
      .subscribe((book) => {
        this.book = book;
      });
  }
}
