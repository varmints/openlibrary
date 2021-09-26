import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookAddingComponent } from './books/book-adding/book-adding.component';
import { BookDetailComponent } from './books/book-detail/book-detail.component';
import { BookEditComponent } from './books/book-edit/book-edit.component';
import { BookListComponent } from './books/book-list/book-list.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'books', component: BookListComponent },
      { path: 'books/:id', component: BookDetailComponent },
      { path: 'book/:id/edit', component: BookEditComponent },
      { path: 'add-book', component: BookAddingComponent },
    ],
  },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
