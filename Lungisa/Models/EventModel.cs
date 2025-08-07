using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lungisa.Models
{
    public class EventModel
    {
        public string Name { get; set; }
        public string DateTime { get; set; }  // Store as string for simplicity
        public string Venue { get; set; }
        public string Description { get; set; }
    }
}