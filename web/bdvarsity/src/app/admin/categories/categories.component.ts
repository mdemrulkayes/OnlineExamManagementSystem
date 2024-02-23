import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InstituteService } from 'src/app/shared/_services/institute/institute.service';
import { ISaveCategory } from 'src/app/shared/_models/categories/ISaveCategory';
import { CategoryService } from 'src/app/shared/_services/category/category.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ICategories } from 'src/app/shared/_models/categories/ICategories';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {
  errorMessage: string;
  successMsg: string;
  modalTitle: string;
  createCategoryForm: FormGroup;
  instituteList: any[] = [];
  selectedItems: any[] = [];
  instituteDropdownSettings = {};
  categoryIdForUpdate: number = null;
  category: ISaveCategory = {
    CategoryName: null,
    InstituteId: null,
    IsDeleted: false
  };
  categoryList: ICategories[] = [];

  categories: ICategories[];

  constructor(private _modal: NgbModal, private _fb: FormBuilder, private _spinner: NgxSpinnerService,
    private _instituteService: InstituteService, private _categoryService: CategoryService, private _router: ActivatedRoute) { }

  ngOnInit() {
    this.successMsg = '';
    this.errorMessage = '';
    this.modalTitle = 'Create Category';
    this._instituteService.getApprovedInstitutes().subscribe(data => {
      data.forEach(element => {
        this.instituteList.push({ item_id: element.Id, item_text: element.InstituteName });
      });
      this.categoryList = this._router.snapshot.data.categoryList;
    });
    this.createCategoryForm = this._fb.group({
      categoryName: ['', Validators.required],
      selectedInstitutes: ['', Validators.required]
    });

    this.instituteDropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };

  }

  openCategoriesCreateModal(content) {
    this.selectedItems = [];
    this.createCategoryForm.reset();
    this.modalTitle = 'Create Categories';
    this.categoryIdForUpdate = null;
    this._modal.open(content, { size: 'lg', backdrop: 'static', keyboard: false });
  }

  get categoryForm() {
    return this.createCategoryForm.controls;
  }

  createOrUpdateCategories() {
    this._spinner.show();
    if (this.createCategoryForm.invalid) {
      this.errorMessage = 'Please fill up complete forms';
      this._spinner.hide();
      return false;
    }

    const instituteIds = [];

    this.categoryForm.selectedInstitutes.value.forEach(element => {
      instituteIds.push(element.item_id);
    });

    this.category = {
      CategoryName: this.categoryForm.categoryName.value,
      IsDeleted: false,
      InstituteId: instituteIds
    };
    if (this.categoryIdForUpdate == null) {
      this._categoryService.createCategory(this.category).subscribe(data => {
        this._modal.dismissAll();
        this._categoryService.getCategories().subscribe(result => {
          this.categoryList = result;
          this._spinner.hide();
          this.successMsg = 'Category Created Successfully';
        });
      }, err => {
        console.log(err);
      });
    } else {
      this._categoryService.updateCategory(this.categoryIdForUpdate, this.category).subscribe(data => {
        this._modal.dismissAll();
        this._categoryService.getCategories().subscribe(result => {
          this.categoryList = result;
          this._spinner.hide();
          this.successMsg = 'Category Updated Successfully';
        });
      }, err => {
        console.log(err);
      });
    }
  }


  editCategory(category: ICategories, categoriesModal) {
    if (!category) {
      return false;
    }
    this.selectedItems = [];
    this.modalTitle = 'Update Categories';
    this.categoryIdForUpdate = category.Id;

    category.Institutes.forEach(element => {
      const data = this.instituteList.find(x => x.item_id === element.InstituteId);
      this.selectedItems.push(data);
    });

    this.createCategoryForm = this._fb.group({
      categoryName: [category.CategoryName, Validators.required],
      selectedInstitutes: [this.selectedItems, Validators.required]
    });
    this._modal.open(categoriesModal, { size: 'lg', backdrop: 'static', keyboard: false });
  }

  deleteCategory(category: ICategories) {
    console.log(category);
  }

  onCloseModal() {
    this.createCategoryForm.reset();
    this.selectedItems = [];
    this._modal.dismissAll();
  }

  closeErrorMessage() {
    this.errorMessage = '';
  }

  closeSuccessMessage() {
    this.successMsg = '';
  }

  // onItemSelect(item: any) {
  //   // console.log(item);
  // }
  // onSelectAll(items: any) {
  //   // console.log(items);
  // }
}
