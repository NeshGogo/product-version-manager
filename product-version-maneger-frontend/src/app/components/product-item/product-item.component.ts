import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  @Input()product: Product | undefined;
  @Input()detailMode: boolean = false;
  @Output()goToVersion = new EventEmitter<number>();
  constructor() { }

  ngOnInit(): void {
  }
  sendToVersion(id:number){
    this.goToVersion.emit(id);
  }
}
