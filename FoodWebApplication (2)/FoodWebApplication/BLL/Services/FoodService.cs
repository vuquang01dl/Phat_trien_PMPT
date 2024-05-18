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
using DTO.Food;
using Entities.Food;

namespace BLL.Services
{
    public class FoodService : IFoodService
    {
        private readonly CoreContext _dbContext;

        public FoodService(CoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<FoodDTO> GetAllFood()
        {
            var restaurants = _dbContext.Restaurant.AsQueryable().Where(w => !w.IsDelete);
            var subjects = _dbContext.Foods.AsQueryable().Where(w => !w.IsDelete);
            return subjects.Select(s => new FoodDTO()
            {
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Price = s.Price,
                RestaurantId = s.RestaurantId,
                ImageURL = s.ImageURL,
                RestaurantName = restaurants.FirstOrDefault(f => f.Id == s.RestaurantId).Name
            }).ToList();
        }
        public void Create(FoodDTO input)
        {
            if (_dbContext.Foods.FirstOrDefault(u => u.Id == input.Id) != null)
            {
                throw new Exception($"Mã món ăn \"{input.Id}\"đã tồn tại");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var Entity = new FoodEntities()
                    {
                        Id = input.Id,
                        Code = input.Code,
                        Name = input.Name,
                        Price = input.Price,
                        RestaurantId = input.RestaurantId,
                        ImageURL = input.ImageURL,
                    };
                    _dbContext.Foods.Add(Entity);
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
                    throw new Exception($"Tạo món ăn \"{input.Id}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }
        }

        public void Delete(long id)
        {
            var Entity = _dbContext.Foods.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy món ăn");
            }
            _dbContext.Foods.Remove(Entity);
            _dbContext.SaveChanges();
        }

        public PaginationModels<List<FoodDTO>> Get(string search)
        {
            var restaurants = _dbContext.Restaurant.AsQueryable().Where(w => !w.IsDelete);
            var Entity = _dbContext.Foods.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                Entity = Entity.Where(w => w.Name.ToLower().Contains(search.Trim().ToLower()));
            }

            return new PaginationModels<List<FoodDTO>>
            {
                TotalItem = Entity.Count(),
                Items = Entity.Select(s => new FoodDTO()
                {
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name,
                    Price = s.Price,
                    RestaurantId = s.RestaurantId,
                    ImageURL = s.ImageURL,
                    RestaurantName = restaurants.FirstOrDefault(f => f.Id == s.RestaurantId).Name
                }).ToList()
            };
        }

        public FoodDTO GetById(long id)
        {
            var Entity = _dbContext.Foods.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy món ăn");
            }
            var restaurants = _dbContext.Restaurant.AsQueryable().Where(w => !w.IsDelete);
            var result = new FoodDTO()
            {
                Id = Entity.Id,
                Code = Entity.Code,
                Name = Entity.Name,
                Price = Entity.Price,
                RestaurantId = Entity.RestaurantId,
                ImageURL = Entity.ImageURL,
                RestaurantName = restaurants.FirstOrDefault(f => f.Id == Entity.RestaurantId)?.Name
            };
            return result;
        }

        public void Update(FoodDTO input, long id)
        {
            var Entity = _dbContext.Foods.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy món ăn");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Entity.Code = input.Code;
                    Entity.Name = input.Name;
                    Entity.Price = input.Price;
                    Entity.RestaurantId = input.RestaurantId;
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
                    throw new Exception($"Tạo món ăn \"{input.Id}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }

        }
    }
}
