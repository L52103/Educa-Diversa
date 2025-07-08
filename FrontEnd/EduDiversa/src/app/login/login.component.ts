import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { LoginRequest } from '../models/login.model';
import { TipoUsuarioEnum } from '../models/auth-response.model'; 
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class LoginComponent {
  loginRequest: LoginRequest = {
    usuarioId: '',
    password: ''
  };
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  onSubmit(): void {
    this.authService.login(this.loginRequest).subscribe({
      next: (response) => {
        console.log('Login successful', response);
        this.errorMessage = ''; // Limpia cualquier mensaje de error

        // Redirección condicional basada en el tipo de usuario
        switch (response.tipoUsuario) {
          case TipoUsuarioEnum.Admin:
            this.router.navigate(['/admin-dashboard']);
            break;
          case TipoUsuarioEnum.Docente:
            this.router.navigate(['/docente-dashboard']);
            break;
          case TipoUsuarioEnum.Familia:
            this.router.navigate(['/familia-dashboard']);
            break;
          default:
            // Fallback por si el tipo de usuario no está definido o es inesperado
            this.router.navigate(['/']); 
            break;
        }
      },
      error: (err) => {
        console.error('Login failed', err);
        if (err.status === 401) {
          this.errorMessage = 'Usuario o contraseña incorrectos.';
        } else {
          this.errorMessage = 'Ocurrió un error al intentar iniciar sesión. Por favor, inténtalo de nuevo más tarde.';
        }
      }
    });
  }
}