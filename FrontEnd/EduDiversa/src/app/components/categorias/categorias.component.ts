import { Component, OnInit } from '@angular/core';
import { CategoriaService } from '../../services/categoria.service'; 
import { Categoria } from '../../models/categoria.model';       
import { CommonModule } from '@angular/common'; 
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html', 
  styleUrls: ['./categorias.component.css'],    
  standalone: true,
  imports: [CommonModule, FormsModule] 
})
export class CategoriasComponent implements OnInit {
  categorias: Categoria[] = [];
  nuevaCategoria: Categoria = { descripcion: '', vigencia: true }; 
  categoriaEditando: Categoria | null = null; // Objeto para edicion formulario

  //inyeccion CategoriaService.
  constructor(private categoriaService: CategoriaService) { }

 
  ngOnInit(): void {
    this.loadCategorias(); // carga las categorias al inicio
  }

  /**
  Carga todas las categorías desde la API usando CategoriaService.
  */
  loadCategorias(): void {
    this.categoriaService.getCategorias().subscribe(
      (data: Categoria[]) => {
        this.categorias = data; // Si la peticion es exitosa asigna los datos recibidos
        console.log('Categorías cargadas exitosamente:', this.categorias);
      },
      (error) => {
        console.error('Error al cargar categorías:', error); // Maneja de error
      }
    );
  }

  /**
   Añade una nueva categoria utilizando los datos del formulario 'nuevaCategoria'
   Despues de añadirla, recarga la lista y limpia el formulario.
   */
  addCategoria(): void {
    // Verifica que la descripcion no este vacia antes de añadir
    if (!this.nuevaCategoria.descripcion.trim()) {
      alert('La descripción de la categoría no puede estar vacía.');
      return;
    }

    this.categoriaService.createCategoria(this.nuevaCategoria).subscribe(
      (data: Categoria) => {
        console.log('Categoría creada:', data);
        this.loadCategorias(); // Vuelve a cargar todas las categorías
        this.nuevaCategoria = { descripcion: '', vigencia: true }; // Resetea el objeto del formulario
      },
      (error) => {
        console.error('Error al crear categoría:', error);
        alert('No se pudo crear la categoría. Revisa la consola para más detalles.');
      }
    );
  }

  /**
   se cargan los datos de la categoría seleccionada y se crea una copia para no modificar directamente el objeto original en la lista
   */
  editCategoria(categoria: Categoria): void {
    this.categoriaEditando = { ...categoria }; // Copia la categoria
  }

  /**
   Despues de actualizarla, recarga la lista y oculta el formulario de edición
   */
  updateCategoria(): void {
    // Verifica que haya una categoría en edición y que tenga un código válido
    if (this.categoriaEditando && this.categoriaEditando.codigo !== undefined && this.categoriaEditando.descripcion.trim()) {
      this.categoriaService.updateCategoria(this.categoriaEditando.codigo, this.categoriaEditando).subscribe(
        (data: Categoria) => {
          console.log('Categoría actualizada:', data);
          this.loadCategorias(); // Vuelve a cargar todas las categorías
          this.categoriaEditando = null; // Oculta el formulario de edición
        },
        (error) => {
          console.error('Error al actualizar categoría:', error);
          alert('No se pudo actualizar la categoría. Revisa la consola para más detalles.');
        }
      );
    } else {
        alert('Selecciona una categoría para editar y asegúrate que la descripción no esté vacía.');
    }
  }

  /**
    Elimina una categoría de la API con confrmacion
    
   */
  deleteCategoria(id: number): void {
    if (confirm('¿Estás seguro de que quieres eliminar esta categoría?')) {
      this.categoriaService.deleteCategoria(id).subscribe(
        () => {
          console.log('Categoría eliminada:', id);
          this.loadCategorias(); // Vuelve a cargar todas las categorias
        },
        (error) => {
          console.error('Error al eliminar categoría:', error);
          alert('No se pudo eliminar la categoría. Revisa la consola para más detalles.');
        }
      );
    }
  }
}