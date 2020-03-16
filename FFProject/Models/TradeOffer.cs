using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FFProject.Models
{
    public class TradeOffer
    {
        [Key]
        public int TradeID { get; set; }

        public List<TradeOffer> Player { get; set; }


    }
}
