import { ICategories } from '../categories/ICategories';

export interface ISubject {
    Id: number;
    SubjectName: string;
    SubjectCode: string;
    CreatedBy: string;
    CategoryId: number;
    CreatedDate: Date;
    UpdatedBy: string;
    UpdatedDate: Date;
    IsDeleted: boolean;
    Category: ICategories;
}
