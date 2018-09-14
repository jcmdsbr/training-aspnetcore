using ApiAngular.Infra.Repository.Context;
using ApiAngular.Infra.Repository.Contracts;
using ApiAngular.Models;

namespace ApiAngular.Infra.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApiAngularContext angularContext) : base(angularContext)
        {
        }
    }
}