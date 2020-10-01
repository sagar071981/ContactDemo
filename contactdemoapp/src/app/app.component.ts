import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit{
  title = 'Contact Manager';
  contacts: any;

  constructor(private http:HttpClient) {}
  
  ngOnInit() {
    this.getContacts();
  }

  getContacts() {
    this.http.get('http://localhost:64145/api/contact').subscribe(response=>
    {
      this.contacts = response;
    }, error=> {
      console.log(error);
    });
  }
}
