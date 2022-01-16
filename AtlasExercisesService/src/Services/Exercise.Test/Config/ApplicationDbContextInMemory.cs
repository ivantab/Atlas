using System;
using System.Collections.Generic;
using System.Text;
using Exercise.DataAccess.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Exercise.Test.Config
{
    public static class ApplicationDbContextInMemory
    {
        public static AtlasExercisesContext Get()
        {
            var option = new DbContextOptionsBuilder<AtlasExercisesContext>().UseInMemoryDatabase(databaseName: $"Exercise.Db").Options;

            return new AtlasExercisesContext(option);
        }
    }
}
