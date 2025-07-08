import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service'; 
import { Router } from '@angular/router'; 
import { CommonModule } from '@angular/common'; 
import { FormsModule } from '@angular/forms';
import { DocenteDashboardComponent } from '../docente-dashboard/docente-dashboard.component';
import { GestionModulosComponent } from '../gestion-modulos/gestion-modulos.component';
import { GestionUsuariosComponent } from '../gestion-usuarios/gestion-usuarios.component';
import { GestionPersonasComponent } from '../gestion-personas/gestion-personas.component';
@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css'],
  standalone: true, 
  imports: [
    CommonModule, 
    FormsModule,
    DocenteDashboardComponent,
    GestionUsuariosComponent,
    GestionModulosComponent,
    GestionPersonasComponent
  ]
})
export class AdminDashboardComponent {
  vistaActual: string = 'menu'; 

  constructor(private authService: AuthService, private router: Router) { }

  cambiarVista(nuevaVista: string): void {
    this.vistaActual = nuevaVista;
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']); 
  }
}