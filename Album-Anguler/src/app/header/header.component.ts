import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { Subscription } from 'rxjs';



@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {

  constructor(
    public dialog: MatDialog,
    private tost: NgToastService,


    private route: Router
  ) {



  }
  changimg() {

  }


  public countProduct: number = 0;

  CountOfFavoriteProduct: number = 0;
  errorMSG: any;
  islogin = false;

  img = '';
  name = '';
  role = false;
  roleadmin = false;
  roleadelivery=false;
  userID = '';
  ngOnInit(): void {

    this.CountCartpro();
    this.CountFav();
  }

  CountFav() {

  }

  CountCartpro() {

  }

  ngLogin() {

  }

  getfavier() {
    this.tost.success({ detail: 'ff', summary: 'gg' });
  }
  ngLogOut() {

    this.islogin = false;
    this.countProduct = 0;
    this.CountOfFavoriteProduct = 0;
    location.href = 'home';
  }
  ngSignup() {

  }

  gocart() {

  }

  gofav() {

  }
}
