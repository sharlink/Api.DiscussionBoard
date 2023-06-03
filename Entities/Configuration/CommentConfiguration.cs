using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData
            (
            new Comment
            {  
                Id = 1,
                Content = "Impressive! Though it seems the drag feature could be improved. But overall it looks incredible. You've nailed the design and the responsiveness at various breakpoints works really well.",
                UserId = new Guid("C8DE10E9-7268-4DD1-AE2B-2F897D7F0A58"),
                Score = 12,
                ReplyingTo = null,
                ParentCommantId = null,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new Comment
            {
                Id = 2,
                Content = "Woah, your project looks awesome! How long have you been coding for? I'm still new, but think I want to dive into Angular as well soon. Perhaps you can give me an insight on where I can learn Angular? Thanks!",
                UserId = new Guid("CB4E3EA5-9264-40A9-AE28-24A782B5FFD4"),
                Score = 5,
                ReplyingTo = null,
                ParentCommantId = null,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new Comment
            {
                Id = 3,
                Content = "If you're looking to kick start your career, search no further. React is all you need. Welcome to the Dark Side.",
                UserId = new Guid("1CD9E503-4A83-492A-AFC6-35A9D182CDC1"),
                Score = 4,
                ReplyingTo = "lukeskywalker",
                ParentCommantId = 2,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new Comment
            {
                Id = 4,
                Content = "Chillax, my Padawans. Much to learn, you have. The fundamentals of HTML, CSS, and JS,  I'd recommend focusing on. It's very tempting to jump ahead but lay a solid foundation first. Everything moves so fast and it always seems like everyone knows the newest library/framework. But the fundamentals are what stays constant.",
                UserId = new Guid("21E9638C-2DD9-4C43-B4A6-4C2F5FCB3F59"),
                Score = 2,
                ReplyingTo = "vader",
                ParentCommantId = 2,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
            );
        }
    }
}
