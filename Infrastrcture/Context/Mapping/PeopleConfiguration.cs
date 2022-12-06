using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEFCore.Infrastrcture.Models;

namespace MyEFCore.Infrastrcture.Context.Mapping
{
    public class PeopleConfiguration : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.ToTable("People");
            builder.HasKey(people => people.Id);
            builder.Property(people => people.Id).HasColumnType("bigint").HasColumnName("id");
            builder.Property(people => people.PeopleType).HasColumnType("nvarchar(50)").HasColumnName("PeopleType").HasMaxLength(50);
            builder.Property(people => people.Sex).HasColumnType("bigint").HasColumnName("Sex");
            builder.Property(people => people.Age).HasColumnType("bigint").HasColumnName("Age");
            builder.Property(people => people.Skills).HasColumnType("bigint").HasColumnName("Skills");
        }
    }
}
