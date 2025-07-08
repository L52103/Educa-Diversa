import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CategoriaService } from '../services/categoria.service';
import { ModuloService } from '../services/modulo.service';
import { ForoService } from '../services/foro.service';
import { MultimediaService } from '../services/multimedia.service';
import { Categoria } from '../models/categoria.model';
import { Multimedia } from '../models/multimedia.model';

@Component({
  selector: 'app-docente-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './docente-dashboard.component.html',
  styleUrls: ['./docente-dashboard.component.css']
})
export class DocenteDashboardComponent implements OnInit {

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

  // Propiedades Multimedia
  contenidoMultimedia: Multimedia[] = [];
  showMultimediaForm = false;
  multimediaEnEdicion: Partial<Multimedia> | null = null;

  constructor(
    private authService: AuthService,
    private router: Router,
    private moduloService: ModuloService,
    private categoriaService: CategoriaService,
    private foroService: ForoService,
    private multimediaService: MultimediaService
  ) { }

  ngOnInit(): void {
    this.cargarModulos();
    this.cargarCategorias();
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

  // Metodos para Multimedia 
  verDetalleModulo(moduloId: number): void {
    this.moduloService.getModuloById(moduloId).subscribe(data => {
      this.selectedModule = data;
      this.vistaActual = 'detalle';
      this.foroIdActual = moduloId;
      this.cargarMultimedia(moduloId);
      this.showMultimediaForm = false;
    });
  }

  cargarMultimedia(moduleId: number): void {
    this.multimediaService.getMultimediaForModule(moduleId).subscribe(data => {
      this.contenidoMultimedia = data;
    });
  }

  abrirFormulario(item?: Multimedia): void {
    if (item) {
      this.multimediaEnEdicion = { ...item };
    } else {
      this.multimediaEnEdicion = {
        nombre: '',
        descripcion: '',
        formato: 'video',
        url: '',
        vigencia: true
      };
    }
    this.showMultimediaForm = true;
  }

  guardarMultimedia(): void {
    if (!this.multimediaEnEdicion || !this.selectedModule) return;

    const codigoPersona = this.authService.getCodigoPersona();
    if (!codigoPersona) {
      alert("Error de autenticación");
      return;
    }

    const mediaData = { ...this.multimediaEnEdicion };

    if (mediaData.codigo) {
      this.multimediaService.updateMultimedia(mediaData.codigo, mediaData).subscribe(() => {
        this.cargarMultimedia(this.selectedModule.codigo);
        this.cerrarFormulario();
      });
    } else {
      mediaData.codigoModulo = this.selectedModule.codigo;
      mediaData.personaCreadora = codigoPersona;
      mediaData.fecha = new Date().toISOString();
      this.multimediaService.createMultimedia(mediaData).subscribe(() => {
        this.cargarMultimedia(this.selectedModule.codigo);
        this.cerrarFormulario();
      });
    }
  }

  eliminarMultimedia(id: number): void {
    if (confirm('¿Estás seguro de que quieres eliminar este contenido?')) {
      this.multimediaService.deleteMultimedia(id).subscribe(() => {
        if(this.selectedModule) {
            this.cargarMultimedia(this.selectedModule.codigo);
        }
      });
    }
  }

  cerrarFormulario(): void {
    this.showMultimediaForm = false;
    this.multimediaEnEdicion = null;
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}