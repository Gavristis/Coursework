﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coursework.Entity.Entities;

namespace Coursework.Web.Models
{
    public class FlowerViewModel
    {
        public long FlowerId { get; set; }

        public string UserId { get; set; }
        
        public string FlowerName { get; set; }

        public virtual User User { get; set; }

        public double Moisture { get; set; }

        public double Temperature { get; set; }

        public double Light { get; set; }

        public virtual Picture Picture { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}