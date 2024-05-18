using BLL.IServices;
using DTO.Category;
using DTO;
using Entities.Category;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Order;
using Entities.Order;
using DTO.Revenue;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly CoreContext _dbContext;

        public OrderService(CoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public RevenueAnual GetRevenueAnual(int year)
        {
            var model = new RevenueAnual();
            model.Year = year;
            var dataOrder = _dbContext.Orders.Where(w=>w.CreatedAt.Year == year).ToList();
            if (dataOrder != null)
            {
                var totalPrice = dataOrder.Where(w => w.CreatedAt.Month == 1).Sum(s => s.Price);
                model.Month1 = 1;
                model.Month1Value = Convert.ToDouble(totalPrice);

                totalPrice = dataOrder.Where(w => w.CreatedAt.Month == 2).Sum(s => s.Price);
                model.Month2 = 2;
                model.Month2Value = Convert.ToDouble(totalPrice);

                totalPrice = dataOrder.Where(w => w.CreatedAt.Month == 3).Sum(s => s.Price);
                model.Month3 = 3;
                model.Month3Value = Convert.ToDouble(totalPrice);

                totalPrice = dataOrder.Where(w => w.CreatedAt.Month == 4).Sum(s => s.Price);
                model.Month4 = 4;
                model.Month4Value = Convert.ToDouble(totalPrice);

                totalPrice = dataOrder.Where(w => w.CreatedAt.Month == 5).Sum(s => s.Price);
                model.Month5 = 5;
                model.Month5Value = Convert.ToDouble(totalPrice);

                totalPrice = dataOrder.Where(w => w.CreatedAt.Month == 6).Sum(s => s.Price);
                model.Month6 = 6;
                model.Month6Value = Convert.ToDouble(totalPrice);

                totalPrice = dataOrder.Where(w => w.CreatedAt.Month == 7).Sum(s => s.Price);
                model.Month7 = 7;
                model.Month7Value = Convert.ToDouble(totalPrice);

                totalPrice = dataOrder.Where(w => w.CreatedAt.Month == 8).Sum(s => s.Price);
                model.Month8 = 8;
                model.Month8Value = Convert.ToDouble(totalPrice);

                totalPrice = dataOrder.Where(w => w.CreatedAt.Month == 9).Sum(s => s.Price);
                model.Month9 = 9;
                model.Month9Value = Convert.ToDouble(totalPrice);

                totalPrice = dataOrder.Where(w => w.CreatedAt.Month == 10).Sum(s => s.Price);
                model.Month10 = 10;
                model.Month10Value = Convert.ToDouble(totalPrice);

                totalPrice = dataOrder.Where(w => w.CreatedAt.Month == 11).Sum(s => s.Price);
                model.Month11 = 11;
                model.Month11Value = Convert.ToDouble(totalPrice);

                totalPrice = dataOrder.Where(w => w.CreatedAt.Month == 12).Sum(s => s.Price);
                model.Month12 = 12;
                model.Month12Value = Convert.ToDouble(totalPrice);
            }
            return model;
        }
        public List<OrderDTO> GetAllOrder()
        {
            var subjects = _dbContext.Orders.AsQueryable().Where(w => !w.IsDelete);
            return subjects.Select(s => new OrderDTO()
            {
                Id = s.Id,
                Price = s.Price,
                Qty = s.Qty,
                CustomerName= s.CustomerName,
                Phone= s.Phone,
                Address= s.Address,
                Email= s.Email,
                Status= s.Status,
                Code= s.Code,
                Description= s.Description,
                CreatedAt= s.CreatedAt,
            }).ToList();
        }
        public OrderDTO Create(OrderDTO input)
        {
            if (_dbContext.Orders.FirstOrDefault(u => u.Id == input.Id) != null)
            {
                throw new Exception($"Mã đơn hàng \"{input.Id}\"đã tồn tại");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var Entity = new OrderEntities()
                    {
                        Id = input.Id,
                        Price = input.Price,
                        Qty = input.Qty,
                        CustomerName = input.CustomerName,
                        Phone = input.Phone,
                        Address = input.Address,
                        Email = input.Email,
                        Status = input.Status,
                        Code = RandomString(8),
                        Description = input.Description,
                        CreatedAt= DateTime.Now
                    };
                    _dbContext.Orders.Add(Entity);
                    var Result = _dbContext.SaveChanges() > 0;
                    if (Result)
                    {
                        input.Id = Entity.Id;
                        _dbContext.SaveChanges();
                        trans.Commit();
                    }
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw new Exception($"Tạo đơn hàng \"{input.Id}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }
            return input;
        }
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void Delete(long id)
        {
            var Entity = _dbContext.Orders.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy đơn hàng");
            }
            _dbContext.Orders.Remove(Entity);
            _dbContext.SaveChanges();
        }

        public PaginationModels<List<OrderDTO>> Get(string search)
        {
            var Entity = _dbContext.Orders.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                Entity = Entity.Where(w => w.CustomerName.ToLower().Contains(search.Trim().ToLower()));
            }

            return new PaginationModels<List<OrderDTO>>
            {
                TotalItem = Entity.Count(),
                Items = Entity.Select(s => new OrderDTO()
                {
                    Id = s.Id,
                    Price = s.Price,
                    Qty = s.Qty,
                    CustomerName = s.CustomerName,
                    Phone = s.Phone,
                    Address = s.Address,
                    Email = s.Email,
                    Status = s.Status,
                    Code = s.Code,
                    Description = s.Description,
                    CreatedAt= s.CreatedAt,
                }).OrderByDescending(o=>o.CreatedAt).ToList()
            };
        }

        public PaginationModels<List<OrderDTO>> GetByEmail(string email)
        {
            var Entity = _dbContext.Orders.AsQueryable();
            if (!string.IsNullOrWhiteSpace(email))
            {
                Entity = Entity.Where(w => w.Email.ToLower() == email.Trim().ToLower());
            }

            return new PaginationModels<List<OrderDTO>>
            {
                TotalItem = Entity.Count(),
                Items = Entity.Select(s => new OrderDTO()
                {
                    Id = s.Id,
                    Price = s.Price,
                    Qty = s.Qty,
                    CustomerName = s.CustomerName,
                    Phone = s.Phone,
                    Address = s.Address,
                    Email = s.Email,
                    Status = s.Status,
                    Code = s.Code,
                    Description = s.Description,
                    CreatedAt = s.CreatedAt,
                }).OrderByDescending(o => o.CreatedAt).ToList()
            };
        }
        public OrderDTO GetById(long id)
        {
            var Entity = _dbContext.Orders.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy đơn hàng");
            }
            var result = new OrderDTO()
            {
                Id = Entity.Id,
                Price = Entity.Price,
                Qty = Entity.Qty,
                CustomerName = Entity.CustomerName,
                Phone = Entity.Phone,
                Address = Entity.Address,
                Email = Entity.Email,
                Status = Entity.Status,
                Code = Entity.Code,
                Description = Entity.Description
            };
            return result;
        }

        public void Update(OrderDTO input, long id)
        {
            var Entity = _dbContext.Orders.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy thể loại");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Entity.Price = input.Price;
                    Entity.Qty = input.Qty;
                    Entity.CustomerName = input.CustomerName;
                    Entity.Phone = input.Phone;
                    Entity.Address = input.Address;
                    Entity.Email = input.Email;
                    Entity.Status = input.Status;
                    Entity.Code = input.Code;
                    Entity.Description = input.Description;
                    var Result = _dbContext.SaveChanges() > 0;
                    if (Result)
                    {
                        _dbContext.SaveChanges();
                        trans.Commit();
                    }
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw new Exception($"Tạo đơn hàng \"{input.Id}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }

        }
    }
}
