using System;
using System.Collections.Generic;

#nullable disable

namespace ToDo.Models
{
    public partial class Owner
    {
        public Owner()
        {
            Tasks = new HashSet<Tasks>();
        }
        public int Id { get; set; }
        public int? OwnerId { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
