
using ProductCollection.Model;
using ProductCollection.Repository;

namespace ProductCollection.Services
{
    public class ProductService
    {
        private ProductRepository _repository;

        public ProductService()
        {
            _repository = new ProductRepository();
        }
        internal void CreateProduct(Product product)
        {
            _repository.Create(product);
        }

        internal void Delete(int id)
        {
            _repository.Delete(id);
        }

        internal IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }

        internal Product GetById(int id)
        {
           return _repository.GetById(id);
        }

        internal void UpdateProduct(Product product)
        {
            _repository.Update(product);
        }
    }
}
