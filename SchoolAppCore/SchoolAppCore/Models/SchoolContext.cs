using Microsoft.EntityFrameworkCore;

namespace SchoolAppCore.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Cấu hình bảng Instructor: Map property InstructorID với cột "ID" trong SQL Server
            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.ToTable("Instructor");
                entity.HasKey(e => e.InstructorID);
                entity.Property(e => e.InstructorID).HasColumnName("ID");
            });

            // 2. Cấu hình bảng Department
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");
                entity.HasKey(e => e.DepartmentID);
                entity.Property(e => e.DepartmentID).HasColumnName("DepartmentID");
                entity.Property(e => e.InstructorID).HasColumnName("InstructorID");
                entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");
            });

            // 3. Cấu hình bảng Course
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");
                entity.HasKey(e => e.CourseID);
                entity.Property(e => e.CourseID).HasColumnName("CourseID");
                entity.Property(e => e.Title).HasColumnName("Title");
                entity.Property(e => e.Credits).HasColumnName("Credits");
                entity.Property(e => e.DepartmentID).HasColumnName("DepartmentID");

                // Liên kết Course với Department
                entity.HasOne(c => c.Department)
                      .WithMany(d => d.Courses)
                      .HasForeignKey(c => c.DepartmentID);
            });

            // 4. Cấu hình Student và Enrollment
            modelBuilder.Entity<Student>().ToTable("Student");

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("Enrollment");
                entity.Property(e => e.Grade).HasColumnType("decimal(3, 2)");
            });
        }
    }
}