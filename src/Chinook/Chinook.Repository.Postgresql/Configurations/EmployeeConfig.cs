using Chinook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Repository.Postgresql.Configurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employee")
               .HasKey(c => c.EmployeeId)
               .HasName("employee_employee_id_pkey");

            builder.Property(e => e.EmployeeId)
                .HasColumnName("employee_id")
                .UseNpgsqlIdentityColumn();

            builder.Property(e => e.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(30);

            builder.Property(e => e.BirthDate)
                .HasColumnName("birth_date")
                .HasColumnType("date");

            builder.Property(e => e.HireDate)
                .HasColumnName("hire_date")
                .HasColumnType("date");

            builder.Property(e => e.Address)
                .HasColumnName("address")
                .HasMaxLength(70);

            builder.Property(e => e.City)
                .HasColumnName("city")
                .HasMaxLength(40);

            builder.Property(e => e.State)
                .HasColumnName("state")
                .HasMaxLength(40);

            builder.Property(e => e.Country)
                .HasColumnName("country")
                .HasMaxLength(40);

            builder.Property(e => e.PostalCode)
                .HasColumnName("postal_code")
                .HasMaxLength(10);

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasMaxLength(24);

            builder.Property(e => e.Fax)
                .HasColumnName("fax")
                .HasMaxLength(24);

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(60);

            builder.HasOne(d => d.ReportsToManager)
                .WithMany(p => p.EmployeesInCharge)
                .HasForeignKey(d => d.ReportsTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee__reference_employee__fkey");
        }
    }
}
