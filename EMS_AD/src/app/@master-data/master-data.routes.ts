import { Routes } from '@angular/router';

import { AccountTypeComponent } from './account-type/account-type.component';
import { EmployeesComponent } from './employees/employees.component';
import { StoreComponent } from './store/store.component';

export const masterDataRoutes: Routes = [
  { path: 'account-type', component: AccountTypeComponent },
  { path: 'employees', component: EmployeesComponent },
  { path: 'store', component: StoreComponent },
];
