import { Component,Input } from '@angular/core';

@Component({
  selector: 'app-lstuser',
  templateUrl:'./lstuser.component.html'
})

export class LstuserComponent{
  @Input() oLstuser: Usuario;
}

interface Usuario {
  usuID: number;
  nombre: string;
  apellido: string;

}
