import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Pagination } from 'src/app/models/pagination';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss'],
})
export class ProductListComponent implements OnInit {
  pagination: Pagination = { page: 1 };
  readonly perRow = 3;
  filter = new FormControl('');
  products: Product[] | undefined = [];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.fetchData();
  }

  private fetchData() {
    this.productService.get(this.pagination).subscribe((response) => {
      this.buildPagination(response.headers);
      console.log(this.pagination.pages);
      this.products = response.body || [];
    });
  }

  private buildPagination(headers: HttpHeaders) {
    this.pagination.pages = [];
    const pages = Number(headers.get('page'));
    for (let index = 0; index <= pages + 1; index++) {
      this.pagination.pages.push(index + 1);
    }
  }

  nextPage() {
    const length = this.pagination.pages?.length;
    if (length && this.pagination.page < length) {
      this.pagination.page += 1;
      this.fetchData();
      console.log(this.pagination);
    }
  }

  previousPage() {
    if (this.pagination.page > 1) {
      this.pagination.page -= 1;
      this.fetchData();
      console.log(this.pagination);
    }
  }
}
