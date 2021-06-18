using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace NooBIT.Model.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder UseTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
                entity.SetTableName(entity.DisplayName());

            return modelBuilder;
        }

        public static ModelBuilder UseIndexNamingConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
                foreach (var index in entity.GetIndexes())
                    index.SetDatabaseName("UX_" + entity.DisplayName() + "_" + index.DeclaringEntityType.Name);

            return modelBuilder;
        }

        public static ModelBuilder UseDateTime2Convention(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes().Where(x => x.GetProperties().Any(y => y.ClrType == typeof(DateTime) || y.ClrType == typeof(DateTime?))))
            {
                var properties = entity.GetProperties().Where(x => x.ClrType == typeof(DateTime) || x.ClrType == typeof(DateTime?)).Select(x => x.Name);
                foreach (var property in properties) modelBuilder.Entity(entity.Name).Property(property).HasColumnType("datetime2(7)");
            }

            return modelBuilder;
        }
    }
}