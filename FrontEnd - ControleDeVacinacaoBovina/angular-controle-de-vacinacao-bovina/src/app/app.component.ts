import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'angular-controle-de-vacinacao-bovina';
  nomeProdutor: String | null;

  constructor(private cd: ChangeDetectorRef){
    this.nomeProdutor = localStorage.getItem('nomeProdutor')
  }

  setProdutor(id: Number,nome: string){
    localStorage.setItem('nomeProdutor', `${nome.split(" ")[0]} ${nome.split(" ")[1]} `)
    localStorage.setItem('idProdutor', id.toString());
    this.nomeProdutor = nome.split(" ")[0];
    this.cd.detectChanges();
  }
}

