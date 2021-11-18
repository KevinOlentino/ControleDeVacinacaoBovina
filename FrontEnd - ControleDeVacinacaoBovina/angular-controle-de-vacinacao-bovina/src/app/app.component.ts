import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent {
  title = 'angular-controle-de-vacinacao-bovina';
  produtor: String = '';

  setProdutor(nome: String){
    this.produtor = nome;
  }
}
