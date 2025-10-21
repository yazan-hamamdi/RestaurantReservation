using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "john.doe@gmail.com", "John", "Doe", "212-555-1001" },
                    { 2, "sarah.smith@yahoo.com", "Sarah", "Smith", "310-555-1002" },
                    { 3, "michael.brown@gmail.com", "Michael", "Brown", "214-555-1003" },
                    { 4, "emily.davis@hotmail.com", "Emily", "Davis", "206-555-1004" },
                    { 5, "robert.johnson@gmail.com", "Robert", "Johnson", "212-555-1005" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St, NY", "The Italian Place", "10:00 - 22:00", "212-555-0101" },
                    { 2, "45 Ocean Ave, CA", "Sushi World", "11:00 - 23:00", "310-555-0202" },
                    { 3, "78 BBQ Lane, TX", "BBQ Heaven", "12:00 - 21:00", "214-555-0303" },
                    { 4, "12 Green St, WA", "Vegan Delight", "09:00 - 20:00", "206-555-0404" },
                    { 5, "88 Rue de Lyon, NY", "Bistro Paris", "10:00 - 23:00", "212-555-0505" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Alice", "Walker", "Manager", 1 },
                    { 2, "Bob", "Lewis", "Chef", 2 },
                    { 3, "Carol", "Hall", "Waiter", 3 },
                    { 4, "David", "King", "Manager", 4 },
                    { 5, "Eve", "Scott", "Waiter", 5 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Classic Italian pasta dish", "Spaghetti Carbonara", 12.99m, 1 },
                    { 2, "Fresh salmon sushi roll", "Salmon Sushi Roll", 15.50m, 2 },
                    { 3, "Smoked ribs with BBQ sauce", "BBQ Ribs", 18.00m, 3 },
                    { 4, "Plant-based burger with fries", "Vegan Burger", 11.50m, 4 },
                    { 5, "Ham and cheese croissant", "Croissant Sandwich", 9.99m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 2, 1 },
                    { 3, 6, 2 },
                    { 4, 4, 3 },
                    { 5, 8, 4 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2025, 10, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 2, 4, new DateTime(2025, 10, 16, 12, 30, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 3, 3, 3, new DateTime(2025, 10, 17, 18, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 4, 4, 5, new DateTime(2025, 10, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 5, 5, 1, new DateTime(2025, 10, 19, 13, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 10, 15, 19, 15, 0, 0, DateTimeKind.Unspecified), 1, 25.98m },
                    { 2, 2, new DateTime(2025, 10, 16, 12, 45, 0, 0, DateTimeKind.Unspecified), 2, 62.00m },
                    { 3, 3, new DateTime(2025, 10, 17, 18, 10, 0, 0, DateTimeKind.Unspecified), 3, 54.00m },
                    { 4, 4, new DateTime(2025, 10, 18, 20, 20, 0, 0, DateTimeKind.Unspecified), 4, 57.50m },
                    { 5, 5, new DateTime(2025, 10, 19, 13, 10, 0, 0, DateTimeKind.Unspecified), 5, 9.99m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "ItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 2, 4 },
                    { 3, 3, 3, 3 },
                    { 4, 4, 4, 5 },
                    { 5, 5, 5, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4);
        }
    }
}
