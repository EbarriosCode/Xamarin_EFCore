using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamEFCore.Models;

namespace XamEFCore.Services
{
    public class WebService
    {
        // Método genérico para consumir cualquier servicio Rest, HttpGet retorna un listado de genéricos
        public async Task<Response> GetListRest<T>(string urlService, string user, string password)
        {
            try
            {
                var client = new HttpClient();

                var credentialBytes = Encoding.ASCII.GetBytes($"{user}:{password}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentialBytes));

                var response = await client.GetAsync(urlService);

                var jsonResult = await response.Content.ReadAsStringAsync();
                var deserializeObject = JsonConvert.DeserializeObject<T>(jsonResult);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = jsonResult,
                    };
                }

                var list = new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    DataResult = deserializeObject,
                };

                return list;
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
