using APIProjectMCC75.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProjectMCC75.Contexts;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<ProductLine> Products { get; set; }
    public DbSet<ProductLine> ProductLines { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Office>().HasIndex(o => new
        {
            o.PhoneNumber
        }).IsUnique();
        modelBuilder.Entity<Employee>().HasIndex(e => new
        {
            e.Email
        }).IsUnique();
        modelBuilder.Entity<Customer>().HasIndex(c => new
        {
            c.PhoneNumber
        }).IsUnique();

        modelBuilder.Entity<Employee>()
            .HasOne(a => a.Account)
            .WithOne(e => e.Employee)
            .HasForeignKey<Account>(fk => fk.Employee_Id);

        //tambah relasi many employee to one repotto
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Employees)
            .WithOne(e => e.ReportTo)
            .HasForeignKey(fk => fk.ReportsTo)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                Name = "Admin"
            },
            new Role
            {
                Id = 2,
                Name = "User"
            });
    }
}