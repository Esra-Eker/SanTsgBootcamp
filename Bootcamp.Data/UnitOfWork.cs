using Bootcamp.Data.Repositories;
using Bootcamp.Data.Repositories.Interfaces;
using System;

namespace Bootcamp.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository Users { get; }
        void Complete();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BootcampDbContext _context;
        public IUserRepository Users { get; private set; }
        public UnitOfWork(BootcampDbContext context)
        {
            _context = context;
            Users = new UserRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
