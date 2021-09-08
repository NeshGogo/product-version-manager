import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  readonly perRow = 3;
  filter = new FormControl('');
  products: Product[] | undefined = [];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.get()
      .subscribe(products => {
        this.products = products;
      });
  }

}
