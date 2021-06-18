import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Consultant } from "./consultant";

@Injectable({
  providedIn: 'root'
})
export class ConsultantsService {

  private apiURL = "https://localhost:44336/api";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private httpClient: HttpClient) { }

  getConsultants(): Observable<Consultant[]> {
    return this.httpClient.get<Consultant[]>(this.apiURL + '/consultants')
      .pipe(
        catchError(this.errorHandler)
      );
  }

  getConsultant(id): Observable<Consultant> {
    return this.httpClient.get<Consultant>(this.apiURL + '/consultants/' + id)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  createConsultant(consultant): Observable<Consultant> {
    return this.httpClient.post<Consultant>(this.apiURL + '/consultants/', JSON.stringify(consultant), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  updateConsultant(id, consultant): Observable<Consultant> {
    return this.httpClient.put<Consultant>(this.apiURL + '/consultants/' + id, JSON.stringify(consultant), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  deleteConsultant(id) {
    return this.httpClient.delete<Consultant>(this.apiURL + '/consultants/' + id, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';

    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }}




