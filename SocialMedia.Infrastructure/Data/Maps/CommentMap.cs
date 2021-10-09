using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Data.Maps
{
  internal class CommentMap : IEntityTypeConfiguration<Comment>
  {
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
      builder.HasKey(e => e.CommentId);

      builder.ToTable("Comentario");

      builder.Property(e => e.CommentId)
        .IsRequired()
        .HasColumnName("IdComentario")
        .ValueGeneratedNever();

      builder.Property(e => e.PostId)
        .IsRequired()
        .HasColumnName("IdPublicacion");

      builder.Property(e => e.UserId)
        .IsRequired()
        .HasColumnName("IdUsuario");

      builder.Property(e => e.Description)
        .IsRequired()
        .HasColumnName("Descripcion")
        .HasMaxLength(500)
        .IsUnicode(false);

      builder.Property(e => e.Date)
        .IsRequired()
        .HasColumnName("Fecha")
        .HasColumnType("datetime");

      builder.Property(e => e.IsActive)
        .IsRequired()
        .HasColumnName("Activo")
        .HasColumnType("bit");

      builder.HasOne(d => d.Post)
        .WithMany(p => p.Comments)
        .HasForeignKey(d => d.PostId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Comentario_Publicacion");

      builder.HasOne(d => d.User)
        .WithMany(p => p.Comments)
        .HasForeignKey(d => d.UserId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Comentario_Usuario");
    }
  }
}