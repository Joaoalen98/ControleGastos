import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <app-header />
    <router-outlet></router-outlet>
  `
})
export class AppComponent {
  title = 'AngularApp';
}
