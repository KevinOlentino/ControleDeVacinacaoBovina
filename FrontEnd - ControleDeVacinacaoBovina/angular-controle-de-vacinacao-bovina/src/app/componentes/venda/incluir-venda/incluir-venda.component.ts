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

@Component({
  selector: 'app-incluir-venda',
  templateUrl: './incluir-venda.component.html',
  styleUrls: ['./incluir-venda.component.css']
})
export class IncluirVendaComponent implements OnInit,AfterViewInit {

  venda: Venda = new Venda();
  especies: Especie[] = [];
  finalidadesDeVenda: FinalidadeDeVenda[]=[];
  propriedades: Propriedade[] = [];
  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());
  @ViewChild('frm')
  private frm!: NgForm ;

  constructor(private vendaService: VendaService, private propriedadeService: PropriedadeService,
              private finalidadeDeVendaService: FinalidadeDeVendaService, private especieService: EspecieService) { }

  ngOnInit(): void {
    if(this.idProdutor)
      this.propriedadeService.ListarPorProdutor(this.idProdutor).subscribe(
        dados => {this.propriedades = dados, console.log(this.propriedades)},
        error => console.log(error)
      )
    this.finalidadeDeVendaService.listaFinalidadeDeVenda().subscribe(
      dados => {this.finalidadesDeVenda = dados},
      error => console.log(error)
    )
    this.especieService.listarEspecies().subscribe(
        dados => {this.especies = dados},
        error => console.log(error)
    )
  }

  ngAfterViewInit() {
    // @ts-ignore
    document.getElementById('adicionarVenda').addEventListener('hidden.bs.modal',
      (event) => {
        this.frm.reset()
      }, false)
  }

  incluirVenda(frm: NgForm){
    console.log(this.venda);
    this.vendaService.CadastrarVenda(this.venda).subscribe(
      dados => {alert("Venda cadastrada com sucesso!")},
      error => {alert("Erro ao cadastrar venda")}
    )
  }

}
