import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CategoriasComponent } from './components/categorias/categorias.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { DocenteDashboardComponent } from './docente-dashboard/docente-dashboard.component'; 
import { FamiliaDashboardComponent } from './familia-dashboard/familia-dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    CategoriasComponent, 
    AdminDashboardComponent,
    DocenteDashboardComponent, 
    FamiliaDashboardComponent 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }