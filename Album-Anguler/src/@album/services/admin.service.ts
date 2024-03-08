import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor( private http:HttpClient,
    private rout:Router   ) { }
  baseUrl="https://localhost:7122/api/GalleryAlbum/";
  headerrs={
headerrs: new HttpHeaders({
  'Content-Type': 'application/json',
}),
withCredentials: true,
  };

  RemoveProduct(ProdID: number): Observable<string> {
    return this.http
      .delete(this.baseUrl + 'RemoveProduct/' + ProdID, { responseType: 'text' })
      .pipe(
        catchError((err) => {
          return throwError(() => err.message || 'Internal Server Error');
        })
      );
  }
  ChangeProductApprove(ProdID: number, Approve: boolean) {
    return this.http
      .get(this.baseUrl +'UpdateProductApprove/'+ `${ProdID}/${Approve}`).pipe(catchError((err) => {
          return throwError(() => err.message || 'Internal Server Error');
        })
      );
  }












  GetById(id: number):Observable<any>{
    return this.http.get<any>(this.baseUrl+'GetById/'+id+'').pipe();
  }

  GetAll():Observable<any[]>{
    return this.http.get<any[]>(this.baseUrl+'GetAll').pipe();
  }

  Save(model: any):Observable<any>{
  return this.http.post<any>(this.baseUrl+'Save',model).pipe();
  }
  Delete(id: number){
    return this.http.delete(this.baseUrl + 'Delete/'+id+'',).pipe();
   }


}
