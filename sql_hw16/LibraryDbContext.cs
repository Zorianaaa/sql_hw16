using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using sql_hw16;

public class LibraryDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("OracleDbContext");
        optionsBuilder.UseOracle(connectionString);
    }


    public DbSet<Librarian> Librarians { get; set; }
    public DbSet<Reader> Readers { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Reader)
            .WithMany()
            .HasForeignKey(l => l.ReaderId);

        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Book)
            .WithMany()
            .HasForeignKey(l => l.BookId);
    }


}


