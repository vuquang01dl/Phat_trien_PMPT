using BLL.IServices;
using DTO.User;
using Entities.User;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Common.Enum;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly CoreContext _dbContext;

        public UserService(CoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<UserDTO> GetAllUser()
        {
            var subjects = _dbContext.Users.AsQueryable().Where(w => !w.IsDelete && !w.IsSupper);
            return subjects.Select(s => new UserDTO()
            {
                Id = s.Id,
                FullName = s.FullName,
                UserName = s.UserName,
                Phone = s.Phone,
                Email = s.Email,
                BirthDay = s.BirthDay,
                Password = s.Password,
                Address = s.Address,
                Role = s.Role,
            }).ToList();
        }
        public void Create(UserDTO input)
        {
            if (_dbContext.Users.FirstOrDefault(u => u.Email == input.Email) != null)
            {
                throw new Exception($"Email người dùng \"{input.Id}\"đã tồn tại");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var User = new UserEntities()
                    {
                        Id = input.Id,
                        FullName = input.FullName,
                        UserName = input.UserName,
                        Phone = input.Phone,
                        Email = input.Email,
                        BirthDay = input.BirthDay,
                        Password = input.Password,
                        Address = input.Address,
                        Role = input.Role,
                    };
                    _dbContext.Users.Add(User);
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
                    throw new Exception($"Tạo người dùng \"{input.Id}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }
        }

        public void Delete(long id)
        {
            var User = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (User == null)
            {
                throw new Exception("Không tìm thấy người dùng");
            }
            _dbContext.Users.Remove(User);
            _dbContext.SaveChanges();
        }

        public PaginationModels<List<UserDTO>> Get(string search)
        {
            var Users = _dbContext.Users.AsQueryable().Where(w => !w.IsSupper);
            if (!string.IsNullOrWhiteSpace(search))
            {
                Users = Users.Where(w => w.FullName.ToLower().Contains(search.Trim().ToLower()));
            }

            return new PaginationModels<List<UserDTO>>
            {
                TotalItem = Users.Count(),
                Items = Users.Select(s => new UserDTO()
                {
                    Id = s.Id,
                    FullName = s.FullName,
                    UserName = s.UserName,
                    Phone = s.Phone,
                    Email = s.Email,
                    BirthDay = s.BirthDay,
                    Password = s.Password,
                    Address = s.Address,
                    Role = s.Role,
                }).ToList()
            };
        }

        public UserDTO GetById(long id)
        {
            var User = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (User == null)
            {
                throw new Exception("Không tìm thấy người dùng");
            }
            var result = new UserDTO()
            {
                Id = User.Id,
                FullName = User.FullName,
                UserName = User.UserName,
                Phone = User.Phone,
                Email = User.Email,
                BirthDay = User.BirthDay,
                Password = User.Password,
                Address = User.Address
            };
            return result;
        }

        public void Update(UserDTO input, long id)
        {
            var User = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (User == null)
            {
                throw new Exception("Không tìm thấy người dùng");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    User.FullName = input.FullName;
                    User.UserName = input.UserName;
                    User.Phone = input.Phone;
                    User.Email = input.Email;
                    User.BirthDay = input.BirthDay;
                    User.Password = input.Password;
                    User.Address = input.Address;
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
                    throw new Exception($"Tạo người dùng \"{input.Id}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }

        }
        public UserDTO Login(string username, string pass)
        {
            var user = _dbContext.Users.AsQueryable().Where(w => (w.UserName.ToLower() == username.Trim().ToLower() || w.Email.ToLower() == username.Trim().ToLower()) && w.Password == pass)
                .Select(s => new UserDTO()
                {
                    Id = s.Id,
                    UserName = s.UserName,
                    Phone = s.Phone,
                    Email = s.Email,
                    BirthDay = s.BirthDay,
                    Password = s.Password,
                    Address = s.Address,
                    Role = s.Role,
                    Type = 1
                }).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                var cuss = _dbContext.Customer.AsQueryable().Where(w => (w.UserName.ToLower() == username.Trim().ToLower() || w.Email.ToLower() == username.Trim().ToLower()) && w.Password == pass)
                .Select(s => new UserDTO()
                {
                    Id = s.Id,
                    UserName = s.UserName,
                    Phone = s.Phone,
                    Email = s.Email,
                    Password = s.Password,
                    Address = s.Address,
                    Type = 2
                }).FirstOrDefault();
                if (cuss != null) { return cuss; }
            }
            return null;
        }
    }
}
