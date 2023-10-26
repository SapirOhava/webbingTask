# Activity Logger Service
## Overview
The Activity Logger Service provides a centralized way for applications and micro-services to log and retrieve activity logs. By leveraging the power of Entity Framework Core and SQL Server, this service ensures durable and performant logging of activities across your entire ecosystem.

## Features:
- **Unified Interface**: One endpoint to cater to all activity logging needs of your microservices.
- **Robust** : Built on ASP.NET Core and uses SQL Server as the data store for resilience and performance.
- **Configurable CORS** : Easily allow multiple front-end applications from different domains to communicate with the service.
- **Swagger Integration** : Auto-generated API documentation and testing interface.

## Setting Up
Prerequisites:


- **Visual Studio(latest recommended)**
- **SQL Server**
- **.NET 6 or higher** 

Installation:

**1. Entity Framework Core:**  Ensure you have Entity Framework Core and the necessary packages installed.

```shell
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer  
```

**2. Clone the repository:**
```shell
git clone [YourRepoLink]
```
**3. Update Database Connection:**

- Open appsettings.json or equivalent configuration file.
- Update the ActivityLoggerConnection with your SQL Server connection string.
**4. Database Migrations:** Run migrations to create/update the database schema.

```shell
dotnet ef migrations add InitialCreate
dotnet ef database update
```
**5. Run the Application:**
```shell
dotnet run
```
**Usage:**
Logging an Activity:
Send a POST request to /api/Activity:

```json
{
    "ServiceID": "OrderService",
    "EntityID": "Order123",
    "Type": "CREATE",
    "UserID": "User456",
    "Description": "Order Created"
}
```
Retrieve All Activities:

Send a GET request to /api/Activity.

Retrieve an Activity by ID:

Send a GET request to /api/Activity/{activityId}.

Update an Activity:

Send a PUT request to /api/Activity/{activityId} with the updated activity object.

Delete an Activity:

Send a DELETE request to /api/Activity/{activityId}.

**Example Scenarios:**

1. Order Microservice:

- An order is created, updated, or deleted.
- The service sends a POST request to the Activity Logger Service with relevant details.
2. Inventory Microservice:

- A stock item is updated.
- The service sends a POST request to the Activity Logger Service noting the change.
3. Front-end Dashboard:

- A manager wants to view all recent activities across microservices.
- The dashboard sends a GET request to the Activity Logger Service and displays the activities.

**Considerations for Scaling:**
1. Database Partitioning: 
As the number of activities grow, consider partitioning the database table based on timestamps or ServiceID.

2. Async Processing:
Instead of direct database writes, consider using a message queue like RabbitMQ or Kafka to decouple activity logging from the main application logic.

3. Database Indexing: 
Index fields that are frequently queried like ServiceID or UserID to speed up query performance.

**Feedback & Contributions:**

Feel free to fork this project, submit issues, or PRs. Your feedback is invaluable and will help improve this Activity Logger Service for the community.