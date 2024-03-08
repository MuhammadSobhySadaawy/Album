import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-acess-denied',
  templateUrl: './acess-denied.component.html',
  styleUrls: ['./acess-denied.component.scss']
})
export class AcessDeniedComponent implements OnInit {

  constructor(private rout:Router) { }

  ngOnInit(): void {
  }
  home(){
    this.rout.navigate(['home']).then(x=>{window.location.reload();})

  }
}
