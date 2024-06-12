using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Security;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Common.RestAPI
{
    public class RestApiServices : IRestApiServices
    {
        private static string ApiEndPoint = "https://localhost:44355/api/";
        private void InitHeaderRequest(HttpClient Client)
        {
            try
            {
                Client.BaseAddress = new Uri(ApiEndPoint);
                Client.DefaultRequestHeaders.Accept.Clear();
            }
            catch (Exception ex) { }
        }

        public async Task<ResponseModels> DeleteJson<TViewModel>(string ApiURL)
        {
            var response = new ResponseModels();
            HttpClient client = new HttpClient();
            InitHeaderRequest(client);
            try
            {
                HttpResponseMessage httpResponse = await client.DeleteAsync(ApiURL);
                var statusCode = (int)httpResponse.StatusCode;
                if (statusCode == (int)HttpStatusCode.Unauthorized || statusCode == (int)HttpStatusCode.Forbidden)
                {
                    response.Status = statusCode;
                    response.Message = "Tài khoản của bạn không có quyền truy cập tài nguyên";
                    response.Success = false;
                }
                else
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(result))
                    {
                        response = JsonConvert.DeserializeObject<ResponseModels>(result);
                        JToken _jToken = response.Data;
                        if (_jToken != null)
                        {

                            if (_jToken.SelectToken("records") != null)
                            {
                                response.Data = JsonConvert.DeserializeObject<IEnumerable<TViewModel>>(_jToken.SelectToken("records").ToString());
                            }
                            else
                            {
                                response.Data = JsonConvert.DeserializeObject<TViewModel>(_jToken.ToString());
                            }
                        }
                    }
                    response.Status = statusCode;
                }
            }
            catch (Exception) { }
            return response;
        }

        public async Task<ResponseModels> GetAsJson<TViewModel>(string ApiURL, string search = null)
        {
            var response = new ResponseModels();
            HttpClient client = new HttpClient();
            InitHeaderRequest(client);
            try
            {
                if (search != null)
                {
                    var dataAsString = JsonConvert.SerializeObject(search);
                    var content = new StringContent(dataAsString);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }
                HttpResponseMessage httpResponse = await client.GetAsync(ApiURL);
                var statusCode = (int)httpResponse.StatusCode;
                if (statusCode == (int)HttpStatusCode.Unauthorized || statusCode == (int)HttpStatusCode.Forbidden)
                {
                    response.Status = statusCode;
                    response.Message = "Tài khoản của bạn không có quyền truy cập tài nguyên";
                    response.Success = false;
                }
                else
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(result))
                    {
                        response = JsonConvert.DeserializeObject<ResponseModels>(result);
                        JToken _jToken = response.Data;
                        if (_jToken != null && _jToken.SelectToken("records") != null)
                        {
                            response.Data = JsonConvert.DeserializeObject<IEnumerable<TViewModel>>(_jToken.SelectToken("records").ToString());
                        }
                        else
                        {
                            response.Data = JsonConvert.DeserializeObject<TViewModel>(_jToken.ToString());
                        }
                    }
                    response.Status = statusCode;
                }
            }
            catch (Exception ex) { }
            finally
            {
                client.CancelPendingRequests();
            }
            return response;
        }

        public async Task<ResponseModels> PostAsJson<TViewModel>(string ApiURL, TViewModel model)
        {
            HttpClient client = new HttpClient();
            var response = new ResponseModels();
            InitHeaderRequest(client);
            try
            {
                if (model != null)
                {
                    var dataAsString = JsonConvert.SerializeObject(model);
                    var content = new StringContent(dataAsString);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage httpResponse = await client.PostAsync(ApiURL, content);
                    var statusCode = (int)httpResponse.StatusCode;
                    if (statusCode == (int)HttpStatusCode.Unauthorized || statusCode == (int)HttpStatusCode.Forbidden)
                    {
                        response.Status = statusCode;
                        response.Message = "Tài khoản của bạn không có quyền truy cập tài nguyên";
                        response.Success = false;
                    }
                    else
                    {
                        var result = await httpResponse.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(result))
                        {
                            response = JsonConvert.DeserializeObject<ResponseModels>(result);
                            JToken _jToken = response.Data;
                            if (_jToken != null)
                            {

                                if (_jToken.SelectToken("records") != null)
                                {
                                    response.Data = JsonConvert.DeserializeObject<IEnumerable<TViewModel>>(_jToken.SelectToken("records").ToString());
                                }
                                else
                                {
                                    response.Data = JsonConvert.DeserializeObject<TViewModel>(_jToken.ToString());
                                }
                            }
                        }
                        response.Status = statusCode;
                    }
                }
            }
            catch (Exception ex) { }
            finally
            {
                client.CancelPendingRequests();
            }
            return response;
        }

    }
}