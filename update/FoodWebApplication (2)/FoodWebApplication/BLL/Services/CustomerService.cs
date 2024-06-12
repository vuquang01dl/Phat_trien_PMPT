using BLL.IServices;
using DTO.User;
using DTO;
using Entities.User;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Customer;
using Entities.Customer;

namespace BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CoreContext _dbContext;

        public CustomerService(CoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CustomerDTO> GetAllCustomer()
        {
            var subjects = _dbContext.Customer.AsQueryable().Where(w => !w.IsDelete);
            return subjects.Select(s => new CustomerDTO()
            {
                Id = s.Id,
                UserName = s.UserName,
                Password = s.Password,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Phone = s.Phone,
                Email = s.Email,
                Address = s.Address,
                Gender = s.Gender,
                Avartar = s.Avartar,
                DateOfBirth = s.DateOfBirth,
            }).ToList();
        }
        public void Create(CustomerDTO input)
        {
            if (_dbContext.Customer.FirstOrDefault(u => u.Email == input.Email) != null)
            {
                throw new Exception($"Email khách hàng \"{input.Id}\"đã tồn tại");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var User = new CustomerEntities()
                    {
                        Id = input.Id,
                        UserName = input.UserName,
                        Password = input.Password,
                        FirstName = input.FirstName,
                        LastName = input.LastName,
                        Address = input.Address,
                        Phone = input.Phone,
                        Email = input.Email,
                        Gender = input.Gender,
                        Avartar = input.Avartar,
                        DateOfBirth = input.DateOfBirth,
                    };
                    _dbContext.Customer.Add(User);
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
                    throw new Exception($"Tạo khách hàng \"{input.Id}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }
        }
        public void CreateContact(CustomerContactDTO input)
        {           
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var User = new CustomerContactEntities()
                    {
                        Name = input.Name,
                        Email = input.Email,
                        Phone = input.Phone,
                        Title = input.Title,
                        Content = input.Content
                    };
                    _dbContext.CustomerContact.Add(User);
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
                    throw new Exception($"Tạo liên hệ \"{input.Name}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }
        }
        public void Delete(long id)
        {
            var User = _dbContext.Customer.FirstOrDefault(x => x.Id == id);
            if (User == null)
            {
                throw new Exception("Không tìm thấy khách hàng");
            }
            _dbContext.Customer.Remove(User);
            _dbContext.SaveChanges();
        }

        public PaginationModels<List<CustomerDTO>> Get(string search)
        {
            var Users = _dbContext.Customer.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                Users = Users.Where(w => w.UserName.ToLower().Contains(search.Trim().ToLower()));
            }

            return new PaginationModels<List<CustomerDTO>>
            {
                TotalItem = Users.Count(),
                Items = Users.Select(s => new CustomerDTO()
                {
                    Id = s.Id,
                    UserName = s.UserName,
                    Password = s.Password,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Phone = s.Phone,
                    Email = s.Email,
                    Address = s.Address,
                    Gender = s.Gender,
                    Avartar = s.Avartar,
                    DateOfBirth = s.DateOfBirth,
                }).ToList()
            };
        }

        public CustomerDTO GetById(long id)
        {
            var User = _dbContext.Customer.FirstOrDefault(x => x.Id == id);
            if (User == null)
            {
                throw new Exception("Không tìm thấy khách hàng");
            }
            var result = new CustomerDTO()
            {
                Id = User.Id,
                UserName = User.UserName,
                Password = User.Password,
                FirstName = User.FirstName,
                LastName = User.LastName,
                Address = User.Address,
                Phone = User.Phone,
                Email = User.Email,
                Gender = User.Gender,
                Avartar = User.Avartar,
                DateOfBirth = User.DateOfBirth,
            };
            return result;
        }

        public void Update(CustomerDTO input, long id)
        {
            var User = _dbContext.Customer.FirstOrDefault(x => x.Id == id);
            if (User == null)
            {
                throw new Exception("Không tìm thấy khách hàng");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    User.UserName = input.UserName;
                    User.Phone = input.Phone;
                    User.Email = input.Email;
                    User.DateOfBirth = input.DateOfBirth;
                    User.Password = input.Password;
                    User.Address = input.Address;
                    User.FirstName = input.FirstName;
                    User.LastName = input.LastName;
                    User.Gender = input.Gender;
                    User.Avartar = input.Avartar;
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
                    throw new Exception($"Tạo khách hàng \"{input.Id}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }

        }        
    }
}
