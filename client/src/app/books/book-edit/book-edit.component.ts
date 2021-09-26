import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Book } from 'src/app/_models/book';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { BooksService } from 'src/app/_services/books.service';

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.scss'],
})
export class BookEditComponent implements OnInit {
  @ViewChild('editBookForm') editBookForm!: NgForm;
  user!: User | null;
  book!: Book;

  constructor(
    private accountService: AccountService,
    private booksService: BooksService,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {
    this.accountService.currentUser$
      .pipe(take(1))
      .subscribe((user) => (this.user = user));
  }

  ngOnInit(): void {
    this.loadBook();
  }

  loadBook() {
    this.booksService
      .getBook(Number(this.route.snapshot.paramMap.get('id')))
      .subscribe((book) => {
        this.book = book;
      });
  }

  updateBook() {
    this.booksService
      .updateBook(Number(this.route.snapshot.paramMap.get('id')), this.book)
      .subscribe(() => {
        this.toastr.success('Book update successfully');
        this.editBookForm.reset(this.book);
      });
  }
}
