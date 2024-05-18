using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RestAPI
{
    public interface IRestApiServices
    {
        Task<ResponseModels> PostAsJson<TViewModel>(string ApiURL, TViewModel model);
        Task<ResponseModels> GetAsJson<TViewModel>(string ApiURL, string search = null);
        Task<ResponseModels> DeleteJson<TViewModel>(string ApiURL);
    }
}
