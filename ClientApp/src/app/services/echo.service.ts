import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class EchoService {

  constructor(private http: HttpClient) { }

  public send(text: string) {
    return this.http.post('/api/Echo/Send', text, {
      responseType: 'text'
    });
  }
}
