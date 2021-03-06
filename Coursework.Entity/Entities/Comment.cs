﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Entity.Entities
{
    public class Comment
    {
        public long CommentId { get; set; }

        public long FlowerId { get; set; }

        public string UserId { get; set; }

        public virtual Flower Flower { get; set; }

        public virtual User User { get; set; }

        public DateTime Time { get; set; }

        public string Text { get; set; }
    }
}