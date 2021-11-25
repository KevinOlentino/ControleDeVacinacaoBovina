import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class RebanhoService {

  rotaBase: string = 'https://localhost:44365/api/Rebanho';

  constructor(private http: HttpClient) { }

  listarPorProdutor(id: number): Observable<any> {
    return this.http.get<any>(`${this.rotaBase}/Produtor/${id}`);
  }

  listarPorPropriedade(id: number): Observable<any>{
    return this.http.get<any>(`${this.rotaBase}/Propriedade/${id}`);
  }
}
