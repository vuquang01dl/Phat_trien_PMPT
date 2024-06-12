using DTO.Category;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Modifier;

namespace BLL.IServices
{
    public interface IModifierService
    {
        void Create(ModifierDTO input);
        void Update(ModifierDTO input, long id);
        void Delete(long id);
        ModifierDTO GetById(long id);
        PaginationModels<List<ModifierDTO>> Get(string search);
        List<ModifierDTO> GetAllModifier();
    }
}
