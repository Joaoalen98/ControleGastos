import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <app-header />
    <app-toast aria-live="polite" aria-atomic="true"></app-toast>
    <router-outlet></router-outlet>
  `
})
export class AppComponent {
  title = 'AngularApp';
}
