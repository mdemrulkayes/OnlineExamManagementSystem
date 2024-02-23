import { Injectable } from '@angular/core';
import { Environment } from '../../_environment/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IChapter } from '../../_models/chapter/IChapter';
import { ISaveChapter } from '../../_models/chapter/ISaveChapter';

@Injectable({
  providedIn: 'root'
})
export class ChapterService {
  constructor(private _env: Environment, private _http: HttpClient) { }

  getChapters(): Observable<IChapter[]> {
    return this._http.get<IChapter[]>(`${this._env.baseUrl}/Chapters`, { responseType: 'json' });
  }

  getSubjectById(id: number): Observable<IChapter> {
    return this._http.get<IChapter>(`${this._env.baseUrl}/Chapters/${id}`, { responseType: 'json' });
  }

  createSubject(subject: ISaveChapter): Observable<IChapter> {
    return this._http.post<IChapter>(`${this._env.baseUrl}/Chapters`, subject, { responseType: 'json' });
  }

  updateSubject(id: number, subject: ISaveChapter): Observable<IChapter> {
    return this._http.put<IChapter>(`${this._env.baseUrl}/Chapters/${id}`, subject, { responseType: 'json' });
  }

  deleteSubject(id: number) {
    return this._http.delete(`${this._env.baseUrl}/Chapters/${id}`);
  }
}
