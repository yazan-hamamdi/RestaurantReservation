using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.DataModels;
using RestaurantReservation.Db.ViewDTOs;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        public RestaurantReservationDbContext()
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<ReservationView> ReservationViews { get; set; }
        public DbSet<EmployeeView> EmployeeViews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=DESKTOP-22M8TQM;Database=RestaurantReservationCore;Trusted_Connection=True;TrustServerCertificate=True;"
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Restaurant)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Table>()
                .HasOne(t => t.Restaurant)
                .WithMany(r => r.Tables)
                .HasForeignKey(t => t.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Restaurant)
                .WithMany(r => r.MenuItems)
                .HasForeignKey(m => m.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Restaurant)
                .WithMany(rs => rs.Reservations)
                .HasForeignKey(r => r.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Table)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TableId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Reservation)
                .WithMany(r => r.Orders)
                .HasForeignKey(o => o.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Employee)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany(m => m.OrderItems)
                .HasForeignKey(oi => oi.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Restaurant>().HasData(
                 new Restaurant { RestaurantId = 1, Name = "The Italian Place", Address = "123 Main St, NY", PhoneNumber = "212-555-0101", OpeningHours = "10:00 - 22:00" },
                 new Restaurant { RestaurantId = 2, Name = "Sushi World", Address = "45 Ocean Ave, CA", PhoneNumber = "310-555-0202", OpeningHours = "11:00 - 23:00" },
                 new Restaurant { RestaurantId = 3, Name = "BBQ Heaven", Address = "78 BBQ Lane, TX", PhoneNumber = "214-555-0303", OpeningHours = "12:00 - 21:00" },
                 new Restaurant { RestaurantId = 4, Name = "Vegan Delight", Address = "12 Green St, WA", PhoneNumber = "206-555-0404", OpeningHours = "09:00 - 20:00" },
                 new Restaurant { RestaurantId = 5, Name = "Bistro Paris", Address = "88 Rue de Lyon, NY", PhoneNumber = "212-555-0505", OpeningHours = "10:00 - 23:00" }
             );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com", PhoneNumber = "212-555-1001" },
                new Customer { CustomerId = 2, FirstName = "Sarah", LastName = "Smith", Email = "sarah.smith@yahoo.com", PhoneNumber = "310-555-1002" },
                new Customer { CustomerId = 3, FirstName = "Michael", LastName = "Brown", Email = "michael.brown@gmail.com", PhoneNumber = "214-555-1003" },
                new Customer { CustomerId = 4, FirstName = "Emily", LastName = "Davis", Email = "emily.davis@hotmail.com", PhoneNumber = "206-555-1004" },
                new Customer { CustomerId = 5, FirstName = "Robert", LastName = "Johnson", Email = "robert.johnson@gmail.com", PhoneNumber = "212-555-1005" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, RestaurantId = 1, FirstName = "Alice", LastName = "Walker", Position = "Manager" },
                new Employee { EmployeeId = 2, RestaurantId = 2, FirstName = "Bob", LastName = "Lewis", Position = "Chef" },
                new Employee { EmployeeId = 3, RestaurantId = 3, FirstName = "Carol", LastName = "Hall", Position = "Waiter" },
                new Employee { EmployeeId = 4, RestaurantId = 4, FirstName = "David", LastName = "King", Position = "Manager" },
                new Employee { EmployeeId = 5, RestaurantId = 5, FirstName = "Eve", LastName = "Scott", Position = "Waiter" }
            );

            modelBuilder.Entity<Table>().HasData(
                new Table { TableId = 1, RestaurantId = 1, Capacity = 4 },
                new Table { TableId = 2, RestaurantId = 1, Capacity = 2 },
                new Table { TableId = 3, RestaurantId = 2, Capacity = 6 },
                new Table { TableId = 4, RestaurantId = 3, Capacity = 4 },
                new Table { TableId = 5, RestaurantId = 4, Capacity = 8 }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { MenuItemId = 1, RestaurantId = 1, Name = "Spaghetti Carbonara", Description = "Classic Italian pasta dish", Price = 12.99m },
                new MenuItem { MenuItemId = 2, RestaurantId = 2, Name = "Salmon Sushi Roll", Description = "Fresh salmon sushi roll", Price = 15.50m },
                new MenuItem { MenuItemId = 3, RestaurantId = 3, Name = "BBQ Ribs", Description = "Smoked ribs with BBQ sauce", Price = 18.00m },
                new MenuItem { MenuItemId = 4, RestaurantId = 4, Name = "Vegan Burger", Description = "Plant-based burger with fries", Price = 11.50m },
                new MenuItem { MenuItemId = 5, RestaurantId = 5, Name = "Croissant Sandwich", Description = "Ham and cheese croissant", Price = 9.99m }
            );

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { ReservationId = 1, CustomerId = 1, RestaurantId = 1, TableId = 1, ReservationDate = new DateTime(2025, 10, 15, 19, 0, 0), PartySize = 2 },
                new Reservation { ReservationId = 2, CustomerId = 2, RestaurantId = 2, TableId = 3, ReservationDate = new DateTime(2025, 10, 16, 12, 30, 0), PartySize = 4 },
                new Reservation { ReservationId = 3, CustomerId = 3, RestaurantId = 3, TableId = 4, ReservationDate = new DateTime(2025, 10, 17, 18, 0, 0), PartySize = 3 },
                new Reservation { ReservationId = 4, CustomerId = 4, RestaurantId = 4, TableId = 5, ReservationDate = new DateTime(2025, 10, 18, 20, 0, 0), PartySize = 5 },
                new Reservation { ReservationId = 5, CustomerId = 5, RestaurantId = 5, TableId = 2, ReservationDate = new DateTime(2025, 10, 19, 13, 0, 0), PartySize = 1 }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, ReservationId = 1, EmployeeId = 1, OrderDate = new DateTime(2025, 10, 15, 19, 15, 0), TotalAmount = 25.98m },
                new Order { OrderId = 2, ReservationId = 2, EmployeeId = 2, OrderDate = new DateTime(2025, 10, 16, 12, 45, 0), TotalAmount = 62.00m },
                new Order { OrderId = 3, ReservationId = 3, EmployeeId = 3, OrderDate = new DateTime(2025, 10, 17, 18, 10, 0), TotalAmount = 54.00m },
                new Order { OrderId = 4, ReservationId = 4, EmployeeId = 4, OrderDate = new DateTime(2025, 10, 18, 20, 20, 0), TotalAmount = 57.50m },
                new Order { OrderId = 5, ReservationId = 5, EmployeeId = 5, OrderDate = new DateTime(2025, 10, 19, 13, 10, 0), TotalAmount = 9.99m }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = 1, OrderId = 1, ItemId = 1, Quantity = 2 },
                new OrderItem { OrderItemId = 2, OrderId = 2, ItemId = 2, Quantity = 4 },
                new OrderItem { OrderItemId = 3, OrderId = 3, ItemId = 3, Quantity = 3 },
                new OrderItem { OrderItemId = 4, OrderId = 4, ItemId = 4, Quantity = 5 },
                new OrderItem { OrderItemId = 5, OrderId = 5, ItemId = 5, Quantity = 1 }
            );

            modelBuilder
              .Entity<ReservationView>()
              .HasNoKey() 
              .ToView("vw_ReservationsWithCustomerRestaurant"
            );

            modelBuilder
              .Entity<EmployeeView>()
              .HasNoKey() 
              .ToView("vw_EmployeesWithRestaurant"
           );
        }
    }
}
