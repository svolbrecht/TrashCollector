using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
      

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zipcode { get; set; }

        public string Balance { get; set; }

        public bool IsTrashPickedUp { get; set; }

        [Display(Name = "Weekly Pickup Day")]
        public string WeeklyPickUp { get; set; }

        [Display(Name = "Special Pickup")]
        public string SpecialPickUp { get; set; }

        [Display(Name = "Service Hold Start Date")]
        public DateTime? StartPickUp { get; set; }

        [Display(Name = "Service Hold End Date")]
        public string EndPickUp { get; set; }


        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}