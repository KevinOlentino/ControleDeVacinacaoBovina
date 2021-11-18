import { Endereco } from './endereco';

export class Produtor{
  idProdutor: number = 0;
  nome: string = '';
  cpf: string = '';
  idEndereco: number = 0;
  endereco: Endereco = new Endereco();
}
