import { BaseFilter } from '../base.model'

export class EmployeeFilter extends BaseFilter {
  code: string = '';
  fullName: string = '';
  position: string = '';
  phoneNumber: string = '';      
  digitalSig: string = ''; 
  email: string = '';
  address: string = '';

  isActive?: boolean | string | null;

  IsDescending: boolean = true;
}
