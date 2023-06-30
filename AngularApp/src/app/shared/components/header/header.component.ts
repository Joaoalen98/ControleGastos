import { Component } from '@angular/core';

interface Link {
  innerText: string;
  routerLink: string;
  style?: any;
  options: { exact: boolean };
}

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  public links: Link[] = [
    {
      innerText: 'Login',
      options: { exact: true },
      routerLink: '/usuario/login'
    },
    {
      innerText: 'Cadastro',
      options: { exact: true },
      routerLink: '/usuario/cadastro'
    },
  ];
}
