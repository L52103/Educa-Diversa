import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PersonaService } from '../services/persona.service';
import { Persona } from '../models/persona.model';

@Component({
  selector: 'app-gestion-personas',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './gestion-personas.component.html',
  styleUrls: ['./gestion-personas.component.css'] 
})
export class GestionPersonasComponent implements OnInit {
  personas: Persona[] = [];
  personaEnEdicion: Partial<Persona> = { vigencia: true };
  modoEdicion = false;

  constructor(private PersonaService: PersonaService) {}

  ngOnInit(): void {
    this.cargarPersonas();
  }

  cargarPersonas(): void {
    this.PersonaService.getPersonas().subscribe(data => this.personas = data);
  }

  iniciarEdicion(persona: Persona): void {
    
    const fechaFormateada = new Date(persona.fechaNacimiento).toISOString().split('T')[0];
    this.personaEnEdicion = { ...persona, fechaNacimiento: fechaFormateada };
    this.modoEdicion = true;
  }

  guardarPersona(): void {
    if (this.modoEdicion) {
      this.PersonaService.updatePersona(this.personaEnEdicion.codigo!, this.personaEnEdicion).subscribe(() => {
        this.finalizarEdicion();
      });
    } else {
      this.PersonaService.createPersona(this.personaEnEdicion).subscribe(() => {
        this.finalizarEdicion();
      });
    }
  }

  eliminarPersona(id: number): void {
    if (confirm('¿Estás seguro de eliminar a esta persona? Esto podría afectar a los usuarios asociados.')) {
      this.PersonaService.deletePersona(id).subscribe(() => this.cargarPersonas());
    }
  }

  finalizarEdicion(): void {
    this.personaEnEdicion = { vigencia: true };
    this.modoEdicion = false;
    this.cargarPersonas();
  }
}