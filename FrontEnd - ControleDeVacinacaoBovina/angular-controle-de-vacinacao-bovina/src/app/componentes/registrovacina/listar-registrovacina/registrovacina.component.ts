import { RegistrovacinaService } from '../../../services/registrovacina/registrovacina.service';
import { RegistroVacina } from '../../../entities/registrovacinacao';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-registrovacina',
  templateUrl: './registrovacina.component.html',
  styleUrls: ['./registrovacina.component.css']
})
export class RegistrovacinaComponent implements OnInit {

  registroVacinas: RegistroVacina[] = [];

  constructor(private registroVacinaService: RegistrovacinaService, private route:ActivatedRoute) { }

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.registroVacinaService.ListarPorPropriedade(id).subscribe(
      dados => {this.registroVacinas = dados, console.log(this.registroVacinas)},
      error => console.log(error)
    )

    //console.log(this.registroVacinas[0].dataDaVacina.getDate());
  }

}
