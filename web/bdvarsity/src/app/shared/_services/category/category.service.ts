import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Environment } from '../../_environment/environment';
import { ICategories } from '../../_models/categories/ICategories';
import { Observable } from 'rxjs';
import { ISaveCategory } from '../../_models/categories/ISaveCategory';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private _http: HttpClient, private _env: Environment) { }

  getCategories(): Observable<ICategories[]> {
    return this._http.get<ICategories[]>(`${this._env.baseUrl}/Categories`, { responseType: 'json' });
  }

  createCategory(category: ISaveCategory): Observable<ICategories> {
    return this._http.post<ICategories>(`${this._env.baseUrl}/Categories`, category, { responseType: 'json' });
  }

  updateCategory(id: number, category: ISaveCategory): Observable<ICategories> {
    return this._http.put<ICategories>(`${this._env.baseUrl}/Categories/${id}`, category, { responseType: 'json' });
  }
}
