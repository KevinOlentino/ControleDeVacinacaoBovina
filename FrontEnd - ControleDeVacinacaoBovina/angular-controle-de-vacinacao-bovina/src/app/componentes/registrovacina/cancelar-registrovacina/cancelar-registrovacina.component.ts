import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {RegistroVacina} from "../../../entities/registrovacinacao";
import {RegistrovacinaService} from "../../../services/registrovacina/registrovacina.service";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-cancelar-registrovacina',
  templateUrl: './cancelar-registrovacina.component.html',
  styleUrls: ['./cancelar-registrovacina.component.css']
})
export class CancelarRegistrovacinaComponent implements OnInit {

  @Input("registroVacina") registroVacina: RegistroVacina = new RegistroVacina();
  @ViewChild('buttonClose')
  private buttonClose: { nativeElement: { click: () => any; }; } | undefined;

  private error: any;

  constructor(private registroVacinaService: RegistrovacinaService) { }

  ngOnInit(){
  }

  cancelarRegistroVacina(id: number){
    this.registroVacinaService.CancelarRegistroVacina(id).subscribe(
      dados => {
        this.buttonClose?.nativeElement.click(),
          alert("Registro de Vacina cancelada com sucesso!"),
          window.location.reload()
      },
      error => {
        this.registrarErro(error);
      }
    )
  }
  registrarErro(error: HttpErrorResponse) {
    this.error = error.error
    if (this.error.error != undefined)
      alert(this.error.error);
  }
}
