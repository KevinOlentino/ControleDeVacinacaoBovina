import { Endereco } from "./endereco";
import { Produtor } from "./produtor";

export class Propriedade{
  idPropriedade: number = 0;
  inscricaoEstadual: string = '';
  nome: string = '';
  idEndereco: number = 0;
  idProdutor: number = 0;
  endereco: Endereco = new Endereco();
  produtor: Produtor = new Produtor();
}
