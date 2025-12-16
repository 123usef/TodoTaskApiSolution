using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoTaskApi.Models;

namespace TodoTaskApi.Configurations
{
    public class TodoTaskConfiguration : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.Property(w => w.Name)
                 .IsRequired(true)
                 .HasMaxLength(50);
            builder.Property(w => w.CreatedAt)
                .HasDefaultValue(DateTime.Now);

            builder.Property(w=>w.IsCompleted)
                .HasDefaultValue(false);
                

                
        }
    }
}
