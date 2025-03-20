using Microsoft.EntityFrameworkCore;
using StudentsTestAPI.Models;

namespace StudentsTestAPI.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>(entity =>
            {
                // 表名明确指定为"Students"
                entity.ToTable("Students");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.StudentNumber).IsRequired();
                entity.HasIndex(e => e.StudentNumber).IsUnique();
            });
        }
    }
}
//command to generate table ORM
/*Scaffold-DbContext "Data Source=students.db" Microsoft.EntityFrameworkCore.Sqlite -OutputDir Models -ContextDir Data -Context StudentContext -Tables Students*/