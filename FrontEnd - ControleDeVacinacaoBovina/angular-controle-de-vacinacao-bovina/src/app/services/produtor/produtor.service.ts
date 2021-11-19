import { Produtor } from '../../entities/produtor';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProdutorService {
  constructor(private http: HttpClient) {}

  rotaBase: String = 'https://localhost:44365/api/Produtor';

  ListarTodosProdutores(): Observable<any> {
    return this.http.get<any>(`${this.rotaBase}`);
  }

  ObterPorCPF(cpf: String): Observable<Produtor> {
    return this.http.get<Produtor>(`${this.rotaBase}/${cpf}`);
  }

  EditarProdutor(produtor: Produtor): Observable<any> {
    return this.http.put<Produtor>(`${this.rotaBase}`, produtor);
  }

  CadastrarProdutor(produtor: Produtor):Observable<any> {
    return this.http.post<Produtor>(`${this.rotaBase}`, produtor);
  }
}
