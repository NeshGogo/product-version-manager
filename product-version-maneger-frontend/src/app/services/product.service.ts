import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private readonly URL = `${environment.API}/products`;

  constructor(private http: HttpClient) {}

  get(): Observable<Product[]> {
    return this.http.get<Product[]>(this.URL);
  }

  set(product: Product): Observable<Product> {
    return this.http.post<Product>(this.URL, product);
  }
}
