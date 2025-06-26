using Think_Digitally_week01.Models;

namespace Think_Digitally_week01.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByName(string name);
    }

}
