using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CommentsWithRepliesDto
    {
        public int commentId { get; set; }
        public string content { get; set; }
        public DateTime? createdAt { get; set; }
        public int? score { get; set; }
        public Guid userId { get; set; }
        public List<Reply> replies { get; set; }
    }

    public class Reply
    {
        public int commentId { get; set; }
        public string content { get; set; }
        public DateTime? createdAt { get; set; }
        public int? score { get; set; }
        public string replyingTo { get; set; }
        public Guid? userId { get; set; }
    }   

}
