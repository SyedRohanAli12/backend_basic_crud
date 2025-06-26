using Think_Digitally_week01.Data;
using Think_Digitally_week01.Models;

namespace Think_Digitally_week01.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public Category GetByName(string name)
        {
            return _context.Set<Category>().FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
