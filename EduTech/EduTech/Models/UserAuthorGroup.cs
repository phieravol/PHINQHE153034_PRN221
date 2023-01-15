using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class UserAuthorGroup
    {
        public string? Username { get; set; }
        public int? GroupId { get; set; }

        public virtual AuthorGroup? Group { get; set; }
        public virtual User? UsernameNavigation { get; set; }
    }
}
