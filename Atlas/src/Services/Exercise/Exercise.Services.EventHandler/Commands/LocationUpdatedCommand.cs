using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Services.EventHandler.Commands
{
    public class LocationUpdatedCommand : INotification
    {
        public int LocationId { get; set; }
        public string Ubication { get; set; }
        public string Description { get; set; }
    }
}
