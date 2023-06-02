using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Entities.Models
{
    public partial class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public string CommentContent { get; set; }
        public string ReplyingTo { get; set; }
        public int? Score { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ParentCommantId { get; set; }
        public virtual User User { get; set; }
    }
}
