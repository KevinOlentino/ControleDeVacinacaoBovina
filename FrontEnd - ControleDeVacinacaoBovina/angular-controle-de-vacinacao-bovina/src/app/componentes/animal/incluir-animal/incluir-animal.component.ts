import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  ElementRef,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild
} from '@angular/core';
import {NgForm} from "@angular/forms";
import {AnimalService} from "../../../services/animal/animal.service";
import {Animal} from "../../../entities/animal";
import {Propriedade} from "../../../entities/propriedade";
import {Especie} from "../../../entities/especie";
import {EspecieService} from "../../../services/especie/especie.service";
import {PropriedadeService} from "../../../services/propriedade/propriedade.service";
import {HttpErrorResponse} from "@angular/common/http";
import {tipoDeEntradas} from "../../../entities/tipodeentradas";
import {TipoDeEntradasService} from "../../../services/tipoDeEntradas/tipo-de-entradas.service";

@Component({
  selector: 'app-incluir-animal',
  templateUrl: './incluir-animal.component.html',
  styleUrls: ['./incluir-animal.component.css']
})
export class IncluirAnimalComponent implements OnInit, AfterViewInit {

  animal: Animal = new Animal();
  propriedades: Propriedade[] = [];
  especies: Especie [] = []
  tipoDeEntradas: tipoDeEntradas [] = []
  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());
  @ViewChild('frm')
  private frm!: NgForm;
  @ViewChild('buttonClose')
  private buttonClose: { nativeElement: { click: () => any; }; } | undefined;

  error: any;

  constructor(private animalService: AnimalService, private especieService: EspecieService,
              private propriedadeService: PropriedadeService, private tipoDeEntradaService: TipoDeEntradasService) {
  }

  ngOnInit(): void {
    if (this.idProdutor)
      this.propriedadeService.ListarPorProdutor(this.idProdutor).subscribe(
        dados => {
          this.propriedades = dados, console.log(this.propriedades)
        },
        error => console.log(error)
      )
    this.especieService.listarEspecies().subscribe(
      dados => {
        this.especies = dados, console.log(this.especies)
      },
      error => console.log(error)
    )
    this.tipoDeEntradaService.listarTodos().subscribe(
      dados => {
        this.tipoDeEntradas = dados, console.log(this.tipoDeEntradas)
      },
      error => console.log(error)
    )
  }

  ngAfterViewInit() {
    // @ts-ignore
    document.getElementById('adicionarAnimal').addEventListener('hidden.bs.modal',
      (event) => {
        this.error = undefined;
        this.frm.form.reset({IdPropriedade: 0, idEspecie: 0})
        this.animal = new Animal();
      }, false)
  }

  incluir(frm: NgForm) {
    console.log(this.animal);
    this.animalService.CadastrarAnimais(this.animal).subscribe(
      dados => {
        this.buttonClose?.nativeElement.click(),
        alert("Animal cadastrado com sucesso!"),
          window.location.reload()
      },
      error => {
        this.registrarErro(error);
      }
    )
  }

  registrarErro(error: HttpErrorResponse) {
    this.error = error.error
    if (this.error.error != undefined)
      alert(this.error.error);
    if(this.error.errors != undefined) {
      let error: string[] = [];
      this.error = this.error.errors;
    }
  }
}
