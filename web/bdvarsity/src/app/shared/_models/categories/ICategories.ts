import { ICategoriesInInstitute } from '../categoriesInInstitute/ICategoriesInInstitute';

export interface ICategories {
        Id: number;
        CategoryName: string;
        IsDeleted: boolean;
        Institutes: ICategoriesInInstitute[];
}
