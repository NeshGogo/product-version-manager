import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpResponse } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Product } from '../models/product';
import { Pagination } from '../models/pagination';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private readonly URL = `${environment.API}/products`;

  constructor(private http: HttpClient) {}

  get(pagination?:Pagination): Observable<HttpResponse<Product[]>> {
    return this.http.get<Product[]>(`${this.URL}?page=${pagination?.page}`, {observe: 'response'});
  }

  geById(id:number): Observable<Product> {
    return this.http.get<Product>(`${this.URL}/${id}`);
  }

  set(product: Product): Observable<Product> {
    return this.http.post<Product>(this.URL, product);
  }

  filter(value: string, pagination?:Pagination): Observable<HttpResponse<Product[]>>{
    return this.http.get<Product[]>(`${this.URL}/${value}?page=${pagination?.page}`, {observe: 'response'});
  }
}
