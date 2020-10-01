import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Contact } from '../_models/Contact';

@Injectable({
  providedIn: 'root'
})

export class ContactService {
  baseUrl = environment.apiUrl;

  constructor(private http:HttpClient) { }

  getContacts() : Observable<Contact[]> {
    return this.http.get<Contact[]>(this.baseUrl + 'contact');
  }

  getContact(id: number) : Observable<Contact> {
    return this.http.get<Contact>(this.baseUrl + '/contact' + id);
  }

  addContact(data: Contact) {
    return this.http.post(this.baseUrl + '/contact', data);
  }

  updateContact(data: Contact) {
    return this.http.put(this.baseUrl + '/contact', data);
  }
}
