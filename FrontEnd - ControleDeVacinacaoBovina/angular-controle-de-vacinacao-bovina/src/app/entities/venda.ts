import { FinalidadeDeVenda } from "./finalidadedevenda";
import { Propriedade } from "./propriedade";
import {Rebanho} from "./rebanho";

export class Venda{
   idVenda: number = 0;
   quantidade?: number;
   idOrigem: number= 0;
   idDestino?: number;
   idRebanho: number= 0;
   idFinalidadeDeVenda: number= 0;
   ativo: Boolean = true;
   origem: Propriedade = new Propriedade();
   destino: Propriedade = new Propriedade();
   rebanho: Rebanho = new Rebanho();
   dataDeVenda: Date = new Date();
   finalidadeDeVenda: FinalidadeDeVenda = new FinalidadeDeVenda();
}
