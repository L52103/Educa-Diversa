import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonasComponent } from '../personas/personas.component';
import { RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  declarations: [PersonasComponent], 
  imports: [
    CommonModule,
    MatCardModule,
    RouterModule.forChild([
      { path: '', component: PersonasComponent }
    ])
  ]
})
export class PersonasModule { }
