import { Component } from '@angular/core';
import { EchoService } from './services/echo.service';
import { openDb, DB, UpgradeDB } from 'idb';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  inputText = '';
  username = '';
  isLoggedIn = false;
  echoText = [];
  db: DB;

  constructor(private echo: EchoService) {
    /*let request = indexedDB.open('echo', 1);

    request.onupgradeneeded = (e) => {
      request.result.createObjectStore('messages', {
        keyPath: 'id',
        autoIncrement: true
      });
    }

    request.onsuccess = (e) => {
      this.db = request.result;

      this.db.transaction('messages', 'readwrite')
    }*/

    openDb('echo', 1, (context: UpgradeDB) => {
      context.createObjectStore('messages', {
        keyPath: 'id',
        autoIncrement: true
      });
    }).then(value => {
      this.db = value;
      return this.db.transaction('messages', 'readonly').objectStore('messages').getAll();
    }).then(messages => {
      this.echoText = messages.map(x => x.text);
    });

    this.echo.onEcho().subscribe((text: string) => {
      this.echoText.push(text);
      this.db.transaction('messages', 'readwrite').objectStore('messages').put({ text });
    });
  }

  send(e: Event) {
    e.preventDefault();
    this.echo.send(this.inputText);
  }

  sendLogin(e: Event) {
    e.preventDefault();
    this.echo.login(this.username).subscribe(() => {
      this.isLoggedIn = true;
    });
  }
}
