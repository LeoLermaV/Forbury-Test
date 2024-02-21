import { TestBed } from '@angular/core/testing';

import { RentCalculatorService } from './rent-calculator.service';

describe('RentCalculatorService', () => {
  let service: RentCalculatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RentCalculatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
