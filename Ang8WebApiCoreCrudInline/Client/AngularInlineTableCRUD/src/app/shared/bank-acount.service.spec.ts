import { TestBed } from '@angular/core/testing';

import { BankAcountService } from './bank-acount.service';

describe('BankAcountService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BankAcountService = TestBed.get(BankAcountService);
    expect(service).toBeTruthy();
  });
});
