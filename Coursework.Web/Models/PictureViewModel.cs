using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Coursework.Entity.Entities;

namespace Coursework.Web.Models
{
    public class PictureViewModel
    {
        [Key]
        public long FlowerId { get; set; }

        public byte[] Image { get; set; }
    }
}