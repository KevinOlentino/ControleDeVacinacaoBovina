import { RegistroVacina } from '../../entities/registrovacinacao';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RegistrovacinaService {
  constructor(private http: HttpClient) {}

  rotaBase: String = 'https://localhost:44365/api/RegistroVacina';

  ListarPorPropriedade(id:number): Observable<any> {
    return this.http.get<any>(`${this.rotaBase}/${id}`);
  }

  CadastrarProdutor(RegistroVacina: RegistroVacina): Observable<RegistroVacina> {
    return this.http.post<RegistroVacina>(`${this.rotaBase}`, RegistroVacina);
  }

  CancelarRegistroVacina(id: number): Observable<RegistroVacina> {
    return this.http.delete<RegistroVacina>(`${this.rotaBase}/${id}`);
  }
}
