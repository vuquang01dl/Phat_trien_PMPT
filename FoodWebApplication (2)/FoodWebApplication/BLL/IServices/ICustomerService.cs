using DTO.Restaurant;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Customer;

namespace BLL.IServices
{
    public interface ICustomerService
    {
        void CreateContact(CustomerContactDTO input);
        void Create(CustomerDTO input);
        void Update(CustomerDTO input, long id);
        void Delete(long id);
        CustomerDTO GetById(long id);
        PaginationModels<List<CustomerDTO>> Get(string search);
        List<CustomerDTO> GetAllCustomer();
    }
}
