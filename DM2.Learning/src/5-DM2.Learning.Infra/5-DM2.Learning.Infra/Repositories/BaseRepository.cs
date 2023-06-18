using _5_DM2.Learning.Infra.Context;

namespace _5_DM2.Learning.Infra.Repositories;

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
