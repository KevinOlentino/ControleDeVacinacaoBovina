import { FinalidadeDeVenda } from "./finalidadedevenda";
import { Propriedade } from "./propriedade";
import {Rebanho} from "./rebanho";

export class Venda{
   idVenda: number = 0;
   quantidade?: number;
   idOrigem?: number;
   idDestino?: number;
   idRebanho?: number;
   idFinalidadeDeVenda?: number;
   ativo: Boolean = true;
   origem: Propriedade = new Propriedade();
   destino: Propriedade = new Propriedade();
   rebanho: Rebanho = new Rebanho();
   finalidadeDeVenda: FinalidadeDeVenda = new FinalidadeDeVenda();
}
