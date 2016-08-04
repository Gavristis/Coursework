using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Entity.Entities
{
    public class Picture
    {
        public long FlowerId { get; set; }

        public virtual Flower Flower { get; set; }

        public byte[] Image { get; set; }
    }
}
