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

export interface Account {
  userName: string;
  fullName: string;
  password?: string;
  phoneNumber: string;
  email: string;
  address: string;
  isActive: boolean;
  storeCode: string;
}

@Component({
  selector: 'app-store',
  standalone: true,
  imports: [ShareModule],
  templateUrl: './store.component.html',
  styleUrl: './store.component.scss'
})
export class StoreComponent implements OnInit, OnDestroy {
  validateForm: FormGroup;
  accountForm!: FormGroup;
  
  isSubmit: boolean = false;
  visible: boolean = false;
  edit: boolean = false;
  
  accountVisible = false;
  accountEdit = false;
  
  filter = new AccountTypeFilter();
  paginationResult = new PaginationResult();
  loading: boolean = false;

  accountMap = new Map<string, Account[]>();

  showPassword = false;

  constructor(
    private _service: StoreService,
    private fb: NonNullableFormBuilder,
    private globalService: GlobalService,
    private message: NzMessageService,
    private accountService: AccountService,
    private accountStoreService: AccountStoreService
  ) {
    this.initAccountForm();

    this.validateForm = this.fb.group({
      code: ['', [Validators.required]],
      name: ['', [Validators.required]],
      phone: ['',[Validators.required, Validators.maxLength(10)]],
      address: ['', [Validators.required]],
      area: ['', [Validators.required]],
      isActive: [true, [Validators.required]],
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
  }

  initAccountForm() {
    this.accountForm = this.fb.group({
      storeCode: [{ value: '', disabled: true }], 
      userName: ['', Validators.required],
      fullName: ['', Validators.required],
      password: [''],
      phoneNumber: ['',[Validators.required, Validators.maxLength(10)]],
      email: [''],
      address: [''],
      isActive: [true]
    });
  }

  ngOnInit(): void {
    this.search();
  }

  ngOnDestroy() {
    this.globalService.setBreadcrumb([]);
  }

  // --- Logic Store ---

  search() {
    this.isSubmit = false;
    // Load danh sách Store
    this._service.search(this.filter).subscribe({
      next: (data) => {
        this.paginationResult = data;
      },
      error: (err) => console.error(err),
    });

    this.loadAccounts();
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
    this.isSubmit = true;
    if (this.validateForm.valid) {
      const formData = this.validateForm.getRawValue();
      if (this.edit) {
        this._service.update(formData).subscribe({
          next: () => {
            this.message.success('Cập nhật cửa hàng thành công');
            this.search();
            this.close();
          },
          error: (err) => console.error(err),
        });
      } else {
        if (this.isCodeExist(formData.code)) {
          this.message.error(`Mã cửa hàng ${formData.code} đã tồn tại!`);
          return;
        }
        this._service.create(formData).subscribe({
          next: () => {
            this.message.success('Thêm mới cửa hàng thành công');
            this.search();
            this.close();
          },
          error: (err) => console.error(err),
        });
      }
    } else {
      Object.values(this.validateForm.controls).forEach((control) => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  openCreate() {
    this.edit = false;
    this.visible = true;
    this.resetForm();
  }

  openEdit(data: any) {
    this.validateForm.patchValue(data);
    setTimeout(() => {
      this.edit = true;
      this.visible = true;
    }, 200);
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

  // --- Logic Account Store ---

  loadAccounts() {
    // Sử dụng accountStoreService để lấy mapping chính xác
    this.accountStoreService.getAllAccountStores({}).subscribe({
      next: (res: Account[]) => {
        this.accountMap.clear();
        res.forEach(acc => {
          if (!this.accountMap.has(acc.storeCode)) {
            this.accountMap.set(acc.storeCode, []);
          }
          this.accountMap.get(acc.storeCode)?.push(acc);
        });
      },
      error: (err) => console.error(err)
    });
  }

  openCreateAccount(storeCode: string) {
    this.accountEdit = false;
    this.accountVisible = true;
    this.accountForm.reset({
      storeCode: storeCode,
      isActive: true
    });
  }

  openEditAccount(acc: Account) {
    this.accountForm.patchValue({
      storeCode: acc.storeCode,
      userName: acc.userName,
      fullName: acc.fullName,
      phoneNumber: acc.phoneNumber,
      email: acc.email,
      address: acc.address,
      isActive: acc.isActive
    });

    setTimeout(() => {
      this.accountEdit = true;
      this.accountVisible = true;
    }, 200);
  }

  submitAccountForm() {
    if (this.accountForm.valid) {
      const data = this.accountForm.getRawValue();

      if (this.accountEdit) {
        if (!data.password) {
          delete data.password;
        }
        this.accountStoreService.update(data).subscribe({
          next: () => {
            this.message.success('Cập nhật tài khoản thành công');
            this.loadAccounts();
            this.closeAccount();
          },
          error: (err) => {
            this.message.error('Lỗi khi cập nhật tài khoản');
            console.error(err);
          }
        });
      } else {
        
        if (this.isAccountExist(data.userName)) {
          this.message.error(`Tên đăng nhập "${data.userName}" đã tồn tại, vui lòng chọn tên khác!`);
          return; 
        }
        this.accountStoreService.create(data).subscribe({
          next: () => {
            this.message.success('Thêm tài khoản thành công');
            this.loadAccounts();
            this.closeAccount();
          },
          error: (err) => {
            this.message.error('Lỗi khi lưu tài khoản');
            console.error(err);
          }
        });
      }
    } else {
      Object.values(this.accountForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity();
        }
      });
    }
  }

  closeAccount() {
    this.accountVisible = false;
    this.accountEdit = false;
    this.accountForm.reset();
  }

  isAccountExist(userName: string): boolean {
    for (const accounts of this.accountMap.values()) {
      if (accounts.some(acc => acc.userName.toLowerCase() === userName.toLowerCase())) {
        return true;
      }
    }
    return false;
  }
}