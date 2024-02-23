import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ICategories } from 'src/app/shared/_models/categories/ICategories';
import { ISubject } from 'src/app/shared/_models/subject/ISubject';
import { ISaveSubject } from 'src/app/shared/_models/subject/ISavesubject';
import { SubjectService } from 'src/app/shared/_services/subject/subject.service';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.css']
})
export class SubjectComponent implements OnInit {

  createSubjectForm: FormGroup;
  errorMessage: string;
  successMsg: string;
  modalTitle: string;
  categories: any[] = [];
  subjects: ISubject[] = [];
  categoryList: any[] = [];
  saveSubject: ISaveSubject = {
    SubjectName: null,
    CategoryId: null,
    IsDeleted: false,
    SubjectCode: null
  };
  selectedItem: any[];
  categoriesDropdownSettings: { };
  subjectIdForUpdate = null;
  deletingSubjectId: number = null;

  constructor(private _modal: NgbModal, private _fb: FormBuilder,
    private _subjectService: SubjectService, private _roter: ActivatedRoute, private _spinner: NgxSpinnerService ) { }

  ngOnInit() {
    this.subjectIdForUpdate = null;
    const categoryData = this._roter.snapshot.data.categoryList as ICategories[];
    categoryData.forEach(element => {
      this.categories.push({ item_id: element.Id, item_text: element.CategoryName });
      this.categoryList.push(element.CategoryName);
    });
    this.subjects = this._roter.snapshot.data.subjectList;
    this.createSubjectForm = this._fb.group({
      SubjectName: ['', Validators.required],
      SubjectCode: [''],
      CategoryId: ['', Validators.required]
    });
    this.categoriesDropdownSettings = {
      singleSelection: true,
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      closeDropDownOnSelection: false,
      allowSearchFilter: true
    };
  }

  openSubjectCreateModal(content) {
    this.selectedItem = [];
    this.createSubjectForm.reset();
    this.subjectIdForUpdate = null;
    this.modalTitle = 'Create Subject';
    this._modal.open(content, {  size: 'lg', backdrop: 'static', keyboard: false });
  }

   get SubjectForm() {
    return this.createSubjectForm.controls;
  }

  createOrUpdateSubject() {
    this._spinner.show();
    if (this.createSubjectForm.invalid) {
      this.errorMessage = 'Please fill up all input fields';
      this._spinner.hide();
      return false;
    }

    const selectedCategoryDetails = this.categories.find(x => x.item_text === this.selectedItem[0]);
    if (selectedCategoryDetails == null) {
      this.errorMessage = 'Please Select Category';
      this._spinner.hide();
      return false;
    }
    this.saveSubject = {
      SubjectName: this.SubjectForm.SubjectName.value,
      SubjectCode: this.SubjectForm.SubjectCode.value,
      CategoryId: selectedCategoryDetails.item_id,
      IsDeleted: false
    };
    if (this.subjectIdForUpdate === null || this.subjectIdForUpdate === 0) {
      this._subjectService.createSubject(this.saveSubject).subscribe(date => {
        this._subjectService.getSubjects().subscribe(result => {
          this.subjects = result;
          this.successMsg = 'Subject Created Successfully';
          this._modal.dismissAll();
          this._spinner.hide();
        }, err => {
          this.errorMessage = 'Error Occured. Please try again later';
          this._spinner.hide();
        });
      }, err => {
        this.errorMessage = 'Error Occured. Please try again later';
        this._spinner.hide();
      });
    } else {
      this._subjectService.updateSubject(+this.subjectIdForUpdate, this.saveSubject).subscribe(date => {
        this._subjectService.getSubjects().subscribe(result => {
          this.subjects = result;
          this.successMsg = 'Subject Updated Successfully';
          this._modal.dismissAll();
          this._spinner.hide();
        }, err => {
          this.errorMessage = 'Error Occured. Please try again later';
          this._spinner.hide();
        });
      }, err => {
        this.errorMessage = 'Error Occured. Please try again later';
        this._spinner.hide();
      });
    }
  }

  editSubejct(subject: ISubject, content) {
    this.selectedItem = [];
    this.modalTitle = 'Update Subject';
    this.subjectIdForUpdate = subject.Id;

    const selectedCategoryDetails = this.categories.find(x => x.item_id === subject.CategoryId);
    this.selectedItem = [selectedCategoryDetails.item_text];
    this.createSubjectForm = this._fb.group({
      SubjectName: [subject.SubjectName, Validators.required],
      SubjectCode: [subject.SubjectCode],
      CategoryId: [subject.CategoryId, Validators.required]
    });
    this._modal.open(content, {  size: 'lg', backdrop: 'static', keyboard: false });
  }

  deleteSubject() {
    this._spinner.show();
    if (!this.deletingSubjectId || this.deletingSubjectId == null) {
      this.errorMessage = 'Please try to delete subject correctly';
      return false;
    }
    this._subjectService.deleteSubject(this.deletingSubjectId).subscribe(() => {
       this._subjectService.getSubjects().subscribe(result => {
         this.subjects = result;
         this.successMsg = 'Subject Deleted Successfully';
         this._modal.dismissAll();
         this._spinner.hide();
       }, err => {
        this.errorMessage = 'Error Occured. Please try again later';
        this._modal.dismissAll();
        this._spinner.hide();
       });
    }, err => {
      this.errorMessage = 'Error Occured. Please try again later';
      this._modal.dismissAll();
      this._spinner.hide();
    });
  }

  onCloseModal() {
    this.createSubjectForm.reset();
    this._modal.dismissAll();
  }

  closeErrorMessage() {
    this.errorMessage = '';
  }

  closeSuccessMessage() {
    this.successMsg = '';
  }

  confirmDelete(modal: any, data: ISubject) {
    this.deletingSubjectId = data.Id;
    this._modal.open(modal, { size: 'lg', backdrop: 'static', keyboard: false } );
  }

  decline() {
    this._modal.dismissAll();
    this.deletingSubjectId = null;
  }
}
