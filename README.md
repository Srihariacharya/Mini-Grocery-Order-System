# Mini Grocery Order System

## Overview
This project is a Mini Grocery Order System developed as part of a backend demo assignment.
The main objective of this project is to demonstrate backend architecture, clean separation of
responsibilities, and correct handling of order and stock logic.

The focus of the implementation is on backend logic rather than UI or design.

## Tech Stack
- ASP.NET Core Web API
- Entity Framework Core
- SQLite Database
- Swagger for API testing

## Project Structure

MiniGroceryOrderSystem/
Controllers  
Services  
Repositories  
Models  
Data  

Each layer has a clear responsibility and avoids mixing concerns.

## Architecture Explanation

### Controllers
Controllers are responsible only for handling HTTP requests and returning responses.
They do not contain any business logic.

### Services
All business logic is implemented in the Service layer.
This includes:
- Validating product existence
- Checking stock availability
- Reducing stock
- Creating orders
All order-related operations are executed inside a single database transaction.

### Repositories
Repositories handle database access only.
They do not contain business rules or transaction logic.

### Models
Models define the database schema and contain only properties.

All business logic is intentionally kept out of controllers and repositories.

## API Design

Only two APIs are implemented as required by the assignment.

### GET /products
Returns the list of available products from the database.

### POST /orders
Places an order for a product.
This API performs the following steps:
- Validates that the product exists
- Checks if sufficient stock is available
- Deducts stock
- Creates an order record
All steps are executed within a single transaction to ensure consistency.

No additional APIs were created.

## Order Processing Flow
1. Client sends a POST /orders request
2. Controller forwards the request to the service layer
3. Service starts a database transaction
4. Product is fetched and validated
5. Stock is checked and reduced
6. Order record is created
7. Transaction is committed
If any step fails, the transaction is rolled back.

## Database
SQLite is used for simplicity and ease of setup.
Products are seeded directly during database initialization.
No API is provided for managing products.

## Conclusion
This project demonstrates a clean backend architecture with proper transaction handling
and strict adherence to the given requirements.
