using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Infra.Context;

namespace Infra.Repositories
{
    public class GameRepository : Repository<Game>
    {
        public GameRepository(DataContext context) : base(context)
        { }

        public override Game GetById(int id)
        {
            var query = _context.Set<Game>().Where(e => e.Deleted_at == null).Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Game> GetAll()
        {
            var query = _context.Set<Game>().Where(e => e.Deleted_at == null);

            return query.Any() ? query.ToList() : new List<Game>();
        }
    }
}