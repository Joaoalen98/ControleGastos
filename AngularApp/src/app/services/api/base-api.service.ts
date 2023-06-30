import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environments } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class BaseApiService {

  url = environments.apiConfig.url;

  constructor(protected http: HttpClient) { }
}
