using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FFProject.Models
{
    public class TeamModel
    {
        [Key]
        public int TeamModelID { get; set; }
        public string TeamName { get; set; }

        // EF to generate a FK field
        public List<AppUser> Users { get; }

    }
}
