import { Component, OnInit } from '@angular/core';
import {Produtor} from "../../entities/produtor";

@Component({
  selector: 'app-bem-vindo',
  templateUrl: './bem-vindo.component.html',
  styleUrls: ['./bem-vindo.component.css']
})
export class BemVindoComponent implements OnInit {
  nomeProdutor: String | null;

  constructor() {
    this.nomeProdutor = localStorage.getItem('nomeProdutor')
  }

  ngOnInit(): void {
  }

}
