import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Environment } from '../../_environment/environment';
import { Observable } from 'rxjs';
import { IQuestionType } from '../../_models/questionType/IQuestionType';

@Injectable({
  providedIn: 'root'
})
export class QuestionTypeService {

  constructor(private _http: HttpClient, private _env: Environment) { }

  getQuestionTypes(): Observable<IQuestionType[]> {
    return this._http.get<IQuestionType[]>(`${this._env.baseUrl}/QuestionType`, { responseType: 'json'});
  }
}
