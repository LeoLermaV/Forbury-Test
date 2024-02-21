import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RentCalculatorService } from './services/rent-calculator.service';

interface RentCalculationResult {
  year: number;
  baseRent: number;
  salesRevenue: number;
  tier1Rent: number;
  tier2Rent: number;
  tier3Rent: number;
  totalPercentageRent: number;
  totalRent: number;
}


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  
  rentCalculationResult: RentCalculationResult[] = [];
  rentForm: FormGroup;

  constructor(private rentCalculatorService: RentCalculatorService) {
    this.rentForm = new FormGroup({});
  }
  ngOnInit(): void {
    this.rentForm = new FormGroup({
      'yearOneSales': new FormControl(null, [Validators.required, Validators.min(0)]),
      'baseRentFirstFiveYears': new FormControl(null, [Validators.required, Validators.min(0)]),
      'baseRentLastFiveYears': new FormControl(null, [Validators.required, Validators.min(0)]),
      'tier1Rate': new FormControl(null, [Validators.required, Validators.min(0)]),
      'tier2Rate': new FormControl(null, [Validators.required, Validators.min(0)]),
      'tier3Rate': new FormControl(null, [Validators.required, Validators.min(0)]),
      'annualSalesGrowth': new FormControl(null, [Validators.required, Validators.min(0)])
    });
  }


  onSubmit(): void {
    if (this.rentForm.valid) {
      this.rentCalculatorService.calculateRent(this.rentForm.value).subscribe(result => {
        console.log(result);
        this.rentCalculationResult = result;
      });
    }
  }

}
