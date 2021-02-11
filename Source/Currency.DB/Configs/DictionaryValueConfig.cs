using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ondato.DB.Models;

namespace Ondato.DB.Configs
{
    public static class DictionaryValueConfig
    {
        public static void Configs(this EntityTypeBuilder<DictionaryValue> model) {
            model.ToTable("DictionaryValues");
            model.HasKey(dv => dv.DictionaryValueId);
            model.Property(c => c.Key).IsRequired().HasMaxLength(50);
            model.Property(c => c.Value).IsRequired();
        }
    }
}
