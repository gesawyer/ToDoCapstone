using System;
using System.Collections.Generic;

#nullable disable

namespace ToDo.Models
{
    public partial class Tasks
    {

        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; } = false;
       

        public virtual Owner Owner { get; set; }
    }
}
