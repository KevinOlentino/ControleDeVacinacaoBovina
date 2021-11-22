import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class MunicipioService {

  rotaBase: String = 'https://localhost:44365/api/Municipio';

  constructor(private http: HttpClient) { }

  listarMuncipios(): Observable<any> {
    return this.http.get(`${this.rotaBase}`);
  }

}
