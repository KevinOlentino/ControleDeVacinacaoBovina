import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class FinalidadeDeVendaService {

  rotaBase: string = "https://localhost:44365/api/FinalidadeDeVenda";

  constructor(private http: HttpClient) { }

  listaFinalidadeDeVenda(): Observable<any>{
    return this.http.get(this.rotaBase);
  }

}
