import { Especie } from "./especie";
import { FinalidadeDeVenda } from "./finalidadedevenda";
import { Propriedade } from "./propriedade";

export class Venda{
   idVenda: number = 0;
   quantidade: number = 0;
   idOrigem: number = 0;
   idDestino: number = 0;
   idEspecie: number = 0;
   idFinalidadeDeVenda: number =0;
   ativo: Boolean = true;
   origem: Propriedade = new Propriedade();
   destino: Propriedade = new Propriedade();
   especie: Especie = new Especie();
   finalidadeDeVenda: FinalidadeDeVenda = new FinalidadeDeVenda();
}
