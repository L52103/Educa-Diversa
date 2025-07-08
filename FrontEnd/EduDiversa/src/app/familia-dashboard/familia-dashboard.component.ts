import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router, RouterModule } from '@angular/router';
import { ModuloService } from '../services/modulo.service';
import { CategoriaService } from '../services/categoria.service';
import { ForoService } from '../services/foro.service';
import { Categoria } from '../models/categoria.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MultimediaService } from '../services/multimedia.service';
import { Multimedia } from '../models/multimedia.model';

@Component({
  selector: 'app-familia-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './familia-dashboard.component.html',
  styleUrls: ['./familia-dashboard.component.css']
})
export class FamiliaDashboardComponent implements OnInit {

  vistaActual: 'lista' | 'detalle' | 'debate' = 'lista';
  modulos: any[] = [];
  modulosFiltrados: any[] = [];
  categorias: Categoria[] = [];
  publicaciones: any[] = [];
  selectedModule: any = null;
  filtroCategoria: string = '';
  terminoBusqueda: string = '';
  nuevoComentario: string = '';
  foroIdActual: number | null = null;
  contenidoMultimedia: Multimedia[] = [];

  constructor(
    private authService: AuthService,
    private router: Router,
    private moduloService: ModuloService,
    private categoriaService: CategoriaService,
    private foroService: ForoService,
    private multimediaService: MultimediaService
    
  ) { }

  ngOnInit(): void {
    this.cargarCategorias();
    this.cargarModulos();
  }

  cargarCategorias(): void {
    this.categoriaService.getCategorias().subscribe(data => {
      this.categorias = data.filter(c => c.vigencia);
    });
  }

  cargarModulos(): void {
    this.moduloService.getModulos().subscribe(data => {
      this.modulos = data;
      this.modulosFiltrados = data;
    });
  }

  filtrarYBuscar(): void {
    let tempModulos = this.modulos;
    if (this.filtroCategoria) {
      tempModulos = tempModulos.filter(m => m.codigoCategoria == this.filtroCategoria);
    }
    if (this.terminoBusqueda) {
      const busqueda = this.terminoBusqueda.toLowerCase();
      tempModulos = tempModulos.filter(m => m.descripcion.toLowerCase().includes(busqueda));
    }
    this.modulosFiltrados = tempModulos;
  }

  verDetalleModulo(moduloId: number): void {
    this.moduloService.getModuloById(moduloId).subscribe(data => {
      this.selectedModule = data;
      this.vistaActual = 'detalle';
      this.foroIdActual = moduloId;
      this.cargarMultimedia(moduloId);
    });
  }

  cargarMultimedia(moduleId: number): void {
    this.multimediaService.getMultimediaForModule(moduleId).subscribe(data => {
      this.contenidoMultimedia = data;
    });
  }

  cargarDebate(): void {
    if (!this.foroIdActual) return;
    this.foroService.getPublicacionesByForoId(this.foroIdActual).subscribe(data => {
      this.publicaciones = data;
      this.vistaActual = 'debate';
    });
  }

  enviarComentario(): void {
    const codigoPersonaLogueada = this.authService.getCodigoPersona();

    const foroId = this.foroIdActual;

    if (!this.nuevoComentario.trim() || !foroId || !codigoPersonaLogueada) {
        console.error("No se puede enviar el comentario. Falta información.");
        return;
    }

    const publicacion = {
      descripcion: this.nuevoComentario,
      codigoForo: foroId,
      codigoPersona: codigoPersonaLogueada
    };

    this.foroService.createPublicacion(publicacion).subscribe(() => {
      this.nuevoComentario = '';
      this.cargarDebate();
    });
  }

  regresar(a: 'lista' | 'detalle'): void {
    if (a === 'lista') {
      this.selectedModule = null;
      this.publicaciones = [];
    }
    this.vistaActual = a;
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}