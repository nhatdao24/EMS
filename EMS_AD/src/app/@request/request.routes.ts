import { Routes } from '@angular/router';
import { RequestlistComponent } from './request-list/request-list.component';
import { RequestDetailsComponent } from './request-details/request-details.component';

export const requestRoutes: Routes = [
  {path: 'request-list',component: RequestlistComponent},
  {path: 'request-details',component: RequestDetailsComponent}
];
