using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FFProject.Models
{
    public class Roster
    { 
        [Key]
        public int RosterID { get; set; }

        public string PlayerName { get; set; }

        public string PlayerPosition { get; set; }

        public int PlayerValue { get; set; }

       
    }
}
