using Presentation.Data.Entities;

namespace Presentation.Data.Repositories;

public class BoilerplateRepository(DataContext context): BaseRepository<BoilerplateEntity>(context), IBoilerplateRepository
{
}
