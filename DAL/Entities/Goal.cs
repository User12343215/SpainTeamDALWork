﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Goal
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int MatchId { get; set; }
    }
}
