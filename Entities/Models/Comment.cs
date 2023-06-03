using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Entities.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CommentId")]
        public int Id { get; set; }
        [Column("CommentContent")]
        public string Content { get; set; }
        public string ReplyingTo { get; set; }
        public int? Score { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ParentCommantId { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User Users { get; set; }
    }
}
