import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { User } from '../_models/user';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { UsersService } from '../_services/users.service';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements AfterViewInit {
  displayedColumns: string[] = ['fullName', 'email', 'gender', 'dob', "age"];
  // filterBy: string = "";
  // searchString: string = "";
  users: Observable<User[]> | undefined;
  dataSource!: MatTableDataSource<User>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private router: Router, private usersService: UsersService) {}

  ngAfterViewInit(): void {
    this.users = this.usersService.getUsers();
    this.users.subscribe((data) => {
      this.dataSource = new MatTableDataSource<User>(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      this.sort.active = 'fullName';
      this.sort.direction = 'asc';
    });
    
  }

  addUser() {
    this.router.navigateByUrl('/add-user');
  }
}
