using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Order;
using DTO.Revenue;

namespace BLL.IServices
{
    public interface IOrderService
    {
        OrderDTO Create(OrderDTO input);
        void Update(OrderDTO input, long id);
        void Delete(long id);
        OrderDTO GetById(long id);
        PaginationModels<List<OrderDTO>> Get(string search);
        PaginationModels<List<OrderDTO>> GetByEmail(string email);
        List<OrderDTO> GetAllOrder();
        RevenueAnual GetRevenueAnual(int year);
    }
}
