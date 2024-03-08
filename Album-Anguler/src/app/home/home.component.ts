import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { AdminService } from 'src/@album/services/admin.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  errorMSG = '';
  prodIsFavorite: any;
  errorfavo: any;

  // gotoProductDetails = (ID: Number) => {
  //   this.rout.navigate(['/product/details/', ID]);
  // };

  additionalDetails!: string;
  displayedColumns: string[] = [
    'id',
    'title',
    'description',
    'coverPhoto',
    'numberOfPhotos',
    'action',
  ];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  userID!: string;
  search: any;
  constructor(private dialog: MatDialog, private adminService: AdminService,  private tost: NgToastService) {}

  ngOnInit(): void {
    this.GetAll();
  }


GetAll(){
  this.adminService.GetAll().subscribe((e) => {
    this.dataSource = new MatTableDataSource(e);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  });
}


  applyFilter(event: any) {
    this.dataSource.filter = event.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  GoDelete(id: number) {
    this.adminService.Delete(id).subscribe({
      next: (value: any) => {
        this.tost.success({
          detail: 'Deleted Successfully',
          summary: "",
          duration: 2000,
        });
          this.GetAll();
      },
    });
  }

  GoEdit(id: number) {
    window.open('/Album/add?id=' + id + '', '_blank');

  }
  AddData() {
    window.open('Album/add?id=' + 0 + '', '_blank');
  }

  GoView(id: number) {
    window.open('/AlbumView/add?id=' + id + '', '_blank');
  }
}
