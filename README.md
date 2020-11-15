# BackendAssignmentPt2
Second part of the Backend mendatory assignment of the web shop. This project is based on Adam Freemans' application in his book series "Pro ASP.NET Core 3" and "Pro ASP.NET Core MVC 2" with modifications.
### The assignment includes:
-	A product catalogue that can be browsed by category and page.
-	A shopping cart where products can be added or removed (removes selected product regardless of quantity).
### What will be included additionally:
-	A checkout form for shipping the order.
-	A dropdown menu option to change the quantity of products added to the cart.
-	An option in the cart to remove or add single unit of a product instead of removing the entire line.
-	An admin area that will utilize CRUD operations for managing the catalogue.
-	Admin authentication
### Implementation details:
- Entity Framework code-first approach.
- Repository pattern + dependency injection (controller injection)
- Shopping cart icon with Font Awesome toolkit.
- Session state to store details of a user’s cart.
- Partial views to reduce code duplication (add to cart button for every product)
### Folder Structure:
- Controllers, Models and Views - well-known naming conventions for the main folders.
- Infrastructure - contains classes that deliver the “plumbing” for an application but that are not related to the application’s main functionality.
- Components (in Models) - the conventional home for view components – for example by default MVC searches the partial view of a view component class in a folder with the same name in Views folder. 
- DataModels - contains classes related to the Entity Framework (EF) and are related only to that layer of the application. 
- ViewModels - since view models are designed exclusively to support the UI they are put in a separate folder.
- Migrations - Entity Framework provides a way to incrementally update the database schema to keep it in sync with the application's data model while preserving existing data in the database.
