using Microsoft.EntityFrameworkCore;

namespace crmLead.Models;

public partial class CrmDbContext : DbContext
{
    // 1. Constructores requeridos para la inyección de dependencias
    public CrmDbContext()
    {
    }

    public CrmDbContext(DbContextOptions<CrmDbContext> options)
        : base(options)
    {
    }

    // 2. Aquí irán tus tablas (DbSet). EF Core las llenará automáticamente.
    // Ejemplo:
    // public virtual DbSet<Lead> Leads { get; set; }
    // public virtual DbSet<User> Users { get; set; }

    // 3. Configuración de la conexión (Vacía para mayor seguridad)
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Se deja vacío intencionalmente. 
        // La conexión se debe registrar en el archivo Program.cs
    }

    // 4. Mapeo de relaciones y restricciones de la base de datos
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // El comando 'scaffold' escribirá aquí automáticamente el mapeo 
        // de tus llaves primarias, foráneas y tipos de datos.
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
