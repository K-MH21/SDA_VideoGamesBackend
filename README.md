#  Video Game E-commerce Backend Project


## Project Overview
This is a comprehensive solution designed to facilitate the online buying and selling of video games. In a rapidly evolving digital landscape, where gamers seek not only quality products but also seamless shopping experiences, this project aims to provide a robust backend infrastructure that supports a wide range of functionalities tailored to both consumers and administrators.

## Project Objective
The primary goal of this project is to create a scalable and efficient platform that allows users to browse, purchase, and review video games while providing administrators with the necessary tools to manage inventory, process orders, and oversee user interactions. By leveraging modern web technologies and best practices, this project aims to deliver a secure, user-friendly, and responsive experience for all stakeholders involved.


 ## Key Features

### For Customers:

#### User Registration and Authentication:
- Secure user registration and login options using email and password.

#### Product Catalog:
- A dynamic catalog of video games with detailed descriptions, category, store, console, and pricing information.

#### Review and Rating :
- Allow users to leave reviews and ratings for games they have purchased.

#### Search and Filtering:
- Enable users to search for games based on name, category, or other criteria.


### For Employees (Administrators):
 
#### User Management:
- User Registration and Login: Allow users to create accounts and log in using email and password.
- User Roles: Support different user roles (e.g., Admin, Customer) with varying permissions.
- Profile Management: Enable users to update their profile information, including order history and preferences.
  
#### Product Management:
- Video Game Listings: Manage video game data, including name, developer, publisher, release date, price, and description.
- Inventory Management: Keep track of stock levels for each game, ensuring that users can only purchase available items.
- Categories : Organize games into categories (e.g., Action, RPG, Sports) .

#### Order Management:
- Order Processing: Handle order creation, status updates, and history tracking.
- Payment Integration: Integrate with payment gateways (e.g., Stripe, PayPal) for processing payments securely.

#### Admin Dashboard:
- Product Management: Allow admins to add, update, or delete video game listings.
- User Management: Admins can manage user accounts.
- Order Management: View and manage all orders.

## Technology Stack:

- Framework: ASP.NET Core 
- Database: PostgreSQL 
- ORM: Entity Framework Core 
- Authentication: JWT (JSON Web Tokens) for secure user authentication
- Hosting: Render and supabase 
- Version Control: Git (for source code management)


## Prerequisites :
- Vscode
- .Net 8 SDK
- SQL Server


  ## Getting Started :

### Step 1: Clone the Repository
Open your terminal or command prompt and clone the repository to your local machine:
```bash
git clone https://github.com/your-username//sda-3-online-Backend_Teamwork.git
```
Replace your-username with your actual GitHub username.


 ### Step 2: Navigate to the Project Directory
Change your directory to the cloned repository:
```bash
cd sda-3-online-Backend_Teamwork
```
 ### Step 3: Set Up the Database
Create the Database:
Create a new database in your SQL Server or PostgreSQL instance. You can use SSMS or pgAdmin for this.
Note the database name, as you will need it in the next step.

Update Connection String:

Open the appsettings.json file located in the project root directory.
Update the connection string to point to your newly created database. For example:
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;"
}
```
Replace your_server, your_database, your_username, and your_password with your actual database connection details.

 ### Step 4: Apply Migrations
To set up the database schema, you'll need to apply the migrations. In the terminal, run the following command:

```bash
dotnet ef database update
```
This command will create the necessary tables in your database based on the entity definitions in the project.


 ### Step 5: Run the Application
You can now run the application. Use the following command in the terminal:

```bash
dotnet run
```
The application should start, and you will see output indicating that the server is running, typically on http://localhost:5005 or https://localhost:5125.

 ### Step 6: Testing the API
You can test the API using tools like Postman or cURL.


## Project structure
- Controllers: API controllers with request and response
- Database : DbContext and Database Configurations
- DTOs : Data Transfer Objects
- Entities : Database Entities (User, Product, Category, Order)
- Middleware : Logging, request, response and Error Handler 
- Repositories : Repository Layer for database operations
- Services : Business Logic Layer 
- Utils : Common logics in the system 
- Migrations : Entity Framework Migrations
- Program : a Application Entry Point


## Some API Endpoints :
- https://fusiontech1.onrender.com/api/v1/Categories
- https://fusiontech1.onrender.com/api/v1/Console
- https://fusiontech1.onrender.com/api/v1/Customer
- https://fusiontech1.onrender.com/api/v1/GameStudio
- https://fusiontech1.onrender.com/api/v1/Payment
- https://fusiontech1.onrender.com/api/v1/Order



## Deployment :
The application is deployed and can be accessed at :  [https://fusiontech1.onrender.com]



## Team Member :
- Lead : Mohammed Alhussain [https://github.com/K-MH21]
- Taghreed Alotaibi [https://github.com/taghreedmn]
- Razan Almohammadi [https://github.com/RazanAlmohammadi]
- Lujain Alshehri [https://github.com/Lujain41]
- Samar Almutairi [https://github.com/SamarSaad056]












