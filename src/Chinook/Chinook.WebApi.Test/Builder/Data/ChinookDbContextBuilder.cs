using Chinook.Repository.Postgresql;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chinook.WebApi.Test.Builder.Data
{
    public partial class ChinookDbContextBuilder : IDisposable
    {
        private ChinookDbContext _context;
        public ChinookDbContextBuilder ConfigureInMemory()
        {
            var options = new DbContextOptionsBuilder<ChinookDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            _context = new ChinookDbContext(options);
            return this;
        }

        public ChinookDbContext Build()
        {
            return _context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
