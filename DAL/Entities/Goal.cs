using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Goal
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public int MatchId { get; set; }
    }
}
