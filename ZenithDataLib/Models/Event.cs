using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ZenithDataLib.Models
{
    public class Event
    {
        //EventId
        //Event from date and time
        //Event to date and time
        //Entered by username
        //ActivityCategory(FK)
        //CreationDate
        //IsActive

        public int EventId { get; set; }

        [Display(Name = "Starts")]
        public DateTime FromDate { get; set; }

        [Display(Name = "Ends")]
        public DateTime ToDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Created by User:")]
        public string EnteredByUsername { get; set; }

        [Display(Name = "Activity Category")]
        [ForeignKey("ActivityCategory")]
        public int ActivityCategoryId { get; set; }
        public ActivityCategory ActivityCategory { get; set; }

        [Required]
        [Display(Name = "Creation Date:")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Active") ]
        public bool IsActive { get; set; }
    }
}
