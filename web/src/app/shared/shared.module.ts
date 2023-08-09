import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    SpinnerComponent
  ],
  imports: [
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    MatTableModule
  ],
  exports: [
    ReactiveFormsModule,
    FormsModule,
    SpinnerComponent,
    MatTableModule,
    HttpClientModule
  ]
})
export class SharedModule { }
