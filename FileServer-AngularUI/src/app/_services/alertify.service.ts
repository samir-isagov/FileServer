import { Injectable } from '@angular/core';
import * as alerify from 'alertifyjs';

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() { }

  confirm(question: string, okCallBack: () => any) {
    alerify.confirm(question, (e: any) => {
      if (e) {
        okCallBack();
      }
    });
  }

  success(text: string) {
    alerify.success(text);
  }

  error(text: string) {
    alerify.error(text);
  }

  warning(text: string) {
    alerify.warning(text);
  }

  message(text: string) {
    alerify.message(text);
  }
}
