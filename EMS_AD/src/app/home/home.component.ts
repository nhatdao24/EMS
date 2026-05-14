import {
  Component,
  OnInit,
  OnDestroy,
} from '@angular/core';
import { GlobalService } from '../service/global.service';
import { Router } from '@angular/router';
import { ShareModule } from '../shared/share-module';

interface DashboardCard {
  title: string;
  // Dashboard card colors update
  // New color palette

  value: number;
  color: string;
  icon: string;
  change?: string;
}


interface OrdersFilterModel {
  dateFrom: Date | null;
  dateTo: Date | null;
  statuses: string[];
  timeRange: 'today' | 'threeDays' | 'sevenDays' | 'custom' | null;
}

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
   ShareModule
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements OnInit, OnDestroy {
  currentAccountType: string = '';

  ordersFilter: OrdersFilterModel = {
    dateFrom: null,
    dateTo: null,
    statuses: [],
    timeRange: null,
  };

  constructor(
    private globalService: GlobalService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.globalService.setBreadcrumb([{ name: 'Trang chủ', path: '/home' }]);
    const userInfo = this.globalService.getUserInfo();
    this.currentAccountType = userInfo?.accountType || '';
  }
  ngOnDestroy(): void {
    
  }
}
