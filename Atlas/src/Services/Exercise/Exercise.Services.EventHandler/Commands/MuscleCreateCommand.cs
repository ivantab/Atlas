using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Services.EventHandler.Commands
{
    public class MuscleCreateCommand : INotification
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Location { get; set; }
    }
}
