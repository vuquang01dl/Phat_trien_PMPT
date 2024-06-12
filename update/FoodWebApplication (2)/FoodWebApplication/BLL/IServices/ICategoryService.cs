using DTO.User;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Category;

namespace BLL.IServices
{
    public interface ICategoryService
    {
        void Create(CategoryDTO input);
        void Update(CategoryDTO input, long id);
        void Delete(long id);
        CategoryDTO GetById(long id);
        PaginationModels<List<CategoryDTO>> Get(string search);
        List<CategoryDTO> GetAllCategory();
    }
}
