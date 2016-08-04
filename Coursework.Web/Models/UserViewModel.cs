using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Coursework.Entity.Entities;

namespace Coursework.Web.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Range(1, 1000, ErrorMessage = "Number of purchased flowers must be between 1 and 1000")]
        public int Purchased { get; set; }

        public virtual ICollection<Flower> Flowers { get; set; }
    }
}