﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CommentForCreationDto
    {
        public string Content { get; set; }
        public string ReplyingTo { get; set; }
        public int? Score { get; set; }                       
    }
}
