import { Component } from '@angular/core';
import { EchoService } from './services/echo.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  inputText = '';
  echoText = '';

  constructor(private echo: EchoService) { }

  send(e: Event) {
    e.preventDefault();
    this.echo.send(this.inputText).subscribe((text: string) => {
      this.echoText = text;
    });
  }
}
