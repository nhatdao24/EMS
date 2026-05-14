import { Component, OnInit } from '@angular/core';
import { ShareModule } from '../../shared/share-module';


@Component({
  selector: 'app-request-details',
  imports: [ShareModule],
  templateUrl: './request-details.component.html',
  styleUrl: './request-details.component.scss'
})
export class RequestDetailsComponent implements OnInit {

  defaultStartDate = new Date(2025, 4, 20); // Tháng trong JS bắt đầu từ 0
  defaultEndDate = new Date(2025, 4, 21);

  constructor() { }

  ngOnInit(): void {
    // Logic khởi tạo dữ liệu form tại đây
  }
}
