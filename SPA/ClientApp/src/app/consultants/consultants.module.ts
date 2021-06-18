import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConsultantsRoutingModule } from './consultants-routing.module';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';


@NgModule({
  declarations: [ListComponent, DetailsComponent, CreateComponent, EditComponent],
  imports: [
    CommonModule,
    ConsultantsRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class ConsultantsModule { }
