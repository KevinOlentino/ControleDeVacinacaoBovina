import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class TipoDeEntradasService {

  rotaBase: string = 'https://localhost:44365/api/TipoDeEntrada';

  constructor(private http:HttpClient) { }

  listarTodos(): Observable<any>{
    return this.http.get<any>(this.rotaBase);
  }

}
