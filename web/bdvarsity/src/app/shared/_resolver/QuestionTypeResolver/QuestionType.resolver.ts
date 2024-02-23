import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { IQuestionType } from '../../_models/questionType/IQuestionType';
import { Observable } from 'rxjs';
import { QuestionTypeService } from '../../_services/questionType/question-type.service';

@Injectable()
export class QuestionTypeResolver implements Resolve<IQuestionType[]> {

    constructor(private _questionTypeService: QuestionTypeService) {

    }
    resolve(): Observable<IQuestionType[]> {
        return this._questionTypeService.getQuestionTypes();
    }
}
