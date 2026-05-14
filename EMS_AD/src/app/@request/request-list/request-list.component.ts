import { Component, OnInit, OnDestroy } from '@angular/core';
import { ShareModule } from '../../shared/share-module';
import { FormGroup, NonNullableFormBuilder, Validators } from '@angular/forms';
import { AccountTypeFilter } from '../../models/master-data/account-type.model';
import { PaginationResult } from '../../models/base.model';
import { GlobalService } from '../../service/global.service';
import { NzMessageService } from 'ng-zorro-antd/message';
import { StoreService } from '../../service/master-data/store.service';
import { AccountService } from '../../service/system-manager/account.service';
import { AccountStoreService } from '../../service/system-manager/accountStore.service';

@Component({
  selector: 'app-requestlist',
  imports: [ShareModule],
  standalone: true,
  templateUrl: './request-list.component.html',
  styleUrl: './request-list.component.scss'
})
export class RequestlistComponent implements OnInit, OnDestroy {
  validateForm: FormGroup;
    
    isSubmit: boolean = false;
    visible: boolean = false;
    edit: boolean = false;
    
    accountVisible = false;
    
    filter = new AccountTypeFilter();
    paginationResult = new PaginationResult();
    loading: boolean = false;
    constructor(
      private _service: StoreService,
      private fb: NonNullableFormBuilder,
      private globalService: GlobalService,
      private message: NzMessageService,
    ) {
  
      this.validateForm = this.fb.group({
        code: ['', [Validators.required]],
        name: ['', [Validators.required]],
        store: ['',[Validators.required]],
        content: ['', [Validators.required]],
      });
  
      this.globalService.setBreadcrumb([
        {
          fullName: 'Danh sách cửa hàng',
          path: 'master-data/store',
        },
      ]);
  
      this.globalService.getLoading().subscribe((value) => {
        this.loading = value;
      });

      this.paginationResult.data = [
        {
          code: 'YCR001',
          name: 'Yêu cầu 1',
          store: 'của hàng A',
          createDate: '2023-01-01',
          status: 1,
          
        },
        {
          code: 'YCR002',
          name: 'Yêu cầu 2',
          store: 'của hàng B',
          createDate: '2023-01-02',
          status: 2,
        },
        {
          code: 'YCR003',
          name: 'Yêu cầu 3',
          store: 'của hàng C',
          createDate: '2023-01-03',
          status: 3,
        }
      ];


    }
  
    ngOnInit(): void {
      this.search();
    }
  
    ngOnDestroy() {
      this.globalService.setBreadcrumb([]);
    }
  
    search() {
      // this.isSubmit = false;
      // // Load danh sách Store
      // this._service.search(this.filter).subscribe({
      //   next: (data) => {
      //     this.paginationResult = data;
      //   },
      //   error: (err) => console.error(err),
      // });
  
    }
  
    onSortChange(name: string, value: any) {
      this.filter = {
        ...this.filter,
        SortColumn: name,
        IsDescending: value === 'descend',
      };
      this.search();
    }
  
    delete(id: string | number) {
      this._service.delete(id).subscribe({
        next: () => {
          this.message.success('Xóa cửa hàng thành công');
          this.search();
        },
        error: (err) => console.error(err),
      });
    }
  
    isCodeExist(code: string): boolean {
      return this.paginationResult.data?.some(
        (store: any) => store.code === code,
      );
    }
  
    submitForm(): void {
      // this.isSubmit = true;
      // if (this.validateForm.valid) {
      //   const formData = this.validateForm.getRawValue();
      //   if (this.edit) {
      //     this._service.update(formData).subscribe({
      //       next: () => {
      //         this.message.success('Cập nhật cửa hàng thành công');
      //         this.search();
      //         this.close();
      //       },
      //       error: (err) => console.error(err),
      //     });
      //   } else {
      //     if (this.isCodeExist(formData.code)) {
      //       this.message.error(`Mã cửa hàng ${formData.code} đã tồn tại!`);
      //       return;
      //     }
      //     this._service.create(formData).subscribe({
      //       next: () => {
      //         this.message.success('Thêm mới cửa hàng thành công');
      //         this.search();
      //         this.close();
      //       },
      //       error: (err) => console.error(err),
      //     });
      //   }
      // } else {
      //   Object.values(this.validateForm.controls).forEach((control) => {
      //     if (control.invalid) {
      //       control.markAsDirty();
      //       control.updateValueAndValidity({ onlySelf: true });
      //     }
      //   });
      // }
    }
  
    openCreate() {
      this.edit = false;
      this.visible = true;
      this.resetForm();
    }
  
    openEdit(data: any) {
      // this.validateForm.patchValue(data);
      // setTimeout(() => {
      //   this.edit = true;
      //   this.visible = true;
      // }, 200);
    }
  
    close() {
      this.visible = false;
      this.resetForm();
    }
  
    reset() {
      this.filter = new AccountTypeFilter();
      this.search();
    }
  
    resetForm() {
      this.validateForm.reset({ isActive: true });
      this.isSubmit = false;
    }
  
    pageSizeChange(size: number): void {
      this.filter.currentPage = 1;
      this.filter.pageSize = size;
      this.search();
    }
  
    pageIndexChange(index: number): void {
      this.filter.currentPage = index;
      this.search();
    }

}
