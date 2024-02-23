import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../shared/_guards/auth.gaurd';
import { SubjectComponent } from './subject/subject.component';
import { SubjectResolver } from '../shared/_resolver/SubjectResolver/subject.resolver';
import { CategoryResolve } from '../shared/_resolver/CategoryResolver/CategoryResolve';
import { InstitutesComponent } from './institutes/institutes.component';
import { InstitutesRelove } from '../shared/_resolver/InstituteResolver/institute.resolve';
import { CategoriesComponent } from './categories/categories.component';
import { ChaptersComponent } from './chapters/chapters.component';
import { ChapterResolver } from '../shared/_resolver/ChapterResolver/chapter.resolver';
import { UserInstituteJoinRequestComponent } from './userInstituteJoinrequest/user-institute-join-request.component';
import { UserInstituteJoinRequestResolver } from '../shared/_resolver/UserInstituteJoinRequestResolver/userInstituteJoinRequest.resolver';

const routes: Routes = [{
  path: '',
  canActivate: [AuthGuard],
  children: [
    {
      path: '',
      redirectTo: 'dashboard',
      pathMatch: 'full'
    },
    {
      path: 'dashboard'
    },
    {
      path: 'subjects',
      component: SubjectComponent,
      resolve: {
        subjectList: SubjectResolver,
        categoryList: CategoryResolve
      }
    },
    {
      path: 'institutes',
      component: InstitutesComponent,
      resolve: {
        instituteList: InstitutesRelove
      }
    },
    {
      path: 'categories',
      component: CategoriesComponent,
      resolve: {
        categoryList: CategoryResolve
      }
    },
    {
      path: 'chapters',
      component: ChaptersComponent,
      resolve: {
        chapterList: ChapterResolver,
        subjectList: SubjectResolver
      }
    },
    {
      path: 'user-join-requests',
      component: UserInstituteJoinRequestComponent,
      resolve: {
        requests: UserInstituteJoinRequestResolver
      }
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
