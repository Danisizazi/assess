using ProductCollection.Model;

namespace ProductCollection.Repository
{
    public interface IRepository
    {
        public void Create(Product product);
        public void Update(Product product);
        public IEnumerable<Product> GetAll();
        public Product GetById(int id);
        public void Delete(int id);
    }
}
