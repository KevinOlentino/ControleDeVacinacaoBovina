import { Municipio } from './municipio';

export class Endereco{
  idEndereco: number = 0;
  rua: String = '';
  numero: String = '';
  idMunicipio: number=0;
  municipio: Municipio = new Municipio();
}
