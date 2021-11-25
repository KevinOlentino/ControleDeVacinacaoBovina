import { Especie } from './especie';
import { Propriedade } from "./propriedade";
import {tipoDeEntradas} from "./tipodeentradas";

export class Animal {
	idAnimal: number = 0;
	quantidadeTotal?: number;
	quantidadeVacinada?: number;
	idEspecie: number = 0;
	idPropriedade: number = 0;
  idTipoDeEntrada: number = 0;
	ativo: boolean = true;
	propriedade: Propriedade = new Propriedade();
  especie: Especie = new Especie();
  tipoDeEntrada: tipoDeEntradas = new tipoDeEntradas();
}
