import { Endereco } from "./endereco";
import { Produtor } from "./produtor";

export interface Propriedade{
  IdPropriedade: number,
  InscricaoEstadual: string,
  Nome: string,
  IdEndereco: number,
  IdProdutor: number,
  Endereco: Endereco,
  Produtor: Produtor
}
