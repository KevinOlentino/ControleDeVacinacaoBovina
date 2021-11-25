import {Especie} from "./especie";
import {Propriedade} from "./propriedade";

export class Rebanho {
  idRebanho: number = 0;
  quantidadeTotal: number = 0;
  quantidadeVacinada: number = 0;
  idEspecie: number = 0;
  idPropriedade: number = 0;
  especie: Especie = new Especie();
  propriedade: Propriedade = new Propriedade();
}
