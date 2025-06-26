using Think_Digitally_week01.Data;
using Think_Digitally_week01.Models;

namespace Think_Digitally_week01.Repositories
{
    //public class ProductRepository : IRepository<Product>
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        //private static List<Product> _products = new List<Product>();
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            //_appDbContext = appDbContext;
        }

        //public void Add(Product entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(Product entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Product> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public string Update(Product entity)
        //{
        //    throw new NotImplementedException();
        //}
        //public void AddProduct(Product product)
        //{
        //    _appDbContext.Products.Add(product);
        //    _appDbContext.SaveChanges();
        //    //_products.Add(product);
        //}

        //public string UpdateProduct(Product product)
        //{

        //    //var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
        //    var existingProduct = _appDbContext.Products.FirstOrDefault(p => p.Id == product.Id);
        //    if (existingProduct == null)
        //    {
        //        return $"Product with ID {product.Id} not found";
        //    }
        //    existingProduct.ProductPrice = product.ProductPrice;
        //    existingProduct.ProductName = product.ProductName;
        //    // line to change everytime we do to the Database
        //    _appDbContext.SaveChanges();
        //    return $"Product with the ID {product.Id} has been updated succesfully.";
        //}

        //public void DeleteProduct(Product product)
        //{
        //    //var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
        //    var existingProduct = _appDbContext.Products.FirstOrDefault(p => p.Id == product.Id);
        //    if (existingProduct != null)
        //    {
        //        //_products.Remove(existingProduct);
        //        _appDbContext.Products.Remove(existingProduct);
        //        _appDbContext.SaveChanges();
        //    }
        //}
        //public List<Product> GetAllProducts()
        //{
        //    //return _products;
        //    return _appDbContext.Products.ToList();
        //}
    }
}
