# EmployeeHub

EmployeeHub is a web application built using ASP.NET Core that helps manage employees, departments, and salary histories. It also includes user authentication with ASP.NET Core Identity and uses SQLite for local database storage.

---

## How to Set Up and Run the Application

### Clone the Repository

First, you need to get the project files. Open your terminal (or Git Bash) and run the following command:

### Change to root of project
``` bash 
cd EmployeeHub\EmployeeHub
```

### Install Dependencies
``` bash
dotnet restore
```

### Build the Project
``` bash
dotnet build
```

### Set Up the Database
``` bash
dotnet ef database update
```

### Run the Application
``` bash
dotnet run
```

## Application Features
- Login: The app uses ASP.NET Core Identity for user login. You can create a new account to log in.
- Employee Management: After logging in, you can add new employees, edit existing employee information, and view employee details.
- Departments and Salary History: Employees are assigned to departments, and their salary history is stored.

## Troubleshooting
If you encounter any issues, here are some tips:

Database Migration Error: If you see an error related to the database, make sure you've run dotnet ef database update to apply the migrations and create the tables.

SQLite Connection Issue: Double-check the connection string in appsettings.json. It should be correct for SQLite, for example:

``` json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Data Source=EmployeeHub.db"
}
```