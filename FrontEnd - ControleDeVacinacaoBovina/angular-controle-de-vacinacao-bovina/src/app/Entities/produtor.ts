import { Endereco } from './endereco';
export interface Produtor{
  IdProdutor: number,
  Nome: string,
  CPF: string,
  IdEndereco: number,
  Endereco: Endereco
}
