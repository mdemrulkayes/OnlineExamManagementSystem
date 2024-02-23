import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';

import { PortalRoutingModule } from './portal-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DataTableModule } from 'angular-6-datatable';
import { PipesModule } from '../shared/pipes.module';

@NgModule({
  declarations: [DashboardComponent],
  imports: [
    CommonModule,
    NgbModule,
    HttpClientModule,
    PortalRoutingModule,
    ReactiveFormsModule,
    DataTableModule,
    NgMultiSelectDropDownModule,
    FormsModule,
    PipesModule
  ]
})
export class PortalModule { }
