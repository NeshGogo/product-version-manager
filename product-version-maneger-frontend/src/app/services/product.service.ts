import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../models/product';
import { Pagination } from '../models/pagination';
import { ApplyVersion } from '../models/apply-version';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private readonly URL = `${environment.API}/products`;

  constructor(private http: HttpClient) {}

  get(pagination?: Pagination): Observable<HttpResponse<Product[]>> {
    return this.http.get<Product[]>(`${this.URL}?page=${pagination?.page}`, {
      observe: 'response',
    });
  }

  geById(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.URL}/${id}`);
  }

  set(product: Product): Observable<Product> {
    return this.http.post<Product>(this.URL, product);
  }

  update(id: number, product: Partial<Product>): Observable<Product> {
    return this.http.put<Product>(`${this.URL}/${id}`, product);
  }

  filter(
    value: string,
    pagination?: Pagination
  ): Observable<HttpResponse<Product[]>> {
    return this.http.get<Product[]>(
      `${this.URL}/filter/${value}?page=${pagination?.page}`,
      { observe: 'response' }
    );
  }

  applyVersion(applyVersion: ApplyVersion) {
    return this.http.post<Product>(`${this.URL}/applyVersion`, applyVersion);
  }

  delete(id: number) {
    return this.http.delete(`${this.URL}/${id}`, { observe: 'response' });
  }
}
