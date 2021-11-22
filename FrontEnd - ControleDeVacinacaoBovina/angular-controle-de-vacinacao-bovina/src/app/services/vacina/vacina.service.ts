import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class VacinaService {

  rotaBase: string = 'https://localhost:44365/api/Vacina';

  constructor(private http:HttpClient) { }

  listarVacina(): Observable<any>{
    return this.http.get<any>(this.rotaBase);
  }

}
