﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIMM.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CodeUrl { get; set; }
        public string CIUrl { get; set; }

        public Accomplishments Accomplishments { get; set; }
    }
}