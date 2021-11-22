import { Animal } from "./animal";
import { Vacina } from "./vacina";

export class RegistroVacina{
  idRegistroVacinacao: number = 0;
  quantidade: number = 0;
  dataDaVacina: Date = new Date();
  idAnimal: number = 0;
  idVacina: number = 0;
  animal: Animal = new Animal();
  vacina: Vacina = new Vacina();
  ativo: boolean = true;
}
