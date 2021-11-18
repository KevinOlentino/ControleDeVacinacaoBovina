import { Endereco } from '../../../entities/endereco';
import { Municipio } from '../../../entities/municipio';
import { ProdutorService } from '../../../services/produtor/produtor.service';
import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Produtor } from 'src/app/entities/produtor';

@Component({
  selector: 'app-produtor',
  templateUrl: './produtor.component.html',
  styleUrls: ['./produtor.component.css']
})
export class ProdutorComponent implements OnInit {

  produtor: Produtor = new Produtor();

  municipios: Municipio[] = []

  constructor(private produtorService: ProdutorService) { }

  ngOnInit() {
  }

 Incluir(frm: NgForm){
   this.produtorService.CadastrarProdutor(this.produtor).subscribe(
     dados => alert("Produtor cadastrado com sucesso!"),
     error => alert("Erro ao cadastrar Produtor")
   )
 }



}
