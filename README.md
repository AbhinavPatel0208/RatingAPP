# RATINGWEB


## Overview

The primary goal is to provide users with a seamless experience in discovering, rating, and sorting products.

## Features

- **Product Management:**
  - Create, update, and delete products.
  - Manage product details: name, image, category, price, and rating.

- **User Roles:**
  - **End User:**
    - Browse and rate products.
    - Sort products by price or best rating within a category.
  - **Administrators:**
    - Exclusive access to product creation, update, and deletion.

## Key Technologies

List the key technologies and frameworks used in your project. For example:
- ASP.NET Core
- Entity Framework Core
- Bootstrap

![1](https://github.com/AbhinavPatel0208/RatingApp/assets/71115461/0f6cb01c-ddf5-4aed-8c86-e209c788288d)

## Architecture
![2](https://github.com/AbhinavPatel0208/RatingApp/assets/71115461/2417fdc8-4653-4065-9e04-089f6d071d86)
![3](https://github.com/AbhinavPatel0208/RatingApp/assets/71115461/5e2f3c39-6fd6-448c-9287-372d6c028d1c)


### 1. Model-View-Controller (MVC):

**Model:**
- Represents the application's data and business logic.
- Includes entities for products, categories, ratings, and user-related information.
- Utilizes Entity Framework Core for seamless database interactions.

**View:**
- Handles the presentation layer, providing a user interface for interacting with the application.
- Implemented using HTML, CSS, and JavaScript to ensure a responsive and engaging user experience.

**Controller:**
- Manages the flow of data between the Model and the View.
- Contains logic for handling user requests, processing data, and determining the appropriate response.

### 2. Repository Design:

**Product Repository:**
- Manages the data access and manipulation related to products.
- Implements CRUD (Create, Read, Update, Delete) operations for products.

**Category Repository:**
- Handles operations related to product categories.
- Ensures efficient retrieval and management of category-related data.

**Rating Repository:**
- Manages user ratings for products.
- Enables the retrieval and storage of product ratings.

### 3. Unit of Work:

**UnitOfWork:**
- Coordinates and manages the execution of multiple repository operations within a single transaction.
- Ensures atomicity and consistency of operations, enhancing data integrity.

## Interaction Flow:

1. **User Interaction:**
   - Users interact with the application through the View, initiating requests.

2. **Controller Handling:**
   - Controllers receive user requests, invoke the necessary business logic, and determine the appropriate response.

3. **Data Access:**
   - Repositories handle data access and manipulation, ensuring proper interaction with the underlying database.

4. **Unit of Work Integration:**
   - Unit of Work coordinates multiple repository operations within a transaction, ensuring data consistency.

5. **Response to View:**
   - The Controller sends the processed data back to the View for presentation to the user.

## Advantages of the Architecture:

- **Modularity:**
  - Each component (Model, View, Controller, Repositories) is modular, promoting code organization and reusability.

- **Maintainability:**
  - Separation of concerns simplifies maintenance tasks for different parts of the application.

- **Scalability:**
  - The architecture supports the addition of new features and scaling of the application with ease.


# Getting Started

## Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/downloads/) installed.
- [.NET Core SDK](https://dotnet.microsoft.com/download) installed.

## Run The Project using this steps

1. **Clone the repository:**
 https://github.com/AbhinavPatel0208/RatingApp.git
 
2. **Open the project in Visual Studio.**

3. **Update Database Connection String:**

5. **Open the appsettings.json file and locate the connection string. Modify it according to your SQL Server setup.**

4. **Open the Package Manager Console:**
        Tools -> NuGet Package Manager -> Package Manager Console
6. **Run Entity Framework migrations to apply the database changes:**
       run command update-database

7. **Build the solution.**

8. **Run the application in Visual Studio.**

9. **Access the application in your web browser:**
