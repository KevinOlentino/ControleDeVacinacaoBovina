import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Venda } from 'src/app/entities/venda';

@Injectable({
  providedIn: 'root',
})
export class VendaService {
  constructor(private http: HttpClient) {}

  rotaBase: String = 'https://localhost:44365/api/Venda';

  listarPorOrigem(id: number): Observable<any> {
    return this.http.get<any>(`${this.rotaBase}/Origem/${id}`);
  }

  listarPorDestino(id: number): Observable<any> {
    return this.http.get<any>(`${this.rotaBase}/Destino/${id}`);
  }

  CadastrarVenda(venda: Venda): Observable<Venda> {
    return this.http.post<Venda>(`${this.rotaBase}`, venda);
  }

  CancelarRegistroAnimal(id: number) {
    return this.http.delete<Venda>(`${this.rotaBase}/${id}`);
  }
}
