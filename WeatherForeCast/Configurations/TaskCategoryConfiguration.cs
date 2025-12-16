using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoTaskApi.Models;

namespace TodoTaskApi.Configurations
{
    public class TaskCategoryConfiguration : IEntityTypeConfiguration<TaskCategory>
    {
        public void Configure(EntityTypeBuilder<TaskCategory> builder)
        {

            builder.Property(w => w.CreatedAt)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
