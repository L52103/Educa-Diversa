import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UsuarioService } from '../services/usuario.service';
import { Usuario, TipoUsuarioEnum } from '../models/usuario.model'; 
import { Persona } from '../models/persona.model';
import { PersonaService } from '../services/persona.service'; 

@Component({
  selector: 'app-gestion-usuarios',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './gestion-usuarios.component.html',
  styleUrls: ['./gestion-usuarios.component.css'] 
})
export class GestionUsuariosComponent implements OnInit {
  usuarios: Usuario[] = [];
  personas: Persona[] = [];
  usuarioEnEdicion: Partial<Usuario> = {};
  modoEdicion = false;
  tiposUsuario = Object.keys(TipoUsuarioEnum).filter(k => isNaN(Number(k))); // dropdown

  constructor(private UsuarioService: UsuarioService, private personaService: PersonaService) {}

  ngOnInit(): void {
    this.cargarUsuarios();
    this.cargarPersonas();
  }

  cargarUsuarios(): void {
    this.UsuarioService.getUsuarios().subscribe(data => this.usuarios = data);
  }

  cargarPersonas(): void { 
    this.personaService.getPersonas().subscribe(data => {
      this.personas = data.filter(p => p.vigencia); 
    });
  }

  iniciarEdicion(usuario: Usuario): void {
    this.usuarioEnEdicion = { ...usuario };
    this.modoEdicion = true;
  }

  guardarUsuario(): void {

  if (this.modoEdicion) {

    // El ! asegura que usuarioId no sera nulo
    this.UsuarioService.updateUsuario(this.usuarioEnEdicion.usuarioId!, this.usuarioEnEdicion).subscribe({
      next: () => this.finalizarEdicion(),
      error: (err) => console.error('Error al actualizar usuario:', err)
    });
  } else {

    this.UsuarioService.createUsuario(this.usuarioEnEdicion).subscribe({
      next: () => this.finalizarEdicion(),
      error: (err) => console.error('Error al crear usuario:', err)
    });
  }
}

  eliminarUsuario(id: string): void {
    if (confirm('¿Estás seguro de eliminar este usuario?')) {
      this.UsuarioService.deleteUsuario(id).subscribe(() => this.cargarUsuarios());
    }
  }

  finalizarEdicion(): void {
    this.usuarioEnEdicion = {};
    this.modoEdicion = false;
    this.cargarUsuarios();
  }
}