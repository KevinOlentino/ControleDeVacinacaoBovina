import { Propriedade } from '../../../entities/propriedade';
import { PropriedadeService } from '../../../services/propriedade/propriedade.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-propriedade',
  templateUrl: './propriedade.component.html',
  styleUrls: ['./propriedade.component.css']
})
export class PropriedadeComponent implements OnInit {

  constructor(private propriedadeService: PropriedadeService) { }

  idProdutor?: number = Number(localStorage.getItem('idProdutor')?.toString());
  propriedades: Propriedade[] = [];

  ngOnInit() {
    if(this.idProdutor)
    this.propriedadeService.ListarPorProdutor(this.idProdutor).subscribe(
      dados => {this.propriedades = dados, console.log(this.propriedades)},
      error => console.log(error)
    )
  }

}
