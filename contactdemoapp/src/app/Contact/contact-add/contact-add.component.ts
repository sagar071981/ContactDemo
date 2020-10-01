import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../_services/contact.service';
import { Contact } from '../../_models/Contact';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from '@angular/forms';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-contact-add',
  templateUrl: './contact-add.component.html',
  styleUrls: ['./contact-add.component.css']
})
export class ContactAddComponent implements OnInit {
  contact: Contact;
  contactForm: FormGroup;

  constructor(
    private contactService: ContactService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.createContactForm();
  }

  createContactForm() {
    this.contactForm = this.fb.group(
      {
        name: ['', Validators.required],
        jobTitle: ['', Validators.required],
        company: ['', Validators.required],
        phoneNo: ['', Validators.required],
        email: ['', Validators.email],
        address: ['', Validators.required],
        lastDateConnected: ['', Validators.required]
      }
    );
  }

  saveContact() {
    if (this.contactForm.valid) {
      this.contact = Object.assign({}, this.contactForm.value);
      this.contactService.addContact(this.contact).subscribe
      (() => {
        console.log('Success');
      },
      error => {
        console.log(error);
      },
      () => {
        this.router.navigate(['']);
      }
    );
    }
  }

}
