using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public partial class User
    {        
        public User()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime? CreatedAt { get; set; }        
        public virtual ICollection<Comment> Comments { get; set; }
    }


}
