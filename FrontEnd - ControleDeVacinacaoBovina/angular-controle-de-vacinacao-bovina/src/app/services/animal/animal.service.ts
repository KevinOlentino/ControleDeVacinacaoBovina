import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Animal } from 'src/app/entities/animal';

@Injectable({
  providedIn: 'root',
})
export class AnimalService {
  constructor(private http: HttpClient) {}

  rotaBase: String = 'https://localhost:44365/api/Animal';

  listarPorProdutor(id: number): Observable<any> {
    return this.http.get<any>(`${this.rotaBase}/Produtor/${id}`);
  }

  listarPorPropriedade(id: number): Observable<any>{
    return this.http.get<any>(`${this.rotaBase}/Propriedade/${id}`);
  }

  CadastrarAnimais(animal: Animal):Observable<Animal>{
    return this.http.post<Animal>(`${this.rotaBase}`, animal);
  }

  CancelarRegistroAnimal(id: number):Observable<Animal>{
    return this.http.delete<Animal>(`${this.rotaBase}/${id}`);
  }
}
