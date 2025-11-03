using CustomerApp.Model;

namespace CustomerApp.Repository
{
    public interface IRepository
    {
        public void Create(Customer customer);
        public void Update(Customer customer);
        public IEnumerable<Customer> GetAll();
        public Customer GetById(int id);
        public void Delete(int id);
    }
}
