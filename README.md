# Restaurant Reservation System

A sample project to manage restaurants, reservations, menu items, orders, and employees using **Entity Framework Core** with a 3-layer architecture (Data, Services, Console App).

---

## Project Overview

- **Language:** C# (.NET 8+)
- **ORM:** Entity Framework Core
- **Database:** SQL Server
- **Architecture:** 3-layer (Repositories, Services, Console app)
- **Main Features:** Entities, Repositories, Services, Migrations, Seed Data, Views, Stored Procedures, Database Functions

---

## Features Implemented

- **Entities:** `Restaurant`, `MenuItem`, `Order`, `OrderItem`, `Employee`, `Reservation`, `Customer`, `Table`
  - Fully configured relationships using **Fluent API**
  - Navigation properties initialized with `ICollection<T>`
  
- **DbContext:** `RestaurantReservationDbContext`
  - Includes `DbSet`s for entities and views
  - Configured relationships with Fluent API

- **Repositories:** Generic base repository and entity-specific repositories (`IRepository<T>` and implementations)

- **Services:** Entity-specific services (`RestaurantService`, `OrderService`, etc.)
  - Business logic and validation
  - Throws `EntityNotFoundException` where necessary

- **Migrations:**
  - Tables with relationships
  - Seed data with 5+ meaningful records per table
  - Views (`vw_ReservationsWithCustomerRestaurant`, `vw_EmployeesWithRestaurant`)
  - Functions (`CalculateTotalRevenue(restaurantId)`)
  - Stored Procedures (`GetCustomersByPartySize`)

- **Sample Methods Implemented:**
  - `ListManagers()`
  - `GetReservationsByCustomer(customerId)`
  - `ListOrdersAndMenuItems(reservationId)`
  - `ListOrderedMenuItems(reservationId)`
  - `CalculateAverageOrderAmount(employeeId)`

---

