import { Component, OnInit } from '@angular/core';
import {Produtor} from "../../entities/produtor";
import {Router} from "@angular/router";

@Component({
  selector: 'app-bem-vindo',
  templateUrl: './bem-vindo.component.html',
  styleUrls: ['./bem-vindo.component.css']
})
export class BemVindoComponent implements OnInit {
  nomeProdutor: String | null;

  constructor(private router: Router) {
    this.nomeProdutor = localStorage.getItem('nomeProdutor')
  }

  ngOnInit(): void {
  }

  goToPage(pageName: String){
    this.router.navigate([pageName])
  }

}
