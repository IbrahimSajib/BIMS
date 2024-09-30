# Basic Inventory Management System

## Technologies
- Language: C#
- Framework: ASP .NET Core v8.0
- Database: MSSQL Server
- ORM: Entity Framework
- Frontend JS Library: JQuery, Ajax 
- 3 Layers architecture (Presentation, Services, Data Access Layer)
- Other : HTML, CSS, Bootstrap, Fontawesome
- Return Type : File(Excel), Json

## Features
- Registation with Email & Password
- Login with Email & Password
- Role Based Authorization
- Only SuperAdmin can manage user role.
- Admin can manage user only, Admin can't manage user Role
- SuperAdmin and Admin can manage Category, Customer, Supplier (other user can not access these part)
- Remote validation added for Unique Name
- Repository used for data access
- Service used for Business Logic
- LINQ
- Tostr used for success message notification.
- Excel Download For report
- Searching with multiple field
- When Purchase Order created Quantity Added To Product table
- In Purchase Order only Active Product can selected.
- In Sales Orders Only Active and availabe product can be selected.
- when Sales Orders created Quantity decrese from Product table.
- In Sales Order when product is selected from dropdown ajax request is called for get the available quantity of the product, User can not input more than availabe Product.

##credentials
- Role:SuperAdmin | Email: superadmin@bims.com | Password: Sa@123
- Role:Admin | Email: admin@bims.com | Password: Ad@123
- OtherUser: | Email: ibrahim@bims.com | Password : Ibr@56

