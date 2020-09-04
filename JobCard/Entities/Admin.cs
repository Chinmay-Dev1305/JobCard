using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobCard.Entities
{
    public partial class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
