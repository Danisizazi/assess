using Microsoft.EntityFrameworkCore;
using CustomerApp.Data;
using CustomerApp.Model;

namespace CustomerApp.Repository
{
    public class CustomerRepository : IRepository
    {
        private CustomerContext _db;
             
        public void Create(Customer customer)
        {
            using (_db = new CustomerContext())
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        { 
            using (_db = new CustomerContext())
            {
                var entity = _db.Customers.Where(p => p.CustomerID == id && p.IsActive).FirstOrDefault();
                if (entity != null)
                {
                    entity.IsActive = false;
                    entity.UpdateDate = DateTime.Now;
                    _db.Customers.Attach(entity);
                    _db.Entry(entity).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using (_db = new CustomerContext())
            {
                return _db.Customers.Where(p => p.IsActive == true).ToList();
            }
        }

        public Customer GetById(int id)
        {
            using (_db = new CustomerContext())
            {
                return _db.Customers.Where(p => p.CustomerID == id && p.IsActive).FirstOrDefault();
            }
        }

        public void Update(Customer customer)
        {
            using (_db = new CustomerContext())
            {
                var oldCustomer = _db.Customers.Where(p => p.CustomerID == customer.CustomerID && p.IsActive).FirstOrDefault();
                if (oldCustomer is not null)
                {
                    oldCustomer.Name = customer.Name;
                    oldCustomer.Email = customer.Email;
                    oldCustomer.PhoneNumber = customer.PhoneNumber;
                    oldCustomer.UpdateDate = DateTime.Now;
                    _db.Customers.Attach(oldCustomer);
                    _db.Entry(oldCustomer).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
        }
    }
}
