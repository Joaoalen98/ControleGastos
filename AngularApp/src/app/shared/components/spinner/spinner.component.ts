import { Component, Input } from '@angular/core';

type SpinnerType = 'border' | 'grow'; 

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.scss']
})
export class SpinnerComponent {
  @Input() class = 'primary';
  @Input() type: SpinnerType = 'border';
}
