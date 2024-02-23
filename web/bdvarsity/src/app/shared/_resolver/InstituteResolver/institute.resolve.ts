import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { IInstitutes } from '../../_models/institutes/IInstitutes';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InstituteService } from '../../_services/institute/institute.service';

@Injectable()
export class InstitutesRelove implements Resolve<IInstitutes[]> {

    constructor(private _instituteService: InstituteService) {
    }
    resolve(route: ActivatedRouteSnapshot): Observable<IInstitutes[]> {
        return this._instituteService.getInstitutes();
    }
}
