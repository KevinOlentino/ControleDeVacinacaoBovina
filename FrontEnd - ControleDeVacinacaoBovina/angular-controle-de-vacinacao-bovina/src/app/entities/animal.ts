import { Especie } from './especie';
import { Propriedade } from "./propriedade";

export class Animal {
	idAnimal: number = 0;
	quantidadeTotal: number = 0;
	quantidadeVacinada: number = 0;
	idEspecie: number = 0;
	idPropriedade: number = 0;
	ativo: boolean = false;
	propriedade: Propriedade = new Propriedade();
  especie: Especie = new Especie();
}
