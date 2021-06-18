import { Component, OnInit } from '@angular/core';
import { Consultant } from "../consultant";
import { ConsultantsService } from "../consultants.service";

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  consultants: Consultant[] = [];

  constructor(public consultantsService: ConsultantsService) { }

  ngOnInit(): void {
    this.consultantsService.getConsultants().subscribe((data: Consultant[]) => {
      this.consultants = data;
    });
  }

  deleteConsultant(id) {
    this.consultantsService.deleteConsultant(id).subscribe(res => {
      this.consultants = this.consultants.filter(item => item.id !== id);
    });
  }
}
