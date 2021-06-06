import { BankAcountService } from './../shared/bank-acount.service';
import { BankService } from './../shared/bank.service';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-bank-account',
  templateUrl: './bank-account.component.html',
  styleUrls: ['./bank-account.component.css']
})
export class BankAccountComponent implements OnInit {

  bankAcountsForms: FormArray = this.fb.array([])
  bankList = []

  constructor(private fb: FormBuilder, private bankService: BankService, private bankAccountService: BankAcountService) {}

  ngOnInit() {
    this.bankService.getBankList().subscribe(
      res => this.bankList = res as []
    )
    //this.addBankAccountForm()

    this.bankAccountService.getBankAccountList().subscribe(
      res=> {
        if ((res as []).length == 0){
          this.addBankAccountForm()
        }
        else{
          (res as []).forEach((bankAccount: any)=>{
            this.bankAcountsForms.push(this.fb.group({
              BankAccountID: bankAccount.BankAccountID,
              AccountNumber: [bankAccount.AccountNumber,Validators.required],
              AccountHolder: [bankAccount.AccountHolder,Validators.required],
              BankID: [bankAccount.BankID,Validators.min(1)],
              IFSC: [bankAccount.IFSC,Validators.required]
            }))
          })
        }
      }
    )


  }

  addBankAccountForm(){
    this.bankAcountsForms.push(this.fb.group({
      BankAccountID: [0],
      AccountNumber: ["",Validators.required],
      AccountHolder: ["",Validators.required],
      BankID: [0,Validators.min(1)],
      IFSC: ["",Validators.required]
    }))
  }

  recordSubmit(fg: FormGroup){
    fg.value.BankID = +fg.value.BankID
    if(fg.value.BankAccountID>0)
    {
      this.bankAccountService.putBankAccount(fg.value).subscribe(
        (res:any) =>{
          fg.patchValue({BankAccountID: res.BankAccountID})
        }
      )
    }
    else
    {
      this.bankAccountService.postBankAccount(fg.value).subscribe(
        (res:any) =>{
          fg.patchValue({BankAccountID: res.BankAccountID})
        }
      )
    }
  }

  onDelete(BankAccountID, i){
    if(BankAccountID==0)
    {
      this.bankAcountsForms.removeAt(i)
    }
    else
    {
      this.bankAccountService.deleteBankAccount(BankAccountID).subscribe(
        (res:any) =>{
          this.bankAcountsForms.removeAt(i)
        }
      )
    }
  }


}
