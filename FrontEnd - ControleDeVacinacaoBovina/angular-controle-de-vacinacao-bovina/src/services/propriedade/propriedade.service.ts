import { Propriedade } from './../../app/Entities/propriedade';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PropriedadeService {
  rotaBase: String = 'https://localhost:44365/api/Propriedade';

  constructor(private http: HttpClient) {}

  ListarPorProdutor(id: number): Observable<any> {
    return this.http.get<any>(`${this.rotaBase}/Produtor/${id}`);
  }

  ObterPorInscricaoEstadual(inscricaoEstudal: String) {
    return this.http.get<Propriedade>(`${this.rotaBase}/${inscricaoEstudal}`);
  }

  EditarPropriedade(propriedade: Propriedade): Observable<any> {
    return this.http.put<Propriedade>(`${this.rotaBase}`, propriedade);
  }

  CadastrarPropriedade(propriedade: Propriedade) {
    return this.http.post<Propriedade>(`${this.rotaBase}`, propriedade);
  }
}
