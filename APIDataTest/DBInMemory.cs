using DataFake.ProdutoData;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Entities;
using Modelo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIDataTest
{
    public class DBInMemory 
    {
        private ApplicationDbContext _context;

        public DBInMemory()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)

                .EnableSensitiveDataLogging()
                .Options;

            _context = new ApplicationDbContext(options);

            InsertFakeData();

        }

        public ApplicationDbContext GetContext() => _context;

        private async void InsertFakeData()
        {

            if (_context.Database.EnsureCreated())
            {
                var produtos = new ProdutoFaker().Generate(20);

                foreach (var produto in produtos)
                {

                    produto.Id = 0;
                    await _context.Produtos.AddAsync(produto);
                }
                await _context.SaveChangesAsync();

            }


        }
    }

    }

