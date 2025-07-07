using Think_Digitally_week01.Models;

namespace Think_Digitally_week01.Services
{
    public interface IProductService
    {
        object GetFilteredProducts(string? search, int page, int pageSize, string? sortBy, bool ascending);

        string AddProduct(Product product);
        List<Product> GetAllProducts();
        string UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
