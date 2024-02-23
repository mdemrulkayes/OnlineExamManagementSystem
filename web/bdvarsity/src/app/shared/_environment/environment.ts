import { Injectable } from '@angular/core';

@Injectable()
export class Environment {
    // private _baseUrl = 'http://localhost:57659/api/v1/';
    private _baseUrl = 'http://localhost:8080/api/v1/';

    get baseUrl() {
        return this._baseUrl;
    }
}
