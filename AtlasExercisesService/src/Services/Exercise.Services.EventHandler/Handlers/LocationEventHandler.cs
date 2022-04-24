using Exercise.DataAccess.DataBase;
using Exercise.Services.EventHandler.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Services.Loggin;
using Exercise.Services.EventHandler.Exceptions;

namespace Exercise.Services.EventHandler.Handlers
{
    public class LocationEventHandler : INotificationHandler<LocationCreateCommand> , INotificationHandler<LocationUpdatedCommand>
    {
        private readonly AtlasExercisesContext _context;
        private readonly ILogger _logger;

        public LocationEventHandler(AtlasExercisesContext context,ILogger<LocationEventHandler> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Handle(LocationCreateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation(command.GetType().ToString() + LogEnums.LogEnum.Started.ToString());
                await _context.Locations.AddAsync(new Domain.Models.Location()
                {
                    Description = command.Description,
                    Ubication = command.Ubication,
                });
                await _context.SaveChangesAsync();
                _logger.LogInformation(command.GetType().ToString() + LogEnums.LogEnum.Ended.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(command.GetType().ToString() + LogEnums.LogEnum.Error.ToString());
                throw ex;
            }                  
        }

        public async Task Handle(LocationUpdatedCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation(command.GetType().ToString() + LogEnums.LogEnum.Started.ToString());
                using (var trx = await _context.Database.BeginTransactionAsync())
                {
                    var data = _context.Locations.SingleOrDefaultAsync(x => x.LocationId == command.LocationId);
                    if (data != null && data.Result != null)
                    {
                        data.Result.Ubication = command.Ubication;
                        data.Result.Description = command.Description;
                        await _context.SaveChangesAsync();
                        _logger.LogInformation(command.GetType().ToString() + LogEnums.LogEnum.Ended.ToString());
                    }
                    else
                    {
                        _logger.LogError(command.GetType().ToString() + LogEnums.LogEnum.Error.ToString());
                        throw new LocationUpdatedCommandException("No se encontro Location con el  id : " + command.LocationId);
                    }

                    await trx.CommitAsync();
                }
                            
            }
            catch (Exception ex)
            {
                _logger.LogError(command.GetType().ToString() + LogEnums.LogEnum.Error.ToString());
                throw ex;
            }
        }
    }
}
