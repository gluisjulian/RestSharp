using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Threading.Tasks;
using testeRestSharp.Response;

namespace testeRestSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViaCepController : ControllerBase
    {
        public async Task<ViaCepResponse> GetEndereco(string cep)
        {

            var client = new RestClient("https://viacep.com.br/ws/"+cep+"/json/" );

            var request = new RestRequest() { RequestFormat = DataFormat.Json };
            var response = await client.GetAsync<ViaCepResponse>(request);

            //https://localhost:44324/api/viacep?cep=17511250

            var result = new ViaCepResponse()
            {
                Cep = response.Cep,
                Bairro = response.Bairro,
                Complemento = response.Complemento,
                Localidade = response.Localidade,
                Logradouro = response.Logradouro,
                Uf = response.Uf,
            };


            return result;
        }
    }
}
