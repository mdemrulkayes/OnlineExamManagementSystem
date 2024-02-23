import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InstituteNameByIdPipe } from './_pipes/institute-name-by-id.pipe';
import { CategoryNameByIdPipe } from './_pipes/category-name-by-id.pipe';
import { SubjectNameByIdPipe } from './_pipes/subject-name-by-id.pipe';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [InstituteNameByIdPipe, CategoryNameByIdPipe, SubjectNameByIdPipe],
  exports: [InstituteNameByIdPipe, CategoryNameByIdPipe]
})
export class PipesModule { }
