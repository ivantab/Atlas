using Exercise.DataAccess.DataBase;
using Exercise.Services.EventHandler.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise.Services.EventHandler
{
    public class MuscleEventHandler : INotificationHandler<MuscleCreateCommand>
    {
        private readonly AtlasExerciseContext _context;
        private readonly ILogger<MuscleEventHandler> _logger;

        public MuscleEventHandler(AtlasExerciseContext context, ILogger<MuscleEventHandler> logger )
        {
            _logger = logger;
            _context = context;
        }

        public async Task Handle(MuscleCreateCommand command , CancellationToken cancellationToken)
        {

        }

    }
}
