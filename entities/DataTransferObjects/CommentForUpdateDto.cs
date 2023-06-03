using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CommentForUpdateDto
    {
        public string Content { get; set; }        
        public int Score { get; set; }
        public string ReplyingTo { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
