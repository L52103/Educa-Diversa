import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: 'personas', loadChildren: () => import('./personas/personas.module').then(m => m.PersonasModule) },
  { path: '', redirectTo: 'personas', pathMatch: 'full' }
];
