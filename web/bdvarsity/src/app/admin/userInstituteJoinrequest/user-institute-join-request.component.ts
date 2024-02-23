import { Component, OnInit } from '@angular/core';
import { UserInstituteJoinRequestService } from 'src/app/shared/_services/userInstituteJoinRequest/user-institute-join-request.service';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { IUserInstituteJoinRequest } from 'src/app/shared/_models/userInstituteJoinRequest/IUserInstituteJoinRequest';
import { ISaveUserInstituteJoinRequest } from 'src/app/shared/_models/userInstituteJoinRequest/ISaveUserInstituteJoinRequest';

@Component({
  selector: 'app-user-institute-join-request',
  templateUrl: './user-institute-join-request.component.html',
  styleUrls: ['./user-institute-join-request.component.css']
})
export class UserInstituteJoinRequestComponent implements OnInit {

  userJoinRequests: IUserInstituteJoinRequest[] = [];
  saveJoinRequest: ISaveUserInstituteJoinRequest = {
    InstituteId: null
  };
  successMsg: string;

  constructor(private _userJoinrequestService: UserInstituteJoinRequestService, private _route: ActivatedRoute,
     private _spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.userJoinRequests = this._route.snapshot.data.requests;
  }

  approveRequest(userInstituteJoinRequest: IUserInstituteJoinRequest) {
    this._spinner.show();
    this._userJoinrequestService.approveUserJoinRequest(userInstituteJoinRequest.Id).subscribe(() => {
      this._userJoinrequestService.getUserInstituteJoinRequests().subscribe(result => {
        this.userJoinRequests = result;
        this._spinner.hide();
        this.successMsg = 'User Join request approved successfully';
      }, err => {
        console.log(err);
        this._spinner.hide();
      });
    }, err => {
      console.log(err);
      this._spinner.hide();
    });
  }

  rejectRequest(userInstituteJoinRequest: IUserInstituteJoinRequest) {
    this._spinner.show();
    this._userJoinrequestService.rejectUserJoinRequest(userInstituteJoinRequest.Id).subscribe(() => {
      this._userJoinrequestService.getUserInstituteJoinRequests().subscribe(result => {
        this.userJoinRequests = result;
        this._spinner.hide();
        this.successMsg = 'User Join request rejected successfully';
      }, err => {
        console.log(err);
        this._spinner.hide();
      });
    }, err => {
      console.log(err);
      this._spinner.hide();
    });
  }
}
