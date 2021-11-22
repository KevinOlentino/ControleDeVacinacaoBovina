import { Propriedade } from '../../../entities/propriedade';
import { PropriedadeService } from '../../../services/propriedade/propriedade.service';
import {Component, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-propriedade',
  templateUrl: './propriedade.component.html',
  styleUrls: ['./propriedade.component.css']
})
export class PropriedadeComponent implements OnInit {

  constructor(private propriedadeService: PropriedadeService) { }

  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());
  propriedades: Propriedade[] = [];
  @Output("propriedade") propriedade: Propriedade = new Propriedade();

  ngOnInit() {
    if(this.idProdutor)
    this.propriedadeService.ListarPorProdutor(this.idProdutor).subscribe(
      dados => {this.propriedades = dados, console.log(this.propriedades)},
      error => console.log(error)
    )
  }

  getPropriedade(propriedade: Propriedade){
    console.log(propriedade);
    this.propriedade = propriedade;
  }

}
