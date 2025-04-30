import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { CommonModule } from '@angular/common'; // Import CommonModule for ngIf, ngFor, etc.
import { FormsModule } from '@angular/forms';
import { DashboardComponent } from "./dashboard/dashboard.component"; // Import FormsModule for two-way data binding
import { HttpClientModule } from '@angular/common/http'; // Import HttpClientModule for HTTP requests
import { ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, FormsModule, DashboardComponent, HttpClientModule, ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'my-angular-app';
}
