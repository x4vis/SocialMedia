using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Data.Maps
{
  internal class UserMap : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.HasKey(e => e.UserId);

      builder.ToTable("Usuario");

      builder.Property(e => e.UserId)
        .IsRequired()
        .HasColumnName("IdUsuario");

      builder.Property(e => e.LastName)
        .IsRequired()
        .HasColumnName("Apellidos")
        .HasMaxLength(50)
        .IsUnicode(false);

      builder.Property(e => e.Email)
        .IsRequired()
        .HasMaxLength(30)
        .IsUnicode(false);

      builder.Property(e => e.DateOfBirth)
        .IsRequired()
        .HasColumnName("FechaNacimiento")
        .HasColumnType("date");

      builder.Property(e => e.FirstName)
        .IsRequired()
        .HasColumnName("Nombres")
        .HasMaxLength(50)
        .IsUnicode(false);

      builder.Property(e => e.PhoneNumber)
        .HasColumnName("Telefono")
        .HasMaxLength(10)
        .IsUnicode(false);

      builder.Property(e => e.IsActive)
        .IsRequired()
        .HasColumnName("Activo");
    }
  }
}