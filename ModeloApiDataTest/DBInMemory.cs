
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Modelo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloApiDataTest
{
   public  class DbInMemory
    {
        private ApplicationDbContext _context;

        public DbInMemory()
        {

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

           


        }
    }
}
