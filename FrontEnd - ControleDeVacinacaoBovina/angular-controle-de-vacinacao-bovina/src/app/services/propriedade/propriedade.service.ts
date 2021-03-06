import { Propriedade } from '../../entities/propriedade';
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

  ObterPorInscricaoEstadual(inscricaoEstudal: String):Observable<any> {
    return this.http.get<Propriedade>(`${this.rotaBase}/${inscricaoEstudal}`);
  }

  EditarPropriedade(id:number,propriedade: Propriedade): Observable<any> {
    return this.http.put<Propriedade>(`${this.rotaBase}/${id}`, propriedade);
  }

  CadastrarPropriedade(propriedade: Propriedade):Observable<any> {
    return this.http.post<Propriedade>(`${this.rotaBase}`, propriedade);
  }
}
