import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { LoginInfo } from '../_models/login-info';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { HttpClient } from '@angular/common/http';
import { LoginsService } from '../_services/logins.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-logins-info',
  templateUrl: './logins-info.component.html',
  styleUrls: ['./logins-info.component.css']
})
export class LoginsInfoComponent implements AfterViewInit{
  displayedColumns: string[] = ['email', 'dateStamp', 'status'];
  users: Observable<LoginInfo[]> | undefined;
  dataSource! : MatTableDataSource<LoginInfo>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  // @ViewChild(MatSort) sort!: MatSort;

  constructor(private loginsService: LoginsService){
  }

  ngAfterViewInit(): void {
    this.users = this.loginsService.getLogins();
    this.users.subscribe((data) => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
    })
      
    // this.dataSource.sort = this.sort;
  }
}
