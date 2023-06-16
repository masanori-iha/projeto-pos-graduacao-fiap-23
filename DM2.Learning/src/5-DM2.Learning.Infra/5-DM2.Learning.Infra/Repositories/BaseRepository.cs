using _5_DM2.Learning.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_DM2.Learning.Infra.Repositories
{
    public abstract class BaseRepository
    {
        public readonly DM2Context _context;
        public BaseRepository(DM2Context dM2Context)
        {
            _context = dM2Context;
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
