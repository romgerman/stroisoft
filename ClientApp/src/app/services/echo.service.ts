import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HubConnectionBuilder, HubConnection } from '@aspnet/signalr';
import { Observable } from 'rxjs';

@Injectable()
export class EchoService {

  private connection: HubConnection;

  constructor(private http: HttpClient) {
    this.connection = new HubConnectionBuilder().withUrl('/echo').build();
    this.connection.start();
  }

  public onEcho() {
    return new Observable(observer => {
      this.connection.on('echo', text => {
        observer.next(text);
      });
    });
  }

  public send(text: string) {
    this.connection.send('SendEcho', text);
  }
}
