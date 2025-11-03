using Microsoft.EntityFrameworkCore;
using ProductCollection.Data;
using ProductCollection.Model;

namespace ProductCollection.Repository
{
    public class ProductRepository : IRepository
    {
        private ProductCollectionContext _db;
        private List<Product> products;

        
        public void Create(Product product)
        {
            using (_db = new ProductCollectionContext())
            {
                _db.Products.Add(product);
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        { 
            using (_db = new ProductCollectionContext())
            {
                var entity = _db.Products.Where(p => p.ProductID == id && p.IsActive).FirstOrDefault();
                if (entity != null)
                {
                    entity.IsActive = false;
                    entity.UpdateDate = DateTime.Now;
                    _db.Products.Attach(entity);
                    _db.Entry(entity).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (_db = new ProductCollectionContext())
            {
                return _db.Products.Where(p => p.IsActive == true).ToList();
            }
        }

        public Product GetById(int id)
        {
            using (_db = new ProductCollectionContext())
            {
                return _db.Products.Where(p => p.ProductID == id && p.IsActive).FirstOrDefault();
            }
        }

        public void Update(Product product)
        {
            using (_db = new ProductCollectionContext())
            {
                var oldProduct = _db.Products.Where(p => p.ProductID == product.ProductID && p.IsActive).FirstOrDefault();
                if (oldProduct is not null)
                {
                    oldProduct.Name = product.Name;
                    oldProduct.Description = product.Description;
                    oldProduct.Price = product.Price;
                    oldProduct.UpdateDate = DateTime.Now;
                    _db.Products.Attach(oldProduct);
                    _db.Entry(oldProduct).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
        }
    }
}
