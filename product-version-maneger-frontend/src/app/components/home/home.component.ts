import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  toggleFlag = false;
  localesList = [
      { code: 'es', label: 'Español' },
      { code: 'en', label: 'English' },     
    ];
  constructor() { }

  ngOnInit(): void {
  }

  dropdown(){
    this.toggleFlag = !this.toggleFlag;
  }

}
