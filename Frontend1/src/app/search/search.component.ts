// search.component.ts
import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Subscription, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap, catchError } from 'rxjs/operators';
import { StockSymbolService } from '../stock-symbol.service';
import { StockSymbol } from '../stock-symbol'; // Adjust path if necessary
import { CommonModule } from '@angular/common'; // Import CommonModule for ngIf, ngFor, etc.
import { ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-search',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule], // Import CommonModule for ngIf, ngFor, etc.
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit, OnDestroy {
  // Create a reactive form control for the search input
  searchControl = new FormControl('');
  // Array to hold the suggestions returned from the API
  suggestions: StockSymbol[] = [];
  // Subscription container for cleanup
  private subscription: Subscription = new Subscription();

  constructor(private stockSymbolService: StockSymbolService) { }

  ngOnInit(): void {
    this.subscription.add(
      this.searchControl.valueChanges.pipe(
        debounceTime(300),
        distinctUntilChanged(),
        switchMap(searchQuery => {
          if (searchQuery && searchQuery.trim().length > 1) {
            return this.stockSymbolService.getSuggestions(searchQuery).pipe(
              catchError(error => {
                console.error('Error fetching suggestions:', error);
                return of([]); // Return an empty array on error
              })
            );
          }
          return of([]);
        })
      ).subscribe(data => {
        console.log('Suggestions:', data); // Debugging log
        this.suggestions = data; // Update the suggestions array
      })
    );
  }

  selectSuggestion(suggestion: StockSymbol): void {
    console.log('Selected suggestion:', suggestion.symbol);
    this.searchControl.setValue(suggestion.symbol);
    this.suggestions = [];
  }

  ngOnDestroy(): void {
    // Clean up the subscription when the component is destroyed
    this.subscription.unsubscribe();
  }
}
