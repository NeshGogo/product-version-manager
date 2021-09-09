import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss'],
})
export class ProductDetailComponent implements OnInit {
  productId: number = 0;
  product: Product | undefined;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.init();
  }

  private init() {
    this.route.params.subscribe((params) => {
      this.productId = params.id;
      this.productService
        .geById(this.productId)
        .subscribe((product) => {this.product = product; console.log(product)});
    });
  }
}
