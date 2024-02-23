import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IInstitutes } from 'src/app/shared/_models/institutes/IInstitutes';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ISaveInstituteResources } from 'src/app/shared/_models/institutes/ISaveInstituteResources';
import { InstituteService } from 'src/app/shared/_services/institute/institute.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-institutes',
  templateUrl: './institutes.component.html',
  styleUrls: ['./institutes.component.css']
})
export class InstitutesComponent implements OnInit {
  institutes: IInstitutes[] = [];
  institute: ISaveInstituteResources = {
    Description: null,
    InstituteName: null,
    Location: null
  };
  instituteIdForUpdate: number;
  createInstituteForm: FormGroup;
  errorMessage = '';
  successMsg = '';
  modalTitle = 'Create Institute';
  deletingInstituteId: number = null;

  constructor(private _modal: NgbModal, private _fb: FormBuilder, private _route: ActivatedRoute,
    private _instituteService: InstituteService, private _spinner: NgxSpinnerService) {
  }

  ngOnInit() {
    this.createInstituteForm = this._fb.group({
      InstituteName: ['', Validators.required],
      Description: ['', Validators.required],
      Location: ['', Validators.required]
    });
    this.instituteIdForUpdate = null;
    this.errorMessage = '';
    this.successMsg = '';
    this.institutes = this._route.snapshot.data.instituteList;
  }

  openInstituteCreateModal(content) {
    this.modalTitle = 'Create Institute';
    this._modal.open(content, { size: 'lg', backdrop: 'static', keyboard: false });
  }

  get submittedForm() {
    return this.createInstituteForm.controls;
  }

  createOrUpdateInstitute() {
    this._spinner.show();

    if (!this.createInstituteForm.valid) {
      this.errorMessage = 'Please fill up all fields';
      this._spinner.hide();
      return false;
    }
    this.institute = {
      InstituteName: this.submittedForm.InstituteName.value,
      Description: this.submittedForm.Description.value,
      Location: this.submittedForm.Location.value
    };
    if (this.instituteIdForUpdate === null) {
      this._instituteService.createInstitute(this.institute).subscribe(() => {
        this._instituteService.getInstitutes().subscribe(resords => {
          this.institutes = resords;
          this._modal.dismissAll();
          this._spinner.hide();
          this.createInstituteForm.reset();
          this.successMsg = 'Institute Created Successfully';
        });
      }, err => {
        this.errorMessage = err.statusText;
        this._spinner.hide();
      });
    } else {
      this._instituteService.updateInstitute(this.instituteIdForUpdate, this.institute).subscribe(() => {
        this._instituteService.getInstitutes().subscribe(resords => {
          this.institutes = resords;
          this._modal.dismissAll();
          this.instituteIdForUpdate = null;
          this._spinner.hide();
          this.createInstituteForm.reset();
          this.successMsg = 'Institute Updated Successfully';
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


  editInstitute(ins: IInstitutes, content) {
    console.log(content);
    if (ins == null) {
      return false;
    }
    this.createInstituteForm = this._fb.group({
      InstituteName: [ins.InstituteName, Validators.required],
      Description: [ins.Description, Validators.required],
      Location: [ins.Location, Validators.required]
    });
    this.instituteIdForUpdate = ins.Id;
    this.modalTitle = 'Update Institute';
    this._modal.open(content, { size: 'lg', backdrop: 'static', keyboard: false });
  }

  deleteInstitute() {
    if (!this.deletingInstituteId) {
      this._modal.dismissAll();
      return false;
    }
      this._spinner.show();
      this._instituteService.deleteInstitute(this.deletingInstituteId).subscribe(() => {
        this._instituteService.getInstitutes().subscribe(resords => {
          this.institutes = resords;
          this._modal.dismissAll();
          this._spinner.hide();
          this.successMsg = 'Institute Deleted Successfully';
        }, err => {
          console.log(err.error);
        });
      }, err => {
        console.log(err.error);
      });
  }

  onCloseModal() {
    this.createInstituteForm.reset();
    this.instituteIdForUpdate = null;
    this.institute = {
      Description: null,
      InstituteName: null,
      Location: null
    };
    this._modal.dismissAll();
    this.errorMessage = '';
  }

  closeErrorMessage() {
    this.errorMessage = '';
  }

  closeSuccessMessage() {
    this.successMsg = '';
  }

  confirmDelete(modal: any, data: IInstitutes) {
    this.deletingInstituteId = data.Id;
    this._modal.open(modal, { size: 'lg', backdrop: 'static', keyboard: false } );
  }

  decline() {
    this._modal.dismissAll();
    this.deletingInstituteId = null;
  }
}
