using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CommentDto
    {
        public string Content { get; set; }
        public string ReplyingTo { get; set; }
        public int? Score { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? ParentCommantId { get; set; }        
        public Guid UserId { get; set; }
    }
}
