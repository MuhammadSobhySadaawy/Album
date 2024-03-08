import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AttachmentsComponent } from './components/attachments/attachments/attachments.component';


@NgModule({
  declarations: [
    AttachmentsComponent,
  ],
  imports: [

    CommonModule,
    ReactiveFormsModule,
    FormsModule,

    HttpClientModule,


  ],
  exports: [

    FormsModule,

    ReactiveFormsModule,

    AttachmentsComponent,



  ],
  providers: [

  ],
})
export class UIModule {}
