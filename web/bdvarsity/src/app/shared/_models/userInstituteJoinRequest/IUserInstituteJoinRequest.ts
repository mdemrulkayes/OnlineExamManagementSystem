import { IUser } from '../user/IUser';
import { IInstitutes } from '../institutes/IInstitutes';

export interface IUserInstituteJoinRequest {
        Id: number;
        UserId: string;
        InstituteId: number;
        IsRequestApproved: boolean;
        IsRequestCanceled: boolean;
        IsInstituteLeft: boolean;
        IsRequestRejected: boolean;
        JoinRequestAt: string;
        ApprovedBy: string;
        StudentUser: IUser;
        ApprovedByUser: IUser;
        Institute: IInstitutes;
}
