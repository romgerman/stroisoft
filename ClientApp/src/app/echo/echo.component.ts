import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-echo',
  templateUrl: './echo.component.html',
  styleUrls: ['./echo.component.css']
})
export class EchoComponent {
  @Input()
  text = '';
}
