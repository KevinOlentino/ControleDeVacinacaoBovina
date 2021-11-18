import { Animal } from "./animal";
import { Vacina } from "./vacina";

export interface RegistroVacina{
  IdRegistroVacinacao: number,
  Quantidade: number,
  DataDaVacina: Date,
  IdAnimal: number,
  IdVacina: number,
  Animal: Animal,
  Vacina: Vacina,
  Ativo: boolean
}
