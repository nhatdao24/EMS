import { Component } from '@angular/core'
import { ShareModule } from '../../shared/share-module'
import { FormGroup, NonNullableFormBuilder, Validators } from '@angular/forms'
import { AccountTypeFilter } from '../../models/master-data/account-type.model'
import { PaginationResult } from '../../models/base.model'
import { EmployeesService} from '../../service/master-data/employees.service'
import { GlobalService } from '../../service/global.service'
import { NzMessageService } from 'ng-zorro-antd/message'

@Component({
  selector: 'app-employees',
  standalone: true,
  imports: [ShareModule],
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.scss',
})
export class EmployeesComponent {
  validateForm: FormGroup
  isSubmit: boolean = false
  visible: boolean = false
  edit: boolean = false
  filter = new AccountTypeFilter()
  
  
  paginationResult = new PaginationResult()
  loading: boolean = false
 
  constructor(
    private _service: EmployeesService,
    private fb: NonNullableFormBuilder,
    private globalService: GlobalService,
    private message: NzMessageService,
  ) {
    this.validateForm= this.fb.group({
      code: ['', [Validators.required]],
      fullName: ['', [Validators.required]],
      position: ['', [Validators.required]],
      digitalSig: ['', [Validators.required]],
      phoneNumber: ['', [Validators.pattern(/^[0-9]{10}$/)]],
      email: ['', [Validators.email, Validators.required]],
      address: ['', [Validators.required]],
      isActive: [true, [Validators.required]],
    })
    this.globalService.setBreadcrumb([
      {
        fullName: 'Danh sách nhóm nhân viên',
        path: 'master-data/employees',
      },
    ])
    this.globalService.getLoading().subscribe((value) => {
      this.loading = value
    })
  }
  ngOnDestroy() {
    this.globalService.setBreadcrumb([])
  }

  ngOnInit(): void {
    this.search()
  }

  onSortChange(name: string, value: any) {
    this.filter = {
      ...this.filter,
      SortColumn: name,
      IsDescending: value === 'descend',
    }
    this.search()
  }

  search() {
    this.isSubmit = false
    this._service.search(this.filter).subscribe({
      next: (data) => {
        this.paginationResult = data
      },
      error: (response) => {
        console.log(response)
      },
    })
  }

 
  isCodeExist(code: string): boolean {
    return this.paginationResult.data?.some(
      (employee: any) => employee.code === code,
    )
  }
  
  submitForm(): void {
    this.isSubmit = true
    if (this.validateForm.valid) {
      if (this.edit) {
        this._service
          .update(this.validateForm.getRawValue())
          .subscribe({
            next: (data) => {
              this.search()
            },
            error: (response) => {
              console.log(response)
            },
          })
      } else {
        const formData = this.validateForm.getRawValue()
        if (this.isCodeExist(formData.code)) {
          this.message.error(
            `Mã nhân viên ${formData.code} đã tồn tại, vui lòng nhập lại`,
          )
          return
        }
        this._service
          .create(this.validateForm.getRawValue())
          .subscribe({
            next: (data) => {
              this.search()
            },
            error: (response) => {
              console.log(response)
            },
          })
      }
    } else {
      Object.values(this.validateForm.controls).forEach((control) => {
        if (control.invalid) {
          control.markAsDirty()
          control.updateValueAndValidity({ onlySelf: true })
        }
      })
    }
  }

  close() {
    this.visible = false
    this.resetForm()
  }

  reset() {
    this.filter = new AccountTypeFilter()
    this.search()
  }

  openCreate() {
    this.edit = false
    this.visible = true
  }

  resetForm() {
    this.validateForm.reset()
    this.isSubmit = false
  }

  // deleteItem(id: string) {
  //   this._service.delete(id).subscribe({
  //     next: (data) => {
  //       this.search()
  //     },
  //     error: (response) => {
  //       console.log(response)
  //     },
  //   })
  // }

  openEdit(data: { code: string; fullName: string; position: string;
    phoneNumber: string; digitalSig: string; email: string; address:
    string; isActive: boolean }) {
    this.validateForm.patchValue({
      code: data.code,
      fullName: data.fullName,
      position: data.position,
      phoneNumber: data.phoneNumber,
      digitalSig: data.digitalSig,
      email: data.email,
      address: data.address,

      isActive: data.isActive,
    })
    setTimeout(() => {
      this.edit = true
      this.visible = true
    }, 200)
  }

  pageSizeChange(size: number): void {
    this.filter.currentPage = 1
    this.filter.pageSize = size
    this.search()
  }

  pageIndexChange(index: number): void {
    this.filter.currentPage = index
    this.search()
  }
}
