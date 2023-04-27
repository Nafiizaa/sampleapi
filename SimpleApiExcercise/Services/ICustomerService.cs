using SimpleApiExcercise.Repositories.DAL.Models;

namespace SimpleApiExcercise.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();
    }
}
