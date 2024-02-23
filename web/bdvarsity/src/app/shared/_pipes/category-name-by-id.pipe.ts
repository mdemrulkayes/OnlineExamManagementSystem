import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'categoryNameById'
})
export class CategoryNameByIdPipe implements PipeTransform {

  transform(value: any, categoryList: any): any {
    if (value && categoryList) {
      return categoryList.find(x => x.item_id === value).item_text;
    } else {
      return '';
    }
  }

}
