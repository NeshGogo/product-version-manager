import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { ProductFormComponent } from './components/product-form/product-form.component';
import { ProductListComponent } from './components/product-list/product-list.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path:'',
        redirectTo: 'products',
        pathMatch: 'full'
      },
      {
        path: 'products',
        children: [
          {
            path: '',
            component: ProductListComponent
          },
          {
            path: 'create',
            component: ProductFormComponent
          },
          {
            path: 'create/:id',
            component: ProductFormComponent
          },
          {
            path: 'detail/:id',
            component: ProductDetailComponent
          },
        ]
      },
    ]
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
