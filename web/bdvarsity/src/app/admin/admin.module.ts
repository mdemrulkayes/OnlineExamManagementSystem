import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { SubjectComponent } from './subject/subject.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DataTableModule } from 'angular-6-datatable';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { PipesModule } from '../shared/pipes.module';
import { CategoriesComponent } from './categories/categories.component';
import { InstitutesComponent } from './institutes/institutes.component';
import { ChaptersComponent } from './chapters/chapters.component';
import { QuillModule } from 'ngx-quill';
import { UserInstituteJoinRequestComponent } from './userInstituteJoinrequest/user-institute-join-request.component';
import { QuestionsComponent } from './questions/questions.component';

@NgModule({
  declarations: [SubjectComponent, CategoriesComponent, InstitutesComponent, ChaptersComponent,
    UserInstituteJoinRequestComponent, QuestionsComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    DataTableModule,
    NgMultiSelectDropDownModule,
    PipesModule,
    QuillModule
  ]
})
export class AdminModule { }
