
using CustomerApp.Model;
using CustomerApp.Repository;

namespace CustomerApp.Services
{
    public class CustomerService
    {
        private CustomerRepository _repository;

        public CustomerService()
        {
            _repository = new CustomerRepository();
        }
        internal void CreateCustomer(Customer customer)
        {
            _repository.Create(customer);
        }

        internal void Delete(int id)
        {
            _repository.Delete(id);
        }

        internal IEnumerable<Customer> GetAllCustomers()
        {
            return _repository.GetAll();
        }

        internal Customer GetById(int id)
        {
           return _repository.GetById(id);
        }

        internal void UpdateCustomer(Customer customer)
        {
            _repository.Update(customer);
        }
    }
}
