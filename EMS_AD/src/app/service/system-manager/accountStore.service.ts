import { Injectable } from '@angular/core'
import { CommonService } from '../common.service'
import { Observable } from 'rxjs'

@Injectable({
  providedIn: 'root',
})
export class AccountStoreService {
  constructor(private commonService: CommonService) { }

  search(params: any): Observable<any> {
    return this.commonService.get('AccountStore/Search', params)
  }
  update(data: any): Observable<any> {
    return this.commonService.put('AccountStore/UpdateAccount', data)
  }
  create(data: any): Observable<any> {
    return this.commonService.post('AccountStore/Create', data)
  }
  delete(id: string|number): Observable<any> {
    return this.commonService.delete(`AccountStore/Delete/${id}`)
  }
  // lấy data accountstore
  getAllAccountStores(params: any): Observable<any> {
    return this.commonService.get('AccountStore/GetAllAccount', params)
  }

}