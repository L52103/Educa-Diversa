import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CategoriasComponent } from './components/categorias/categorias.component'; 
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { DocenteDashboardComponent } from './docente-dashboard/docente-dashboard.component';
import { FamiliaDashboardComponent } from './familia-dashboard/familia-dashboard.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'categorias', component: CategoriasComponent }, 
  { path: 'admin-dashboard', component: AdminDashboardComponent },
  { path: 'docente-dashboard', component: DocenteDashboardComponent },
  { path: 'familia-dashboard', component: FamiliaDashboardComponent },
  
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: '**', redirectTo: '/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }