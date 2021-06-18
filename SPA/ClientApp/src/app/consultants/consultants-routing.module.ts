import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';


const routes: Routes = [
  { path: 'consultants', redirectTo: 'consultants/list', pathMatch: 'full' },
  { path: 'consultants/list', component: ListComponent },
  { path: 'consultants/:consultantId/details', component: DetailsComponent },
  { path: 'consultants/create', component: CreateComponent },
  { path: 'consultants/:consultantId/edit', component: EditComponent }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConsultantsRoutingModule { }
