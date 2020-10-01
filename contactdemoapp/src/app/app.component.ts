import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Contact } from './_models/Contact';
import { ContactService } from './_services/contact.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit{
  title = 'Contact Manager';
  contacts: Contact[];

  constructor(private contactService:ContactService) {}
  
  ngOnInit() {
    this.getContacts();
  }

  getContacts() {
    this.contactService.getContacts().subscribe(res=>
      {
        this.contacts = res;
      }, error => {
        console.log(error);
      });
  }
}
