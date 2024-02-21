import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RentCalculatorService {
  
  //@ToDo move apiurl to env
  private apiURL = 'http://localhost:5042/RentCalculator';

  constructor(private http: HttpClient ) { }

  calculateRent(request: any): Observable<any> {
    return this.http.post(this.apiURL, request);
  }
}