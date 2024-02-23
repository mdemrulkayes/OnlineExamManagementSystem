import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { IChapter } from '../../_models/chapter/IChapter';
import { ChapterService } from '../../_services/chapter/chapter.service';
import { Observable } from 'rxjs';

@Injectable()
export class ChapterResolver implements Resolve<IChapter[]> {
    constructor(private _chapterService: ChapterService) {
    }

    resolve(): Observable<IChapter[]> {
        return this._chapterService.getChapters();
    }
}
