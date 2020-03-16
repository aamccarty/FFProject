using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FFProject.Models
{
    public class TradeOffer
    {
        private List<TradeOffer> players = new List<TradeOffer>();

        [Key]
        public int TradeID { get; set; }

        public List<TradeOffer> Trades { get { return players; } }

        public string PName { get; set; }

        public string PPosition { get; set; }

        public int PValue { get; set; }




    }
}
