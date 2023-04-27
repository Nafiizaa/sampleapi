using Microsoft.EntityFrameworkCore;
using SimpleApiExcercise.Repositories.DAL.Models;
using SimpleApiExcercise.Repositories.Repository;

namespace SimpleApiExcercise.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _repositoryCustomer;

        public CustomerService(IGenericRepository<Customer> repositoryCustomer)
        {
            _repositoryCustomer = repositoryCustomer;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {            
            return await _repositoryCustomer.Table.ToListAsync();
        }
    }
}
