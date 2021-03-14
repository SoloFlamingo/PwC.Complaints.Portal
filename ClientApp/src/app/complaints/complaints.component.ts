import { Component } from '@angular/core';

@Component({
  selector: 'app-complaints-component',
  templateUrl: './complaints.component.html'
})
export class ComplaintsComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
