create database employeeManagementDB;

use employeeManagementDB;

create table employeeDetails
(
	empNo int primary key,
	empName varchar(20),
	empDesignation varchar(20),
	empSalary int,
	empIsPermenant bit
)

insert into employeeDetails values(101,'Sumit','Sales',5000,1)
insert into employeeDetails values(102,'Manpreet','HR',15000,1)
insert into employeeDetails values(103,'Sakshi','Sales',53000,0)
insert into employeeDetails values(104,'Harmeet','Sales',13000,1)
insert into employeeDetails values(105,'Sujoy','HR',2500,1)
insert into employeeDetails values(106,'Aman','Sales',1200,0)
insert into employeeDetails values(107,'Karan','Accounts',7800,1)


select * from employeeDetails

alter table employeeDetails add empCity varchar(20)
update employeeDetails set empCity = 'Chennai'


create table deptDetails
(
	deptNo int primary key,
	deptName varchar(20),
	deptHead varchar(20)
)

insert into deptDetails values(10,'IT','Sonam')
insert into deptDetails values(20,'Accounts','Vikram')
insert into deptDetails values(30,'Sales','Naresh')
















