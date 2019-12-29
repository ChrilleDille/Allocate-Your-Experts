import { Injectable } from '@angular/core';

@Injectable()
export class MessageService {
constructor() { }

successMessages: string[] = [];
errorMessages: string[] = [];

addSuccess(message: string){
this.successMessages.push(message);
this.errorMessages = [];
}

addErrors(message: string){
  this.errorMessages.push(message)
  this.successMessages = [];
}

clear(){
  this.successMessages =  [];
  this.errorMessages = [];
}
}
