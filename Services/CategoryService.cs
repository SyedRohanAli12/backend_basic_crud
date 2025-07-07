using Think_Digitally_week01.Data;
using Think_Digitally_week01.Models;
using Think_Digitally_week01.Repositories;

namespace Think_Digitally_week01.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly AppDbContext _context;
        public CategoryService(ICategoryRepository categoryRepository , AppDbContext context)
        {
            _categoryRepository = categoryRepository;
            _context = context;
        }

        public string AddCategory(Category category)
        {
            var existing = _categoryRepository.GetByName(category.Name);
            if (existing != null && !existing.IsDeleted)
            {
                return $"Category '{category.Name}' already exists.";
            }

            _categoryRepository.Add(category);
            return $"Category '{category.Name}' added successfully.";
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll().Where(c => !c.IsDeleted).ToList();
        }

        public Category GetByName(string name)
        {
            return _categoryRepository.GetByName(name);
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }


        public object GetFilteredCategories(string? search, int page, int pageSize, string? sortBy, bool ascending)
        {
            var query = _categoryRepository
                .GetAll()
                .Where(c => !c.IsDeleted)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c =>
                    c.Name.ToLower().Contains(search.ToLower()));
            }

            // Sorting logic
            query = sortBy?.ToLower() switch
            {
                "name" => ascending ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                _ => query.OrderBy(c => c.Id)
            };

            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            if (page > totalPages && totalPages > 0)
            {
                page = totalPages;
            }

            var items = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new
            {
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                Items = items
            };
        }

    }
}
