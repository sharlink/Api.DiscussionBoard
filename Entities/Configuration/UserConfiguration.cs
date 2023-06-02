using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
                 (
                 new User
                 {
                     UserId = new Guid("CB4E3EA5-9264-40A9-AE28-24A782B5FFD4"),                    
                     UserName = "lukesksywalker",
                     CreatedAt = DateTime.Now,
                 },
                 new User
                 {
                     UserId = new Guid("C8DE10E9-7268-4DD1-AE2B-2F897D7F0A58"),
                     UserName = "leiaskywalker",
                     CreatedAt = DateTime.Now,
                 },
                 new User
                 {
                     UserId = new Guid("1CD9E503-4A83-492A-AFC6-35A9D182CDC1"),
                     UserName = "vader",
                     CreatedAt = DateTime.Now,
                 },
                 new User
                 {
                     UserId = new Guid("21E9638C-2DD9-4C43-B4A6-4C2F5FCB3F59"),
                     UserName = "yoda",
                     CreatedAt = DateTime.Now,
                 }
                 );

        }
    }
}
