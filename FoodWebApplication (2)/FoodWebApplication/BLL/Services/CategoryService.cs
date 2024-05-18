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
using DTO.Category;
using Entities.Category;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CoreContext _dbContext;

        public CategoryService(CoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CategoryDTO> GetAllCategory()
        {
            var subjects = _dbContext.Categories.AsQueryable().Where(w => !w.IsDelete);
            return subjects.Select(s => new CategoryDTO()
            {
                Id = s.Id,
                Name = s.Name,
                ImageURL = s.ImageURL,
            }).ToList();
        }
        public void Create(CategoryDTO input)
        {
            if (_dbContext.Categories.FirstOrDefault(u => u.Id == input.Id) != null)
            {
                throw new Exception($"Mã thể loại \"{input.Id}\"đã tồn tại");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var Entity = new CategoryEntities()
                    {
                        Id = input.Id,
                        Name = input.Name,
                        ImageURL = input.ImageURL,
                    };
                    _dbContext.Categories.Add(Entity);
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
                    throw new Exception($"Tạo thể loại \"{input.Id}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }
        }

        public void Delete(long id)
        {
            var Entity = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy thể loại");
            }
            _dbContext.Categories.Remove(Entity);
            _dbContext.SaveChanges();
        }

        public PaginationModels<List<CategoryDTO>> Get(string search)
        {
            var Entity = _dbContext.Categories.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                Entity = Entity.Where(w => w.Name.ToLower().Contains(search.Trim().ToLower()));
            }

            return new PaginationModels<List<CategoryDTO>>
            {
                TotalItem = Entity.Count(),
                Items = Entity.Select(s => new CategoryDTO()
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImageURL = s.ImageURL,
                }).ToList()
            };
        }

        public CategoryDTO GetById(long id)
        {
            var Entity = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy thể loại");
            }
            var result = new CategoryDTO()
            {
                Id = Entity.Id,
                Name = Entity.Name,
                ImageURL = Entity.ImageURL
            };
            return result;
        }

        public void Update(CategoryDTO input, long id)
        {
            var Entity = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
            if (Entity == null)
            {
                throw new Exception("Không tìm thấy thể loại");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Entity.Name = input.Name;
                    Entity.Type = input.Type;
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
                    throw new Exception($"Tạo thể loại \"{input.Id}\"không thành công");
                }
                finally
                {
                    trans.Dispose();
                }
            }

        }
    }
}
