import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BankAcountService {

  constructor(private http: HttpClient) { }

  putBankAccount(formData)
  {
    return this.http.put(environment.apiBaseUri + "/BankAccount/" + formData.BankAccountID ,formData)
  }

  postBankAccount(formData)
  {
    return this.http.post(environment.apiBaseUri + "/BankAccount",formData)
  }

  getBankAccountList(){
    return this.http.get(environment.apiBaseUri + "/BankAccount")
   }

   deleteBankAccount(id)
  {
    return this.http.delete(environment.apiBaseUri + "/BankAccount/" + id)
  }
}
