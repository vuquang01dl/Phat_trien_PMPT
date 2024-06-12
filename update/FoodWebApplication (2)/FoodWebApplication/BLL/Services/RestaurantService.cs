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
using DTO.Restaurant;
using Entities.Restaurant;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BLL.Services
{
    public class RestaurantService  : IRestaurantService
    {
        private readonly CoreContext _dbContext;

        public RestaurantService(CoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public RestaurantDTO GetDetail(long id)
        {
            var Entity = _dbContext.Restaurant.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy nhà hàng");
            }
            var category = _dbContext.Categories.AsQueryable();
            var result = new RestaurantDTO()
            {
                Id = Entity.Id,
                Name = Entity.Name,
                CategoryId = Entity.CategoryId,
                ImageURL = Entity.ImageURL,
                CategoryName = category.FirstOrDefault(f => f.Id == Entity.CategoryId).Name,
            };
            var restaurants = _dbContext.Restaurant.AsQueryable();
            result.Foods = _dbContext.Foods.Where(x => x.RestaurantId == result.Id).Select(z => new DTO.Food.FoodDTO()
            {
                Id = z.Id,
                Code = z.Code,
                Name = z.Name,
                Price = z.Price,
                ImageURL = z.ImageURL,
                RestaurantId = z.RestaurantId,
                RestaurantName = restaurants.FirstOrDefault(f => f.Id == z.RestaurantId).Name
            }).ToList();
            var modifiers = _dbContext.Modifiers.AsQueryable();
            if (result.Foods != null && result.Foods.Any())
            {
                result.Foods.ForEach(f =>
                {
                    f.Modifiers = modifiers.Where(w => w.FoodId == f.Id).Select(z => new DTO.Modifier.ModifierDTO
                    {
                        Code = z.Code,
                        Name = z.Name,
                        Price = z.Price,
                        ImageURL = z.ImageURL
                    }).ToList();
                });
            }
            return result;
        }

        public List<RestaurantDTO> getByCate(long id)
        {
            var category = _dbContext.Categories.AsQueryable();
            var restaurants = _dbContext.Restaurant.AsQueryable().Where(w => !w.IsDelete);
            if (id > 0)
            {
                restaurants = restaurants.Where(w => w.CategoryId == id);
            }
            return restaurants.Select(s => new RestaurantDTO()
            {
                Id = s.Id,
                Name = s.Name,
                CategoryId = s.CategoryId,
                CategoryName = category.FirstOrDefault(f => f.Id == s.CategoryId).Name,
                ImageURL = s.ImageURL,
            }).ToList();
        }
        public List<RestaurantDTO> GetAllRestaurant()
        {
            var category = _dbContext.Categories.AsQueryable();
            var subjects = _dbContext.Restaurant.AsQueryable().Where(w => !w.IsDelete);
            return subjects.Select(s => new RestaurantDTO()
            {
                Id = s.Id,
                Name = s.Name,
                CategoryId = s.CategoryId,
                CategoryName = category.FirstOrDefault(f => f.Id == s.CategoryId).Name,
                ImageURL = s.ImageURL,
            }).ToList();
        }
        public void Create(RestaurantDTO input)
        {
            if (_dbContext.Restaurant.FirstOrDefault(u => u.Id == input.Id) != null)
            {
                throw new Exception($"Mã nhà hàng \"{input.Id}\"đã tồn tại");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var Entity = new RestaurantEntities()
                    {
                        Id = input.Id,
                        Name = input.Name,
                        CategoryId = input.CategoryId,
                        ImageURL = input.ImageURL,
                    };
                    _dbContext.Restaurant.Add(Entity);
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
                    throw new Exception($"Tạo nhà hàng \"{input.Id}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }
        }

        public void Delete(long id)
        {
            var Entity = _dbContext.Restaurant.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy nhà hàng");
            }
            _dbContext.Restaurant.Remove(Entity);
            _dbContext.SaveChanges();
        }

        public PaginationModels<List<RestaurantDTO>> Get(string search)
        {
            var Entity = _dbContext.Restaurant.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                Entity = Entity.Where(w => w.Name.ToLower().Contains(search.Trim().ToLower()));
            }

            var category = _dbContext.Categories.AsQueryable();
            return new PaginationModels<List<RestaurantDTO>>
            {
                TotalItem = Entity.Count(),
                Items = Entity.Select(s => new RestaurantDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    CategoryId = s.CategoryId,
                    ImageURL = s.ImageURL,
                    CategoryName = category.FirstOrDefault(f => f.Id == s.CategoryId).Name,
                }).ToList()
            };
        }

        public RestaurantDTO GetById(long id)
        {
            var Entity = _dbContext.Restaurant.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy nhà hàng");
            }
            var category = _dbContext.Categories.AsQueryable();
            var result = new RestaurantDTO()
            {
                Id = Entity.Id,
                Name = Entity.Name,
                CategoryId = Entity.CategoryId,
                ImageURL = Entity.ImageURL,
                CategoryName = category.FirstOrDefault(f => f.Id == Entity.CategoryId).Name,
            };
            return result;
        }

        public void Update(RestaurantDTO input, long id)
        {
            var Entity = _dbContext.Restaurant.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy nhà hàng");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Entity.Name = input.Name;
                    Entity.CategoryId = input.CategoryId;
                    Entity.ImageURL = input.ImageURL;
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
                    throw new Exception($"Tạo nhà hàng \"{input.Id}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }

        }
    }
}
