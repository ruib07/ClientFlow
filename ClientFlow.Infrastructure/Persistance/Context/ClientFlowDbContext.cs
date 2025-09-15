using ClientFlow.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClientFlow.Infrastructure.Persistance.Context;

public class ClientFlowDbContext : IdentityDbContext<ApplicationUser>
{
    public ClientFlowDbContext(DbContextOptions<ClientFlowDbContext> options) : base(options) { }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Interaction> Interactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
