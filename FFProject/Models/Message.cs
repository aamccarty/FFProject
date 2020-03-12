using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FFProject.Models
{
    public class Message
    {   
        public int MessageID { get; set; }

        [StringLength(1000, MinimumLength = 2)]
        [Required]
        public string MessageText { get; set; }
        public AppUser Messenger { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}
