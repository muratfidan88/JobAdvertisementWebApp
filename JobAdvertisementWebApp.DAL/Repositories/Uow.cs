using JobAdvertisementWebApp.DAL.Data.Contexts;
using JobAdvertisementWebApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.DAL.Repositories
{
    public class Uow : IUow
    {
        private readonly JobAdvertisementContext _context;

        public Uow(JobAdvertisementContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T: class, new()
        {
            return new Repository<T>(_context);
        }
        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
