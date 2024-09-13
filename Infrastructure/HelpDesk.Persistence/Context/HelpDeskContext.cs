namespace HelpDesk.Persistence.Context
{
    public class HelpDeskContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-4M0OQRD\SQLEXPRESS;Database=HelpDesk;User Id=pixxaer;Password=453885;Encrypt=false;TrustServerCertificate=true;");
            //optionsBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-KIBK0ID\SQLEXPRESS;Database=HelpDesk;TrustServerCertificate=true;Trusted_Connection=true;");
        }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketDocument> TicketDocuments { get; set; }
        public DbSet<TicketRoute> TicketRoutes { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StaffDepartment> StaffDepartments { get; set; }
        public DbSet<Mail> Mails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Blank
        }
    }
}
