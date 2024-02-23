import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { IUserInstituteJoinRequest } from '../../_models/userInstituteJoinRequest/IUserInstituteJoinRequest';
import { Observable } from 'rxjs';
import { UserInstituteJoinRequestService } from '../../_services/userInstituteJoinRequest/user-institute-join-request.service';

@Injectable()
export class UserInstituteJoinRequestResolver implements Resolve<IUserInstituteJoinRequest[]> {

    constructor(private _userInstituteJoinRequestService: UserInstituteJoinRequestService) {
    }

    resolve(): Observable<IUserInstituteJoinRequest[]> {
        return this._userInstituteJoinRequestService.getUserInstituteJoinRequests();
    }
}
