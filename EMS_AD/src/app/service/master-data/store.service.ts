import { Injectable } from '@angular/core'
import { CommonService } from '../common.service'
import { Observable } from 'rxjs'

@Injectable({
  providedIn: 'root',
})
export class StoreService {
  constructor(private commonService: CommonService) { }

  search(params: any): Observable<any> {
    return this.commonService.get('Store/Search', params)
  }
  update(data: any): Observable<any> {
    return this.commonService.put('Store/Update', data)
  }
  create(data: any): Observable<any> {
    return this.commonService.post('Store/Insert', data)
  }
  delete(id: string|number): Observable<any> {
    return this.commonService.delete(`Store/Delete/${id}`)
  }

}