import { Vacina } from "./vacina";
import {Rebanho} from "./rebanho";

export class RegistroVacina{
  idRegistroVacinacao: number = 0;
  quantidade: number = 0;
  dataDaVacina: Date = new Date();
  idRebanho: number = 0;
  idVacina: number = 0;
  rebanho: Rebanho = new Rebanho();
  vacina: Vacina = new Vacina();
  ativo: boolean = true;
}
