import { Pipe, PipeTransform } from '@angular/core';
import { ISubject } from '../_models/subject/ISubject';

@Pipe({
  name: 'subjectNameById'
})
export class SubjectNameByIdPipe implements PipeTransform {

  transform(value: any, subjects: ISubject[]): any {
    return subjects.find(x => x.Id === value).SubjectName;
  }
}
