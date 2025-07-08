import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-docente-dashboard',
  templateUrl: './docente-dashboard.component.html',
  styleUrls: ['./docente-dashboard.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class DocenteDashboardComponent {
  constructor(private authService: AuthService, private router: Router) { }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}