import { Injectable } from '@angular/core'
import { CommonService } from '../common.service'
import { Observable } from 'rxjs'

@Injectable({
  providedIn: 'root',
})
export class EmployeesService {
  constructor(private commonService: CommonService) { }

  search(params: any): Observable<any> {
    return this.commonService.get('Employees/Search', params)
  }
  update(data: any): Observable<any> {
    return this.commonService.put('Employees/Update', data)
  }
  create(data: any): Observable<any> {
    return this.commonService.post('Employees/Insert', data)
  }
}
