import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import {MatDialogModule} from '@angular/material/dialog';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { NgxPaginationModule } from 'ngx-pagination';
import { AcessDeniedComponent } from './acess-denied/acess-denied.component';
import { ReactiveFormsModule, FormsModule, NgModel } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';

import {MatMenuModule} from '@angular/material/menu';

import { MatInputModule } from '@angular/material/input';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import {MatIconModule} from '@angular/material/icon';
import { NgToastModule } from 'ng-angular-popup';
import { NgxPrintModule } from 'ngx-print';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { AlbumViewComponent } from './album-view/album-view.component';
import { AlbumComponent } from './album/album.component';
import { GalleryModule } from 'ng-gallery';
import { AdminService } from 'src/@album/services/admin.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { SharedModule } from 'src/shared/shared.module';
@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    HomeComponent,
    PageNotFoundComponent,
    AcessDeniedComponent,
    AlbumViewComponent,
    AlbumComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    GalleryModule,
     MatDialogModule,
    CarouselModule,
    NgxPaginationModule,
SharedModule,
    MatMenuModule,
    MatIconModule,
    NgToastModule ,
    MatFormFieldModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
    ReactiveFormsModule,
    FormsModule,HttpClientModule,
    MatInputModule,
    MatAutocompleteModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
   NgxPrintModule,Ng2SearchPipeModule
  ],
  providers: [AdminService],
  bootstrap: [AppComponent]
})
export class AppModule { }
