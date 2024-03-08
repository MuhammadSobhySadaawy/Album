import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { GalleryItem, ImageItem } from 'ng-gallery';
import { AdminService } from 'src/@album/services/admin.service';

@Component({
  selector: 'app-album-view',
  templateUrl: './album-view.component.html',
  styleUrls: ['./album-view.component.scss'],
})
export class AlbumViewComponent implements OnInit {
  Product!: any;
  errorMSG = '';
  errorImg = '';
  errorfavo = '';
  errorComment = '';

  Imgs: any;
  albumId: number = 0;

  Imgss!: GalleryItem[];
albumDetails:any;
  constructor(
    private ActRoute: ActivatedRoute,
    private adminService: AdminService,
    private tost: NgToastService
  ) {
    this.albumId =
      this.ActRoute.snapshot.queryParamMap.get('id') != null
        ? Number.parseInt(
            this.ActRoute.snapshot.queryParamMap.get('id') || '{}'
          )
        : 0;
  }
  images: any = [];
  maxquantity!: number;

  userID = '';
  imgg = '';

  ngOnInit(): void {
    if (this.albumId > 0) {
      this.adminService.GetById(this.albumId).subscribe({
        next: (data: any) => {
          this.Imgs = data.albumAttachments;
          this.albumDetails=data;
          let ggg = [];
          for (let index = 0; index < data.albumAttachments.length; index++) {
            ggg[index] = new ImageItem({
              src: data.albumAttachments[index].filePath,
              thumb: data.albumAttachments[index].filePath,
            });
          }
          this.Imgss = ggg;
          console.log(this.Imgss);
        },
      });
    }
  }
}
