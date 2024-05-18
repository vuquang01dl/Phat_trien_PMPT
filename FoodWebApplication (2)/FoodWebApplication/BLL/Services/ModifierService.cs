using DTO.Food;
using DTO;
using Entities.Food;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.IServices;
using DTO.Modifier;
using Entities.Modifier;

namespace BLL.Services
{
    public class ModifierService : IModifierService
    {
        private readonly CoreContext _dbContext;

        public ModifierService(CoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ModifierDTO> GetAllModifier()
        {
            var foods = _dbContext.Modifiers.AsQueryable();
            var subjects = _dbContext.Modifiers.AsQueryable().Where(w => !w.IsDelete);
            return subjects.Select(s => new ModifierDTO()
            {
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Price = s.Price,
                ImageURL = s.ImageURL,
                FoodId = s.FoodId,
                FoodName = foods.FirstOrDefault(f => f.Id == s.FoodId).Name
            }).ToList();
        }
        public void Create(ModifierDTO input)
        {
            if (_dbContext.Modifiers.FirstOrDefault(u => u.Id == input.Id) != null)
            {
                throw new Exception($"Mã topping \"{input.Id}\"đã tồn tại");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var Entity = new ModifierEntities()
                    {
                        Id = input.Id,
                        Code = input.Code,
                        Name = input.Name,
                        Price = input.Price,
                        ImageURL = input.ImageURL,
                        FoodId= input.FoodId,
                    };
                    _dbContext.Modifiers.Add(Entity);
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
                    throw new Exception($"Tạo topping \"{input.Id}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }
        }

        public void Delete(long id)
        {
            var Entity = _dbContext.Modifiers.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy topping");
            }
            _dbContext.Modifiers.Remove(Entity);
            _dbContext.SaveChanges();
        }

        public PaginationModels<List<ModifierDTO>> Get(string search)
        {
            var Entity = _dbContext.Modifiers.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                Entity = Entity.Where(w => w.Name.ToLower().Contains(search.Trim().ToLower()));
            }

            var foods = _dbContext.Modifiers.AsQueryable();
            return new PaginationModels<List<ModifierDTO>>
            {
                TotalItem = Entity.Count(),
                Items = Entity.Select(s => new ModifierDTO()
                {
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name,
                    Price = s.Price,
                    ImageURL = s.ImageURL,
                    FoodId = s.FoodId,
                    FoodName = foods.FirstOrDefault(f => f.Id == s.FoodId).Name
                }).ToList()
            };
        }

        public ModifierDTO GetById(long id)
        {
            var Entity = _dbContext.Modifiers.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy topping");
            }
            var foods = _dbContext.Modifiers.AsQueryable();
            var result = new ModifierDTO()
            {
                Id = Entity.Id,
                Code = Entity.Code,
                Name = Entity.Name,
                Price = Entity.Price,
                ImageURL = Entity.ImageURL,
                FoodId = Entity.FoodId,
                FoodName = foods.FirstOrDefault(f => f.Id == Entity.FoodId)?.Name,
            };
            return result;
        }

        public void Update(ModifierDTO input, long id)
        {
            var Entity = _dbContext.Modifiers.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy topping");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Entity.Code = input.Code;
                    Entity.Name = input.Name;
                    Entity.Price = input.Price;
                    Entity.ImageURL = input.ImageURL;
                    Entity.FoodId = input.FoodId;
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
                    throw new Exception($"Tạo topping \"{input.Id}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }

        }
    }
}
