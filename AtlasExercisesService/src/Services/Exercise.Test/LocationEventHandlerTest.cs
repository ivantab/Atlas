using Exercise.Services.EventHandler.Handlers;
using Exercise.Services.EventHandler.Commands;
using Exercise.Services.EventHandler.Exceptions;
using Exercise.Test.Config;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading;

namespace Exercise.Test
{
    [TestClass]
    public class LocationEventHandlerTest
    {
        private ILogger<LocationEventHandler> GetLogger
        {
            get
            {
                return new Mock<ILogger<LocationEventHandler>>().Object;
            }
        }

        [TestMethod]
        public void TryToCreateLocation()
        {
            var contex = ApplicationDbContextInMemory.Get();
            var handler = new LocationEventHandler(contex, this.GetLogger);
            LocationCreateCommand locationCreateCommand = new LocationCreateCommand(){  Description ="test", Ubication = "test" };
            handler.Handle(locationCreateCommand,new CancellationToken()).Wait();
        }


        [TestMethod]
        [ExpectedException(typeof(LocationUpdatedCommandException))]
        public void TryToUpdateWhenHasntLocationId()
        {

            var contex = ApplicationDbContextInMemory.Get();
            var handler = new LocationEventHandler(contex, this.GetLogger);
            try
            {
                LocationUpdatedCommand locationUpdateCommand = new LocationUpdatedCommand() { LocationId = 2002, Description = "test", Ubication = "test" };
                handler.Handle(locationUpdateCommand, new CancellationToken()).Wait();
            }
            //AggregateException es devuelta en los metodoss asincronos por eso debemos capturarla y reenviar la nuestra
            catch (AggregateException ae)
            {
                var exception = ae.GetBaseException();
                if(exception is LocationUpdatedCommandException)
                {
                    throw new LocationUpdatedCommandException(exception?.InnerException?.Message);
                }
            }
            
        }
    }
}
