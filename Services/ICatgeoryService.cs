using Think_Digitally_week01.Models;

namespace Think_Digitally_week01.Services
{
    public interface ICategoryService
    {

        object GetFilteredCategories(string? search, int page, int pageSize,string? sortBy, bool ascending);

        string AddCategory(Category category);
        List<Category> GetAllCategories();
        Category GetByName(string name);
        Category GetById(int id);
    }
}
