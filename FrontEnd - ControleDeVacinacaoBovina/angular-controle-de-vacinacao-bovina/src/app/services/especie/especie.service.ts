import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class EspecieService {

  rotaBase: string = 'https://localhost:44365/api/Especie';

  constructor(private http:HttpClient) { }

  listarEspecies(): Observable<any>{
    return this.http.get<any>(this.rotaBase);
  }

}
