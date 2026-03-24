import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule,FormsModule,HttpClientModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
       products: Product[] = [];
 loading = false;
 message = '';

 constructor(private productService: ProductService, private cartService: CartService) {}

 ngOnInit(): void {
   this.load();
 }

 load(): void {
   this.productService.getAll().subscribe({
     next: p => (this.products = p),
     error: () => (this.message = 'Failed to load products')
   });
 }

 addToCart(productId: number): void {
   this.loading = true;
   this.cartService.addToCart(productId, 1).subscribe({
     next: () => {
       this.message = 'Added to cart';
       this.loading = false;
     },
     error: () => {
       this.message = 'Failed to add to cart';
       this.loading = false;
     }
   });
 }
}
