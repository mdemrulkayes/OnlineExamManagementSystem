import { Resolve } from '@angular/router';
import { ISubject } from '../../_models/subject/ISubject';
import { SubjectService } from '../../_services/subject/subject.service';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class SubjectResolver implements Resolve<ISubject[]> {
    constructor(private _subjectServcie: SubjectService) {
    }
    resolve(): Observable<ISubject[]> {
        return this._subjectServcie.getSubjects();
    }
}
