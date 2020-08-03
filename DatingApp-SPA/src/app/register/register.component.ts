import { Component, OnInit, Input, Output } from '@angular/core';
import { EventEmitter } from 'events';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input() valuesFromHome: any;
  @Output() cancelRegister = new EventEmitter();
  registerModel: any = {};
  userExistError = "";
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.registerModel).subscribe(repsone => {
      console.log("Succesfully Saved");
      this.registerModel = {};
    }, error => {

      console.log(error);
    });

  }

  cancel() {
    this.cancelRegister.emit('', false);
    console.log("cancelled");
  }

}
