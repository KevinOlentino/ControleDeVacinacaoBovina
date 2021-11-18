import { Municipio } from './municipio';

export interface Endereco{
  IdEndereco: number,
  Rua: String,
  Numero: String,
  IdMunicipio: number,
  Municipio: Municipio
}
