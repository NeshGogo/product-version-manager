import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.scss']
})
export class ProductFormComponent implements OnInit {
  successMessage = 'Registrado exitosamente!';
  showAlert = false;
  form: FormGroup = this.formBuilder.group({
    name: [null, [Validators.required]],
    brand: [null, [Validators.required]],
    price: [0, [Validators.required]],
    seller: [null, [Validators.required]],
  });

  constructor(private formBuilder: FormBuilder, private productService: ProductService) { }

  ngOnInit(): void {
  }

  send(event: Event) {
    event.preventDefault();
    if (!this.form.valid) return this.form.markAsTouched();
    const product: Product = this.form.value;
    this.DisplayAleter();
    this.productService.set(product).subscribe((product) => console.log(product));
    this.form.reset();
  }
  private DisplayAleter(){
    this.showAlert = true;
    setTimeout(() => {
      this.showAlert = false;
    }, 1500);
  }
  public get nameField(): AbstractControl | null {
    return this.form.get('name');
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
