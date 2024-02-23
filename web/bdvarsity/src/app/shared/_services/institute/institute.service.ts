import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Environment } from '../../_environment/environment';
import { Observable } from 'rxjs';
import { IInstitutes } from '../../_models/institutes/IInstitutes';
import { ISaveInstituteResources } from '../../_models/institutes/ISaveInstituteResources';

@Injectable({
  providedIn: 'root'
})
export class InstituteService {
  constructor(private _http: HttpClient, private _env: Environment) { }

  getInstitutes(): Observable<IInstitutes[]> {
    return this._http.get<IInstitutes[]>
      (`${this._env.baseUrl}/Institutes/GetInstitutes`, { responseType: 'json' });
  }

  getApprovedInstitutes(): Observable<IInstitutes[]> {
    return this._http.get<IInstitutes[]>
      (`${this._env.baseUrl}/Institutes/GetApprovedInstitutes`, { responseType: 'json' });
  }

  getInstitute(id: number): Observable<IInstitutes> {
    return this._http.get<IInstitutes>
      (`${this._env.baseUrl}/Institutes/GetInstitute/${id}`, { responseType: 'json' });
  }

  createInstitute(instituteObj: ISaveInstituteResources): Observable<IInstitutes> {
    return this._http.post<IInstitutes>
      (`${this._env.baseUrl}/Institutes/CreateInstitute`, instituteObj, { responseType: 'json' });
  }

  updateInstitute(id: number, instituteObj: ISaveInstituteResources): Observable<IInstitutes> {
    return this._http.put<IInstitutes>
      (`${this._env.baseUrl}/Institutes/UpdateInstitute/${id}`, instituteObj, { responseType: 'json' });
  }

  rejectInstitute(id: number): Observable<IInstitutes> {
    return this._http.put<IInstitutes>
      (`${this._env.baseUrl}/Institutes/RejectInstitute/${id}`, { responseType: 'json' });
  }

  deleteInstitute(id: number) {
    return this._http.delete(`${this._env.baseUrl}/Institutes/DeleteInstitute/${id}`, { responseType: 'json' });
  }


}
