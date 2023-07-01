import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';

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
export class HeaderComponent implements OnInit {
  logado = false;
  
  public links: Link[] = [];
  
  linksDeslogado = [
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

  linksLogado = [
      {
        innerText: 'Dashboard',
        options: { exact: true },
        routerLink: '/dashboard'
      },
      {
        innerText: 'Receitas',
        options: { exact: true },
        routerLink: '/movimentacao/receitas'
      },
      {
        innerText: 'Despesas',
        options: { exact: true },
        routerLink: '/movimentacao/despesas'
      },
  ];

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.router.events.subscribe(() => {
      const token = localStorage.getItem('token');
      if (token != null) {
        this.logado = true;
        this.links = this.linksLogado;
      } else {
        this.logado = false;
        this.links = this.linksDeslogado;
      }
    });
  }
}
