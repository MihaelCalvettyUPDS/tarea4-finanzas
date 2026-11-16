using System;
using finanzas.Models;
using Microsoft.EntityFrameworkCore;

namespace finanzas.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
}
