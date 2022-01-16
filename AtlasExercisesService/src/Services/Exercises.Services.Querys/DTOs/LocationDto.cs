using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Services.Querys
{
    public partial class LocationDto
    {
        public LocationDto()
        {
        }

        public int LocationId { get; set; }
        public string Ubication { get; set; }
        public string Description { get; set; }

    }
}
