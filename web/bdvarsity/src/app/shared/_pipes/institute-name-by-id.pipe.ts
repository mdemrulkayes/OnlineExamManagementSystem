import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'instituteNameById'
})
export class InstituteNameByIdPipe implements PipeTransform {
  transform(value: any, instituteList: any): any {
    if (value && instituteList) {
     return instituteList.find(x => x.item_id === value).item_text;
    } else {
      return '';
    }
  }

}
