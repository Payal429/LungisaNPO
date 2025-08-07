﻿namespace Lungisa.Models
{
    public class ProjectModel
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ImageUrl { get; set; }  // optional for now
    }
}