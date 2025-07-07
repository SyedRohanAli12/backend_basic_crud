using Microsoft.EntityFrameworkCore;
using Think_Digitally_week01.Data;
using Think_Digitally_week01.Models;
using Think_Digitally_week01.Repositories;

namespace Think_Digitally_week01.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly AppDbContext _context;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, AppDbContext context)
        {
            _productRepository = productRepository;
            _context = context;
            _categoryRepository = categoryRepository;
        }

        public string AddProduct(Product product)
        //{
        //    if (product.Category != null)
        //    {
        //        var existingCategory = _categoryRepository.GetByName(product.Category.Name);
        //    if (existingCategory != null)
        //    {
        //        // Use existing category Id
        //        product.CategoryId = existingCategory.Id;
        //        product.Category = null;  // prevent EF from trying to insert again
        //    }
        //    else
        //    {
        //            // Add new category first
        //            _categoryRepository.Add(product.Category);
        //        product.CategoryId = product.Category.Id;
        //        product.Category = null;
        //    }
        //}
        //    _productRepository.Add(product);
        //    return $"Product ({product.ProductName}) successfully added!";
        //}

        {
            // Check if category exists by Id
            var existingCategory = _categoryRepository.GetById(product.CategoryId);

            if (existingCategory == null || existingCategory.IsDeleted)
            {
                throw new Exception("Category does not exist or has been deleted.");
            }

            product.Category = null; // Avoid EF tracking issues
            _productRepository.Add(product);
            return $"Product ({product.ProductName}) successfully added!";
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public string UpdateProduct(Product product)
        {
            return _productRepository.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            _productRepository.Delete(product);
        }


        public object GetFilteredProducts(string? search, int page, int pageSize, string? sortBy, bool ascending)
        {
            var query = _productRepository
                .GetAll()
                .Where(p => !p.IsDeleted)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p =>
                    p.ProductName.ToLower().Contains(search.ToLower()));
            }

            // Sorting logic
            query = sortBy?.ToLower() switch
            {
                "price" => ascending ? query.OrderBy(p => p.ProductPrice) : query.OrderByDescending(p => p.ProductPrice),
                "category" => ascending ? query.OrderBy(p => p.CategoryId) : query.OrderByDescending(p => p.CategoryId),
                _ => query.OrderBy(p => p.Id)
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
