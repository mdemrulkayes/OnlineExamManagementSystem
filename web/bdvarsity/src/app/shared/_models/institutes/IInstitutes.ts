import { IUser } from '../user/IUser';

export interface IInstitutes {
    Id: number;
    InstituteName: string;
    Description: string;
    Location: string;
    CreatedAt: Date;
    UpdatedAt: Date;
    IsDeleted: boolean;
    UserId: string;
    User?: IUser;
}
