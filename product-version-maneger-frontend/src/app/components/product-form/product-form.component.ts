import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.scss'],
})
export class ProductFormComponent implements OnInit {
  showAlert = false;
  productId: number | undefined;
  form: FormGroup = this.formBuilder.group({
    name: [null, [Validators.required]],
    brand: [null, [Validators.required]],
    price: [0, [Validators.required]],
    seller: [null, [Validators.required]],
  });

  constructor(
    private formBuilder: FormBuilder,
    private productService: ProductService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.init();
  }

  send(event: Event) {
    event.preventDefault();
    if (!this.form.valid) return this.form.markAsTouched();
    const product: Product = this.form.value;
    if(this.productId){
      this.productService.update(this.productId, product)
      .subscribe((product) => {
        this.DisplayAleter();
      });
    }else{
      this.productService
      .set(product)
      .subscribe((product) => {
        this.DisplayAleter();
        this.form.reset();
      });
    }
  }
  private DisplayAleter() {
    this.showAlert = true;
    setTimeout(() => {
      this.showAlert = false;
    }, 1500);
  }

  public get nameField(): AbstractControl | null {
    return this.form.get('name');
  }

  private init() {
    this.route.params.subscribe((params) => {
      this.productId = params.id;
      if(!this.productId) return;
      this.productService.geById(this.productId).subscribe((product) => {
        this.form.patchValue(product);
      });
    });
  }

  public get brandField(): AbstractControl | null {
    return this.form.get('brand');
  }

  public get priceField(): AbstractControl | null {
    return this.form.get('price');
  }

  public get sellerField(): AbstractControl | null {
    return this.form.get('seller');
  }
}
