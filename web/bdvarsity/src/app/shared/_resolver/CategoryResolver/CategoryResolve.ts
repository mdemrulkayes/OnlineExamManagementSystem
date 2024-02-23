import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { ICategories } from '../../_models/categories/ICategories';
import { Observable } from 'rxjs';
import { CategoryService } from '../../_services/category/category.service';

@Injectable()
export class CategoryResolve implements Resolve<ICategories[]> {
    constructor(private _categoryService: CategoryService) {

    }
    resolve(route: ActivatedRouteSnapshot): Observable<ICategories[]> {
        return this._categoryService.getCategories();
    }
}
