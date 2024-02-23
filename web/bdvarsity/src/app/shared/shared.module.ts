import { NgModule } from '@angular/core';
import { AuthenticationService } from './_services/authentication/authentication.service';
import { AuthGuard } from './_guards/auth.gaurd';
import { Environment } from './_environment/environment';
import { InstituteService } from './_services/institute/institute.service';
import { InstitutesRelove } from './_resolver/InstituteResolver/institute.resolve';
import { CategoryService } from './_services/category/category.service';
import { CategoryResolve } from './_resolver/CategoryResolver/CategoryResolve';
import { SubjectService } from './_services/subject/subject.service';
import { SubjectResolver } from './_resolver/SubjectResolver/subject.resolver';
import { ChapterService } from './_services/chapter/chapter.service';
import { ChapterResolver } from './_resolver/ChapterResolver/chapter.resolver';
import { UserInstituteJoinRequestResolver } from './_resolver/UserInstituteJoinRequestResolver/userInstituteJoinRequest.resolver';
import { UserInstituteJoinRequestService } from './_services/userInstituteJoinRequest/user-institute-join-request.service';
import { QuestionTypeService } from './_services/questionType/question-type.service';
import { QuestionTypeResolver } from './_resolver/QuestionTypeResolver/QuestionType.resolver';


@NgModule({
  providers: [
    AuthenticationService,
    AuthGuard,
    Environment,
    InstituteService,
    InstitutesRelove,
    CategoryService,
    CategoryResolve,
    SubjectService,
    SubjectResolver,
    ChapterService,
    ChapterResolver,
    UserInstituteJoinRequestResolver,
    UserInstituteJoinRequestService,
    QuestionTypeService,
    QuestionTypeResolver
  ]
})
export class SharedModule {
  static forRoot() {
    return {
      ngModule: SharedModule,
      providers: [
        AuthenticationService,
        AuthGuard,
        Environment,
        InstituteService,
        InstitutesRelove,
        CategoryService,
        CategoryResolve,
        SubjectService,
        SubjectResolver,
        ChapterService,
        ChapterResolver,
        UserInstituteJoinRequestResolver,
        UserInstituteJoinRequestService,
        QuestionTypeService,
        QuestionTypeResolver
      ]
    };
  }
}
