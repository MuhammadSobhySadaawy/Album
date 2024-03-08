using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album.Models
{
    public class Defaults
    {
        public DateTime createdAt { get; set; }
        public int createdBy { get; set; }
        public DateTime? modifiedAt { get; set; }
        public int? modifiedBy { get; set; }
        public bool? isDeleted { get; set; }
        public bool? isEnabled { get; set; }
        public Defaults()
        {
            createdAt = DateTime.UtcNow;
            isDeleted = false;
            isEnabled = true;
            modifiedBy = -1;
        }
    }
}
