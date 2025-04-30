# InventoryManagementAPI

An inventory management API with CRUD operations. Built with ASP.NET Core, this project helps users create and manage records of various products and categories in a store.

## 🚀 Features

- **POST** `/api/categories`: Create a category for products with a name and description  
- **POST** `/api/products`: Create a product record with name, price, quantity in stock, etc.  
- **GET** `/api/products`: Retrieve all products in the database  
- **GET** `/api/categories`: Retrieve all categories in the database  
- **GET** `/api/products/{id}`: Retrieve a specific product by ID  
- **GET** `/api/categories/{id}`: Retrieve a specific category by ID  
- **PUT** `/api/products/{id}`: Update details of a specific product by ID  
- **PUT** `/api/categories/{id}`: Update details of a specific category by ID  
- **DELETE** `/api/products/{id}`: Delete a specific product by ID  
- **DELETE** `/api/categories/{id}`: Delete a specific category by ID  

## 🛠️ Technologies Used

- **ASP.NET Core** – Web framework for building the API  
- **C#** – Programming language  
- **Entity Framework Core** – ORM for interacting with the database  
- **SQLite** – Database used for storing product and category records  
- **Swagger (Swashbuckle)** – For API documentation and testing interface  

---

## 📦 Getting Started

### Prerequisites

- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/)
- [.NET SDK 7.0 or later](https://dotnet.microsoft.com/download)
- SQLite (Local or installed instance)

### 🧑‍💻 Steps to Run Locally

1. **Clone the Repository**

   ```bash
   git clone https://github.com/ROGException/InventoryManagementAPI.git
   cd InventoryManagementAPI
   
2.**Open the Solution, Set Startup Project, Apply Migrations & Run the Application**

Open InventoryManagementAPI.sln in Visual Studio.

Set the Startup Project: In Solution Explorer, right-click the API project (e.g., InventoryManagementAPI) and select "Set as Startup Project".

Apply Migrations (If Applicable):

Open Tools > NuGet Package Manager > Package Manager Console.

Then run the following command to apply any pending migrations:
Update-Database

⚠️ This step is needed if you are using Entity Framework Core with Code-First Migrations.

Run the Application: Press F5 or click Start Debugging in Visual Studio.

The API will launch, and Swagger UI should open automatically in your browser at:
https://localhost:5001/swagger
