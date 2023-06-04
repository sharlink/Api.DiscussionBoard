using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class CommentsReplyForCreationDto
    {
        public string Content { get; set; }
        public string ReplyingTo { get; set; }
        public int? Score { get; set; }
    }
}
