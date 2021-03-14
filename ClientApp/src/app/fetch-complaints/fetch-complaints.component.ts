import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-complaints',
  templateUrl: './fetch-complaints.component.html'
})
export class FetchComplaintsComponent {
  public complaints : Complaint[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Complaint[]>(baseUrl + 'complaint').subscribe(result => {
      this.complaints = result;
    }, error => console.error(error));
  }
}

interface Complaint {
  complaintId: number;
  complaintTitle: string;
  complaintMessage: string;
  isCriticalString: string;
  submittedOn: Date;
  userEmail: string;
  statusString: string;
  topicString: string;
}
