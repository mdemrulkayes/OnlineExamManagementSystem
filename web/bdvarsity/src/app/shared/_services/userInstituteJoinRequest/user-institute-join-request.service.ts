import { Injectable } from '@angular/core';
import { Environment } from '../../_environment/environment';
import { HttpClient } from '@angular/common/http';
import { IUserInstituteJoinRequest } from '../../_models/userInstituteJoinRequest/IUserInstituteJoinRequest';
import { Observable } from 'rxjs';
import { ISaveUserInstituteJoinRequest } from '../../_models/userInstituteJoinRequest/ISaveUserInstituteJoinRequest';

@Injectable({
  providedIn: 'root'
})
export class UserInstituteJoinRequestService {

  constructor(private _env: Environment, private _http: HttpClient) { }

  getUserInstituteJoinRequests(): Observable<IUserInstituteJoinRequest[]> {
    return this._http.get<IUserInstituteJoinRequest[]>
      (`${this._env.baseUrl}/UserJoinRequests/GetUserJoinRequests`, { responseType: 'json' });
  }

  createUserInstituteJoinRequest(saveUserInstituteJoinRequest: ISaveUserInstituteJoinRequest):
    Observable<IUserInstituteJoinRequest> {
    return this._http.post<IUserInstituteJoinRequest>
      (`${this._env.baseUrl}/UserJoinRequests/Create`, saveUserInstituteJoinRequest, { responseType: 'json' });
  }

  approveUserJoinRequest(requestId: number) {
    return this._http.put<IUserInstituteJoinRequest>
      (`${this._env.baseUrl}/UserJoinRequests/Approve/${requestId}`, { responseType: 'json' });
  }

  cancelUserJoinRequest(requestId: number) {
    return this._http.put<IUserInstituteJoinRequest>
      (`${this._env.baseUrl}/UserJoinRequests/Cancel/${requestId}`, { responseType: 'json' });
  }

  leftInstitute(requestId: number) {
    return this._http.put<IUserInstituteJoinRequest>
      (`${this._env.baseUrl}/UserJoinRequests/Left/${requestId}`, { responseType: 'json' });
  }

  rejectUserJoinRequest(requestId: number) {
    return this._http.put<IUserInstituteJoinRequest>
      (`${this._env.baseUrl}/UserJoinRequests/Reject/${requestId}`, { responseType: 'json' });
  }
}
