using ClassLibrary1;
using Microsoft.EntityFrameworkCore;

public class LaboratoryContext : DbContext
{
    public LaboratoryContext(DbContextOptions<LaboratoryContext> options) : base(options) { }

    public DbSet<Research> Researches { get; set; }
    public DbSet<Scientist> Scientists { get; set; }
    public DbSet<Equipment> Equipments { get; set; }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Research>().ToTable("Researches");
        modelBuilder.Entity<Scientist>().ToTable("Scientists");
        modelBuilder.Entity<Equipment>().ToTable("Equipments");
    }*/
}

namespace ClassLibrary1
{
    public class Research
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class Scientist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FieldOfStudy { get; set; }
    }

    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}