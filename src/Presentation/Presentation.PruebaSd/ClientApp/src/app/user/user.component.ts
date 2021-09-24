import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'user-app',
  templateUrl:'./user.component.html'
})
export class UserComponent {
  public lstUsuarios: Usuario[];
  constructor(http: HttpClient, @Inject("BASE_URL")baseUrl:string)
  {
    //http://localhost:62498/User?page=1&take=10
    //http.get<Usuario[]>(baseUrl + "User?page=1&take=10").subscribe(result => {
    http.get<Usuario[]>("http://localhost:62498/User").subscribe(result => {
      this.lstUsuarios = result;
    }, error => console.error(error))
  }
}
interface Usuario {
  usuID: number;
  nombre: string;
  apellido: string;

}
