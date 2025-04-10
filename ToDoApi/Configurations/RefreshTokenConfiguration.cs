using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoApi.Configurations
{
    // Конфигурация сущности RefreshToken с помощью Fluent API
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(r => r.Id);                          // Установка первичного ключа

            builder.Property(r => r.Token)
                .IsRequired()
                .HasMaxLength(200);                             // Установка обязательного поля Token с максимальной длиной 200 символов

            builder.Property(r => r.ExpiresAt).IsRequired();    // Установка обязательного поля ExpiresAt

            builder.HasOne(r => r.User)                         // Устанавливаем связь один - ко многим
                .WithMany(u => u.RefreshToken)
                .HasForeignKey(r => r.UserId);                  // И внешний ключ
        }
    }
}
