using UnderTheBrand.Domain.Core.Interfaces;
using UnderTheBrand.Infrastructure.Dal.Context;

namespace UnderTheBrand.Infrastructure.Dal.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UnderTheBrandContext _context;

        public UnitOfWork(UnderTheBrandContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
