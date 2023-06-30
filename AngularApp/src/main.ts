/// <reference types="@angular/localize" />

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { StaticProvider } from '@angular/core';

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
