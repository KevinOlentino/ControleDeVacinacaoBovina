import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from "@angular/forms";
import {VendaService} from "../../../services/venda/venda.service";
import {Venda} from "../../../entities/venda";
import {Especie} from "../../../entities/especie";
import {FinalidadeDeVenda} from "../../../entities/finalidadedevenda";
import {Propriedade} from "../../../entities/propriedade";
import {PropriedadeService} from "../../../services/propriedade/propriedade.service";
import {FinalidadeDeVendaService} from "../../../services/finalidadeDeVenda/finalidade-de-venda.service";
import {EspecieService} from "../../../services/especie/especie.service";
import {HttpErrorResponse} from "@angular/common/http";
import {tipoDeEntradas} from "../../../entities/tipodeentradas";
import {TipoDeEntradasService} from "../../../services/tipoDeEntradas/tipo-de-entradas.service";
import {RebanhoService} from "../../../services/rebanho/rebanho.service";
import {Rebanho} from "../../../entities/rebanho";

@Component({
  selector: 'app-incluir-venda',
  templateUrl: './incluir-venda.component.html',
  styleUrls: ['./incluir-venda.component.css']
})
export class IncluirVendaComponent implements OnInit, AfterViewInit {

  venda: Venda = new Venda();
  rebanhos: Rebanho[] = [];
  finalidadesDeVenda: FinalidadeDeVenda[] = [];
  propriedades: Propriedade[] = [];
  inscricaoEstadual: string = '';
  date: Date = new Date();
  propriedadeDestino: Propriedade = new Propriedade();
  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());

  @ViewChild('frm')
  private frm!: NgForm;
  @ViewChild('buttonClose')
  private buttonClose: { nativeElement: { click: () => any; }; } | undefined;

  error: any;

  private today: Date = new Date();

  constructor(private vendaService: VendaService, private propriedadeService: PropriedadeService,
              private finalidadeDeVendaService: FinalidadeDeVendaService, private rebanhoService: RebanhoService) {
  }

  ngOnInit(): void {
    this.finalidadeDeVendaService.listaFinalidadeDeVenda().subscribe(
      dados => {
        this.finalidadesDeVenda = dados
      },
      error => console.log(error)
    )
    if(this.idProdutor)
    this.propriedadeService.ListarPorProdutor(this.idProdutor).subscribe(
      dados => this.propriedades = dados,
      error => console.log(error)
    )
  }

  ngAfterViewInit() {
    // @ts-ignore
    document.getElementById('adicionarVenda').addEventListener('hidden.bs.modal',
      (event) => {
      this.propriedadeDestino = new Propriedade();
        this.frm.reset({idFinalidadeDeVenda:0,idOrigem:0,idRebanho:0})
        this.error = undefined;
        this.venda = new Venda();
      }, false)
  }

  incluirVenda(frm: NgForm) {
    this.verifyPropriedade();
    this.venda.idDestino = this.propriedadeDestino.idPropriedade;
    this.vendaService.CadastrarVenda(this.venda).subscribe(
      dados => {
        this.buttonClose?.nativeElement.click(),
          alert("Venda cadastrada com sucesso!"),
          window.location.reload()
      },
      error => {
        console.log(error);
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
      console.log(this.error)
    }
  }

  verifyPropriedade(){
      if(this.inscricaoEstadual == null|| this.inscricaoEstadual.length < 9 || this.inscricaoEstadual.length > 10)
          alert("Inscrição Estadual somente de 9 digitos")
      else
      this.propriedadeService.ObterPorInscricaoEstadual(this.inscricaoEstadual).subscribe(
        dados => {this.propriedadeDestino = dados},
        error => {this.propriedadeDestino= new Propriedade(), alert("Inscrição Estadual não encontrada!")}
      )
  }

  atualizarRebanhos(){
    if(this.venda.idOrigem)
      this.rebanhoService.listarPorPropriedade(this.venda.idOrigem).subscribe(
        dados => {this.rebanhos = dados},
        error => this.rebanhos = []
      )
  }
}
