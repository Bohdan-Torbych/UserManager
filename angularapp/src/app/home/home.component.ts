import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { User } from '../_models/user';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { UsersService } from '../_services/users.service';
import { Observable } from 'rxjs/internal/Observable';
import { filter } from 'rxjs';
import { FilterPredicate } from '../_models/filter-predicate';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  displayedColumns: string[] = ['fullName', 'email', 'gender', 'dob', 'age'];
  filterOptions = [
    {
      value: 'fullName',
      view: 'Full Name',
    },
    {
      value: 'email',
      view: 'Email',
    },
    {
      value: 'gender',
      view: 'Gender',
    },
    {
      value: 'age',
      view: 'Age',
    },
  ];
  filterPredicates: FilterPredicate = {
    fullName: (data: User, filter: string) =>
      data.fullName.toLocaleLowerCase().includes(filter.toLocaleLowerCase()),
    email: (data: User, filter: string) =>
      data.email.toLocaleLowerCase().includes(filter.toLocaleLowerCase()),
    gender: (data: User, filter: string) =>
      data.gender.toLocaleLowerCase().includes(filter.toLocaleLowerCase()),
    age: (data: User, filter: string) =>
      data.age
        .toString()
        .toLocaleLowerCase()
        .includes(filter.toLocaleLowerCase()),
  };
  filterBy: string = '';
  filterString: string = '';
  users: Observable<User[]>;
  dataSource!: MatTableDataSource<User>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private router: Router, private usersService: UsersService) {}

  ngOnInit(): void {
    this.users = this.usersService.getUsers();
    this.users.subscribe((data) => {
      this.dataSource = new MatTableDataSource<User>(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  addUser() {
    this.router.navigateByUrl('/add-user');
  }

  applyFilter() {
    if (this.filterBy === '') return;
    console.log(this.filterBy);
    this.dataSource.filterPredicate = this.filterPredicates[this.filterBy];

    this.dataSource.filter = this.filterString;
  }

  clearFilter() {
    this.dataSource.filter = '';
    this.filterBy = '';
  }
}
