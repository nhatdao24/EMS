import { Routes } from '@angular/router';
import { MainLayoutComponent } from './layouts/main-layout/main-layout.component';
import { BlankLayoutComponent } from './layouts/blank-layout/blank-layout.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { NotFoundComponent } from './layouts/not-found/not-found.component';
import { systemManagerRoutes } from './@system-manager/system-manager.routes';
import { masterDataRoutes } from './@master-data/master-data.routes';
import { UnauthGuard } from './service/config/unauth.guard';
import { AuthGuard } from './service/config/auth.guard';
import { requestRoutes } from './@request/request.routes';

export const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      {
        path: 'system-manager',
        children: systemManagerRoutes,
      },
      {
        path: 'master-data',
        children: masterDataRoutes,
      },
      {
        path: 'request',
        children: requestRoutes,
      },
    ],
  },
  {
    path: '',
    component: BlankLayoutComponent,
    children: [
      { path: 'login', component: LoginComponent, canActivate: [UnauthGuard] },
    ],
  },
  { path: '**', component: NotFoundComponent },
];