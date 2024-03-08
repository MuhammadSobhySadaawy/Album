import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { AlbumRequest } from 'src/@album/model/AlbumRequest';
import { AdminService } from 'src/@album/services/admin.service';
import { AttachmentsComponent } from 'src/shared/ui/components/attachments/attachments/attachments.component';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.scss'],
})
export class AlbumComponent implements OnInit {
  @ViewChild(AttachmentsComponent) mainImageComponent!: AttachmentsComponent;
  @ViewChild(AttachmentsComponent) attachmentsComponent!: AttachmentsComponent;

  Files: any[] = [];
  FilesCover: any[] = [];
  FilesAttachment: any[] = [];
  _ID: number = 0;
  GalleryImages: any = [];
  multiple: boolean = false;
  public Response?: any;
  formData!: FormGroup;
  albumRequest?: AlbumRequest = <AlbumRequest>{};
  constructor(
    private fb: FormBuilder,
    private Activeroute: ActivatedRoute,
    private adminService: AdminService,
    private tost: NgToastService
  ) {
    this._ID =
      this.Activeroute.snapshot.queryParamMap.get('id') != null
        ? Number.parseInt(
            this.Activeroute.snapshot.queryParamMap.get('id') || '{}'
          )
        : 0;
  }

  ngOnInit(): void {
    this.resetTheForm();
    if (this._ID > 0) {
      this.GetById();
    }
  }
  resetTheForm() {
    this.formData = this.fb.group({
      id: ['0'],
      title: ['', [Validators.required, Validators.maxLength(300)]],
      description: ['', Validators.maxLength(2000)],
      albumAttachments: [],
      coverAttachments: [],
    });
  }
  albumsAttachment: any[] = [];
  getFiles(list: any[]) {
    this.albumsAttachment = this.deepClone(list);
    this.albumsAttachment.forEach((item) => {
      item.galleryAlbumId = this._ID;
    });
    this.formData.patchValue({
      albumAttachments: this.albumsAttachment,
    });
  }
  CoverAttachment: any[] = [];
  getCoverImage(list: any[]) {
    this.CoverAttachment = this.deepClone(list);
    this.CoverAttachment.forEach((item) => {
      item.galleryAlbumId = this._ID;
    });
    this.formData.patchValue({
      coverAttachments: this.CoverAttachment,
    });
  }
  get Get_Title() {
    return this.formData.get('title');
  }
  get Get_Description() {
    return this.formData.get('description');
  }
  get Get_albumAttachments() {
    return this.formData.get('albumAttachments');
  }
  //--------------Deep Clone--------------//
  deepClone(obj: any): any {
    if (typeof obj !== 'object' || obj === null) {
      return obj;
    }

    let clone: any;

    if (Array.isArray(obj)) {
      clone = [];
      for (let i = 0; i < obj.length; i++) {
        clone[i] = this.deepClone(obj[i]);
      }
    } else {
      clone = {};
      for (const key in obj) {
        if (Object.prototype.hasOwnProperty.call(obj, key)) {
          clone[key] = this.deepClone(obj[key]);
        }
      }
    }
    return clone;
  }
  //--------------------------------------//
  resetAllImages() {
    this.mainImageComponent.ClearFiles();
    this.attachmentsComponent.ClearFiles();
  }
  Save() {
    this.albumRequest = {
      id: this._ID,
      title: this.Get_Title?.value,
      description: this.Get_Description?.value,
      coverPhoto: this.CoverAttachment[0],
      albumAttachments: this.albumsAttachment,
    };
    this.adminService.Save(this.albumRequest).subscribe({
      next: (value: any) => {
        this.resetTheForm();
        this.resetAllImages();
        this.Response.albumAttachments = [];
        this.FilesCover = [];
        if (this._ID > 0) {
          this.tost.success({
            detail: 'Update Successfully',
            summary: '',
            duration: 2000,
          });
          this.GetById();
        } else {
          this.tost.success({
            detail: 'Add Successfully',
            summary: '',
            duration: 2000,
          });
        }
      },
    });
  }

  GetById() {
    this.adminService.GetById(this._ID).subscribe({
      next: (value: any) => {
        this.Response = value;
        this.formData.patchValue({
          title: value.title,
          description: value.description,
        });
        this.Response.albumAttachments.forEach((attach: any) => {
          this.Files.push({
            id: attach.id,
            fileName: attach.fileName,
            filePath: attach.filePath,
            sortNumber: attach.sortNumber,
            galleryAlbumId: attach.galleryAlbumId,
            isDeleted: attach.isDeleted,
          });
        });
        this.FilesCover.push({
          id: this._ID,
          fileName: value.coverPhotoName,
          filePath: value.coverPhotoPath,
          sortNumber: 0,
          galleryAlbumId: this._ID,
          isDeleted: false,
        });
      },
    });
  }
}
