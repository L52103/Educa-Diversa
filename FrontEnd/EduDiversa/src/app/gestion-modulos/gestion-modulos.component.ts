import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ModuloService } from '../services/modulo.service';
import { CategoriaService } from '../services/categoria.service';
import { Modulo } from '../models/modulo.model';
import { Categoria } from '../models/categoria.model';

@Component({
  selector: 'app-gestion-modulos',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './gestion-modulos.component.html',
  styleUrls: ['./gestion-modulos.component.css']
})
export class GestionModulosComponent implements OnInit {
  modulos: any[] = [];
  categorias: Categoria[] = [];
  moduloEnEdicion: Partial<Modulo> = { vigencia: true };
  modoEdicion = false;

  constructor(
    private moduloService: ModuloService,
    private categoriaService: CategoriaService
  ) {}

  ngOnInit(): void {
    this.cargarModulos();
    this.cargarCategorias();
  }

  cargarModulos(): void {
    this.moduloService.getModulos().subscribe(data => this.modulos = data);
  }

  cargarCategorias(): void {
    this.categoriaService.getCategorias().subscribe(data => this.categorias = data);
  }

  iniciarEdicion(modulo: Modulo): void {
    this.moduloEnEdicion = { ...modulo };
    this.modoEdicion = true;
  }

  guardarModulo(): void {
    if (this.modoEdicion) {
      this.moduloService.updateModulo(this.moduloEnEdicion.codigo!, this.moduloEnEdicion).subscribe(() => {
        this.finalizarEdicion();
      });
    } else {
      this.moduloService.createModulo(this.moduloEnEdicion).subscribe(() => {
        this.finalizarEdicion();
      });
    }
  }

  eliminarModulo(id: number): void {
    if (confirm('¿Estás seguro de eliminar este módulo?')) {
      this.moduloService.deleteModulo(id).subscribe(() => this.cargarModulos());
    }
  }

  finalizarEdicion(): void {
    this.moduloEnEdicion = { vigencia: true };
    this.modoEdicion = false;
    this.cargarModulos();
  }
}