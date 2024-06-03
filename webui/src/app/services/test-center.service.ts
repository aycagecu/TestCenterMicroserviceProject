// src/app/services/test-center.service.ts

import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable,throwError  } from 'rxjs';
import { TestCenter } from '../models/test-center.model';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})


export class TestCenterService {
  private apiUrl = 'http://localhost:51355/api/TestCenters'; // Test Center API URL'si

  constructor(private http: HttpClient) { }

  getTestCenters(): Observable<TestCenter[]> {
    return this.http.get<TestCenter[]>(this.apiUrl);
  }
  private handleError(error: HttpErrorResponse): Observable<never> {
    console.error('API çağrısı sırasında bir hata oluştu:', error);
    return throwError('Bir hata oluştu. Lütfen tekrar deneyin.');
  }
}
