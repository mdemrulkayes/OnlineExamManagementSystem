import { ISubject } from '../subject/ISubject';

export interface IChapter {
    Id: number;
    ChapterName: string;
    ChapterCode?: string;
    IsDeleted: boolean;
    SubjectId: number;
    ChapterDetails: string;
    Subject: ISubject;
    CreatedAt: Date;
    CreatedBy: string;
}
