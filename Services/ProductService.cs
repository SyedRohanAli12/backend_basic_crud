using Think_Digitally_week01.Models;
using Think_Digitally_week01.Repositories;

namespace Think_Digitally_week01.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public string AddProduct(Product product)
        {
            if (product.Category != null)
            {
                var existingCategory = _categoryRepository.GetByName(product.Category.Name);
            if (existingCategory != null)
            {
                // Use existing category Id
                product.CategoryId = existingCategory.Id;
                product.Category = null;  // prevent EF from trying to insert again
            }
            else
            {
                    // Add new category first
                    _categoryRepository.Add(product.Category);
                product.CategoryId = product.Category.Id;
                product.Category = null;
            }
        }
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
    }
}
