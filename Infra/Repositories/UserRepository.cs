using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Infra.Context;

namespace Infra.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DataContext context) : base(context)
        { }

        public override User GetById(int id)
        {
            var query = _context.Set<User>().Where(e => e.Deleted_at == null).Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<User> GetAll()
        {
            var query = _context.Set<User>().Where(e => e.Deleted_at == null);

            return query.Any() ? query.ToList() : new List<User>();
        }
    }
}