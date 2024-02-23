import { Component, OnInit, TemplateRef } from '@angular/core';
import { ChapterService } from 'src/app/shared/_services/chapter/chapter.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IChapter } from 'src/app/shared/_models/chapter/IChapter';
import { ActivatedRoute } from '@angular/router';
import { ISubject } from 'src/app/shared/_models/subject/ISubject';
import { NgxSpinnerService } from 'ngx-spinner';
import { ISaveChapter } from 'src/app/shared/_models/chapter/ISaveChapter';

@Component({
  selector: 'app-chapters',
  templateUrl: './chapters.component.html',
  styleUrls: ['./chapters.component.css']
})
export class ChaptersComponent implements OnInit {
  modalTitle: string;
  chapterIdForUpdate: any;
  errorMessage: string;
  successMsg: string;
  chapterDropdownSettings = {};
  createChapterForm: FormGroup;
  chapterList: IChapter[] = [];
  subjectList: any[] = [];
  subjects: ISubject[] = [];
  selectedItem: any[];
  saveChapter: ISaveChapter = {
    ChapterName: null,
    ChapterCode: null,
    ChapterDetails: null,
    IsDeleted: false,
    SubjectId: null
  };
  deletingChapterId: number = null;

  constructor(private _chapterService: ChapterService, private _modal: NgbModal, private _fb: FormBuilder,
    private _router: ActivatedRoute, private _spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.chapterList = this._router.snapshot.data.chapterList;
    this.subjects = this._router.snapshot.data.subjectList;

    this.createChapterForm = this._fb.group({
      chapterName: ['', Validators.required],
      subjectName: ['', Validators.required],
      chapterDetails: ['', Validators.required]
    });

    this.subjects.forEach(element => {
      this.subjectList.push(element.SubjectName);
    });

    this.chapterDropdownSettings = {
      singleSelection: true,
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
  }

  get chapterForm() {
    return this.createChapterForm.controls;
  }

  createOrUpdateChapter() {
    this._spinner.show();
    this.closeErrorMessage();
    console.log(this.createChapterForm);
    if (this.createChapterForm.invalid) {
      this.errorMessage = 'Please fill up all fields';
      this._spinner.hide();
      return false;
    }

    this.saveChapter = {
      ChapterName: this.chapterForm.chapterName.value,
      ChapterCode: null,
      ChapterDetails: this.chapterForm.chapterDetails.value,
      IsDeleted: false,
      SubjectId: this.subjects.find(x => x.SubjectName === this.selectedItem[0]).Id
    };

    if (this.chapterIdForUpdate === null) {
      this._chapterService.createSubject(this.saveChapter).subscribe(data => {
        this._chapterService.getChapters().subscribe(result => {
          this.chapterList = result;
          this.successMsg = 'Chapter created successfully';
          this._modal.dismissAll();
          this.createChapterForm.reset();
          this._spinner.hide();
        }, err => {
          this.errorMessage = err.error;
          this._spinner.hide();
        });
      }, err => {
        this.errorMessage = err.error;
        this._spinner.hide();
      });
    } else {
      this._chapterService.updateSubject(this.chapterIdForUpdate, this.saveChapter).subscribe(data => {
        this._chapterService.getChapters().subscribe(result => {
          this.chapterList = result;
          this.successMsg = 'Chapter updated successfully';
          this._modal.dismissAll();
          this.createChapterForm.reset();
          this._spinner.hide();
        }, err => {
          this.errorMessage = err.error;
          this._spinner.hide();
        });
      }, err => {
        this.errorMessage = err.error;
        this._spinner.hide();
      });
    }
  }

  openChaptersCreateModal(content: any) {
    this.modalTitle = 'Create Chapters';
    this.selectedItem = [];
    this.chapterIdForUpdate = null;
    this.closeErrorMessage();
    this._modal.open(content, { size: 'lg', backdrop: 'static', keyboard: false });
  }

  editChapter(chapter: IChapter, content: any) {
    if (!chapter) {
      return false;
    }

    this.selectedItem = [];
    this.modalTitle = 'Update Chapter';
    this.chapterIdForUpdate = chapter.Id;

    this.selectedItem = [chapter.Subject.SubjectName];

    this.createChapterForm = this._fb.group({
      chapterName: [chapter.ChapterName, Validators.required],
      subjectName: [chapter.Subject.SubjectName, Validators.required],
      chapterDetails: [chapter.ChapterDetails, Validators.required]
    });

    this._modal.open(content, { size: 'lg', backdrop: 'static', keyboard: false });
  }

  deleteChapter() {
    if (!this.deletingChapterId) {
      this._modal.dismissAll();
      return false;
    }

    this._spinner.show();
    this._chapterService.deleteSubject(this.deletingChapterId).subscribe(() => {
      this._chapterService.getChapters().subscribe(result => {
        this.chapterList = result;
        this.successMsg = 'Chapter deleted successfully';
        this._modal.dismissAll();
        this._spinner.hide();
      }, err => {
        this.errorMessage = err.error;
        this._modal.dismissAll();
        this._spinner.hide();
      });
    }, err => {
      this.errorMessage = err.error;
      this._modal.dismissAll();
      console.log(err);
    });
  }

  search(term: string) {
    if (!term) {
    }
  }

  onCloseModal() {
    this.createChapterForm.reset();
    this.errorMessage = '';
    this._modal.dismissAll();
  }

  closeErrorMessage() {
    this.errorMessage = '';
  }

  closeSuccessMessage() {
    this.successMsg = '';
  }

  confirmDelete(modal: any, data: IChapter) {
    this.deletingChapterId = data.Id;
    this._modal.open(modal, { size: 'lg', backdrop: 'static', keyboard: false } );
  }

  decline() {
    this._modal.dismissAll();
    this.deletingChapterId = null;
  }
}
