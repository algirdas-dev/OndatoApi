using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ondato.DB.Models;

namespace Ondato.DB.Configs
{
    public static class DictionaryKeyConfig
    {
        public static void Configs(this EntityTypeBuilder<DictionaryKey> model) {
            model.ToTable("DictionaryKeys");
            model.HasKey(c => c.Key);
            model.HasMany(dk => dk.DictionaryValues).WithOne(dv => dv.DictionaryKey).HasForeignKey(dv => dv.Key).HasPrincipalKey(dk => dk.Key);
            model.Property(c => c.Key).IsRequired().HasMaxLength(50);
            model.Property(c => c.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");
            model.Property(c => c.UpdatedDate).IsRequired().HasDefaultValueSql("getdate()");
        }
    }
}
