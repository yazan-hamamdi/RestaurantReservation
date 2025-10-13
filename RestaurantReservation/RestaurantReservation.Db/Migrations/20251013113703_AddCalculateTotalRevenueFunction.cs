using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddCalculateTotalRevenueFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE OR ALTER FUNCTION CalculateTotalRevenue(@RestaurantId INT)
            RETURNS DECIMAL(18,2)
            AS
            BEGIN
                DECLARE @TotalRevenue DECIMAL(18,2);
                
                SELECT @TotalRevenue = SUM(o.TotalAmount)
                FROM Orders o
                JOIN Reservations r ON o.ReservationId = r.ReservationId
                WHERE r.RestaurantId = @RestaurantId;

                RETURN ISNULL(@TotalRevenue, 0);
            END
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION CalculateTotalRevenue");
        }
    }
}
