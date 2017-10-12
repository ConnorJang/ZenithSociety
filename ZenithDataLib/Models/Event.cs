using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models
{
    class Event
    {
        //EventId
        //Event from date and time
        //Event to date and time
        //Entered by username
        //ActivityCategory(FK)
        //CreationDate
        //IsActive

        public int EventId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        [Display(Name = "Created by User:")]
        public string EnteredByUsername { get; set; }

        [ForeignKey("ActiveCategory")]
        public int ActivityCategoryId { get; set; }
        public ActiveCategory ActiveCategory { get; set; }

        [Display(Name = "Creation Date:")]
        public DateTime CreationDate { get; set; }

        public bool IsActive { get; set; }
    }
}
