import { Injectable } from '@angular/core';
import { Environment } from '../../_environment/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ISubject } from '../../_models/subject/ISubject';
import { ISaveSubject } from '../../_models/subject/ISavesubject';

@Injectable()
export class SubjectService {

  constructor(private _env: Environment, private _http: HttpClient) { }

  getSubjects(): Observable<ISubject[]> {
    return this._http.get<ISubject[]>(`${this._env.baseUrl}/Subjects`, { responseType: 'json' });
  }

  getSubjectById(id: number): Observable<ISubject> {
    return this._http.get<ISubject>(`${this._env.baseUrl}/Subjects/${id}`, { responseType: 'json' });
  }

  createSubject(subject: ISaveSubject): Observable<ISubject> {
    return this._http.post<ISubject>(`${this._env.baseUrl}/Subjects`, subject, { responseType: 'json' });
  }

  updateSubject(id: number, subject: ISaveSubject): Observable<ISubject> {
    return this._http.put<ISubject>(`${this._env.baseUrl}/Subjects/${id}`, subject, { responseType: 'json' });
  }

  deleteSubject(id: number) {
    return this._http.delete(`${this._env.baseUrl}/Subjects/${id}`);
  }
}
