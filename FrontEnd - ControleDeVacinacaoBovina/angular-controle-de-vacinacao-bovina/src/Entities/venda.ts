import { FinalidadeDeVenda } from './finalidadedevenda';
import { Especie } from './especie';
import { Propriedade } from './propriedade';
export interface Venda{
   IdVenda: number,
   Quantidade: number,
   IdOrigem: number,
   IdDestino: number,
   IdEspecie: number,
   IdFinalidadeDeVenda: number,
   Ativo: Boolean,
   Origem: Propriedade,
   Destino: Propriedade,
   Especie: Especie,
   FinalidadeDeVenda: FinalidadeDeVenda
}
