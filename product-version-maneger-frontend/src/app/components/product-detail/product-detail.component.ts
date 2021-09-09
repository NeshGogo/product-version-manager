import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApplyVersion } from 'src/app/models/apply-version';
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
      this.fetchData();
    });
  }

  private fetchData() {
    this.productService.geById(this.productId).subscribe((product) => {
      product.productVersions = product.productVersions?.reverse();
      this.product = product;
    });
  }

  goToVersion(id:number){
    if(!id || id === 0) return;
    const applyVersion: ApplyVersion = {
      productId: this.productId,
      version:id,
    }
    this.productService
    .applyVersion(applyVersion)
    .subscribe(product => this.fetchData());

  }

}
