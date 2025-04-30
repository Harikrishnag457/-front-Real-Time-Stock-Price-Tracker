import { Component, OnInit } from '@angular/core';
import { Stock } from '../stock'; // Import the Stock model
import { CommonModule } from '@angular/common'; // Import CommonModule for ngIf, ngFor, etc.
import { FormsModule } from '@angular/forms';
import { SearchComponent } from '../search/search.component';// Import FormsModule for two-way data binding
@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule, SearchComponent], // Import CommonModule for ngIf, ngFor, etc.
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  stocks: Stock[] = [
    { symbol: 'AAPL', price: 234.75, change: 0.81, open: 234.00, volume: 52163798, previousClose: 233.86 },
    { symbol: 'MSFT', price: 367.78, change: -1.07, open: 373.83, volume: 21120192, previousClose: 371.76 },
    { symbol: 'NVDA', price: 136.94, change: 0.68, open: 136.50, volume: 18500000, previousClose: 136.02 },
    { symbol: 'GOOG', price: 153.36, change: -1.37, open: 156.63, volume: 19513408, previousClose: 155.49 },
    { symbol: 'AMZN', price: 196.36, change: 5.34, open: 190.51, volume: 22670658, previousClose: 186.40 },
    { symbol: 'META', price: 573.77, change: -1.53, open: 571.00, volume: 22670658, previousClose: 563.00 },
    { symbol: 'TSLA', price: 341.85, change: 0.96, open: 341.45, volume: 31783446, previousClose: 338.59 },
    { symbol: 'WMT', price: 93.24, change: -0.50, open: 93.00, volume: 10000000, previousClose: 92.78 },
    { symbol: 'MA', price: 517.33, change: 0.75, open: 515.00, volume: 5000000, previousClose: 513.50 }
  ];

  constructor() { }


  sortByPrice(): void {
    this.stocks.sort((a, b) => a.price - b.price);
  }
}

