﻿using System;

namespace ModusoftCRM.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }  
        public string Name { get; set; } = string.Empty; 
        public decimal? Latitude { get; set; } 
        public decimal? Longitude { get; set; }  
    }
}
