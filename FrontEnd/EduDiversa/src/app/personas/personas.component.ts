import { Component, OnInit } from '@angular/core';
import { PersonasService } from '../core/personas.service';
import { Persona } from '../models/persona.model';


@Component({
  selector: 'app-personas',
  templateUrl: './personas.component.html',
  
})
export class PersonasComponent implements OnInit {
  personas: Persona[] = [];

  constructor(private personasService: PersonasService) {}

  ngOnInit(): void {
    this.personasService.getPersonas().subscribe(data => this.personas = data);
  }
}