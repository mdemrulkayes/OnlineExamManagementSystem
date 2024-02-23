import { IInstitutes } from '../institutes/IInstitutes';

export interface IUser {
            FirstName: string;
            LastName: string;
            Address: string;
            Gender: string;
            ProfilePictureUrl: string;
            CreatedAt: Date;
            UpdatedAt: Date;
            Institutes: IInstitutes[];
            Id: string;
            UserName: string;
            Email: string;
            EmailConfirmed: boolean;
            PhoneNumber: string;
            PhoneNumberConfirmed: boolean;
}
