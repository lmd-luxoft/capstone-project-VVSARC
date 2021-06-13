

using HomeAccouting.BusinessLogic.EF.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HomeAccouting.BusinessLogic.EF.AppLogic
{
    public class DomainContext : DbContext
    {

        private readonly string _connectionstring = "Data Source=DESKTOP-CMIGEHE;Initial Catalog=HomeAccounting;Integrated Security=True;";
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Cash> Cashes { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyPriceChange> PricesChanges { get; set; }

        public DbSet<Deposit> Deposites { get; set; }

        public DomainContext ()
        {
        //    //Database.Ensur
        }

        public DomainContext (DbContextOptions<DomainContext> opt) : base(opt)
        {
           // base.OnConfiguring(opt.buil);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionstring);
           // Database.EnsureDeleted();

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>().HasKey(x => x.Id);
            modelBuilder.Entity<Bank>().HasKey(x => x.Id);
            modelBuilder.Entity<Deposit>().ToTable("Deposites");
            modelBuilder.Entity<Cash>().ToTable("Cashes");
            modelBuilder.Entity<Property>().ToTable("Properties").HasMany<PropertyPriceChange>(x => x.PropertyPriceChanges);
            modelBuilder.Entity<PropertyPriceChange>();
            modelBuilder.Entity<Operation>().HasMany<Account>(x => x.Accounts)
            .WithMany(r => r.Operations)
            .UsingEntity<Dictionary<string, object>>(
                "OperationsAccounts",
                j => j.HasOne<Account>()
                    .WithMany()
                    .HasForeignKey("AccountID"),
                j => j
                    .HasOne<Operation>()
                    .WithMany()
                    .HasForeignKey("OperationID"));



        }
    }
}
