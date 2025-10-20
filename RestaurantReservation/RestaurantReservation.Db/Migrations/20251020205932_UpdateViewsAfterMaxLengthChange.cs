using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class UpdateViewsAfterMaxLengthChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Update Reservation view
            migrationBuilder.Sql(@"
               CREATE OR ALTER VIEW vw_ReservationsWithCustomerRestaurant AS
               SELECT 
                   r.ReservationId,
                   r.ReservationDate,
                   r.PartySize,
                   c.CustomerId,
                   c.FirstName AS CustomerFirstName,
                   c.LastName AS CustomerLastName,
                   c.Email,
                   c.PhoneNumber,
                   res.RestaurantId,
                   res.Name AS RestaurantName,
                   res.Address AS RestaurantAddress
               FROM Reservations r
               JOIN Customers c ON r.CustomerId = c.CustomerId
               JOIN Restaurants res ON r.RestaurantId = res.RestaurantId;
    ");

            migrationBuilder.Sql(@"
              CREATE OR ALTER VIEW vw_EmployeesWithRestaurant AS
              SELECT 
                  e.EmployeeId,
                  e.FirstName,
                  e.LastName,
                  e.Position,
                  r.RestaurantId,
                  r.Name AS RestaurantName,
                  r.Address AS RestaurantAddress,
                  r.PhoneNumber AS RestaurantPhone
              FROM Employees e
              JOIN Restaurants r ON e.RestaurantId = r.RestaurantId;
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS vw_ReservationsWithCustomerRestaurant;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS vw_EmployeesWithRestaurant;");
        }
    }
}
