using GokalpLogistics.UI.Service.Absract;
using Newtonsoft.Json;
using RestSharp;

namespace GokalpLogistics.UI.Service.Concrete
{
    /// <summary>
    /// Örnek kullanımı :
    ///     _restService.PostAsync<TruckRegisterVM, Result<int>>(TruckModel, "truck/createTruck");
    ///     Bunun için DI prensibini kullanmak ve pipeline eklemek şart.
    /// --------------------------------------------------------------
    /// RestService : IRestService => 
    ///     İmplement etmek istediğimiz için sınıfa sorumluluk yüklüyoruz
    /// -----------------------------------------------------
    /// RestClient restClient = new RestClient(apiUri) => 
    ///     Api ye istek atmak için isteğin temel instance oluşturuluyor.
    ///     -------------------------------------------------------
    /// RestRequest restRequest = new RestRequest(endpointUrl) => 
    ///     Gidecek olan isteğin ayrıntıları için RestRequest instance i oluşturuluyor.
    ///     -------------------------------------------------------
    /// restRequest.AddHeader("Accept", "application/json") => 
    ///     Gidecek olan isteğe ayrıntı ekliyoruz.
    ///     ---------------------------------------------------------   
    /// var response = await restClient.ExecuteAsync<TResponse>(restRequest);
    ///     Gidecek olan isteği başlatıyoruz.
    /// return response;
    ///     Ve isteğin cevabını alıyoruz.
    /// --------------------------------------------------------------------
    /// </summary>
    public class RestService : IRestService
    {
        private readonly IConfiguration _configuration;
        

        public RestService(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        public async Task<RestResponse<TResponse>> DeleteAsync<TResponse>(string endpointUrl)
        {
            var apiUrl = _configuration["Api:Url"];
            RestClient restClient = new RestClient(apiUrl);
            RestRequest restRequest = new RestRequest(endpointUrl, Method.Delete);
            restRequest.AddHeader("Accept", "application/json");
            var response = await restClient.ExecuteAsync<TResponse>(restRequest);            
            return response;
        }

        public async Task<RestResponse<TResponse>> GetAsync<TResponse>(string endpointUrl)
        {
            var apiUri = _configuration["Api:Url"];
            RestClient restClient = new RestClient(apiUri);
            RestRequest restRequest = new RestRequest(endpointUrl);
            restRequest.AddHeader("Accept", "application/json");
            var response = await restClient.ExecuteAsync<TResponse>(restRequest);
            return response;
        }

        public async Task<RestResponse<TResponse>> PostAsync<TRequest, TResponse>(TRequest requestModel, string endpointUrl)
        {
            var apiUrl = _configuration["Api:Url"];
            var jsonModel = JsonConvert.SerializeObject(requestModel);

            RestClient restClient = new RestClient(apiUrl);
            RestRequest restRequest = new RestRequest(endpointUrl, Method.Post);

            restRequest.AddParameter("application/json", jsonModel, ParameterType.RequestBody);
            restRequest.AddHeader("Accept", "application/json");
            var response = await restClient.ExecuteAsync<TResponse>(restRequest);
            return response;
        }

        public async Task<RestResponse<TResponse>> PostAsync<TResponse>(string endpointUrl)
        {
            var apiUrl = _configuration["Api:Url"];
            RestClient restClient = new RestClient(apiUrl);
            RestRequest restRequest = new RestRequest(endpointUrl, Method.Post);
            restRequest.AddHeader("Accept", "application/json");
            var response = await restClient.ExecuteAsync<TResponse>(restRequest);
            return response;
        }

        public async Task<RestResponse<TResponse>> PostFormAsync<TResponse>(Dictionary<string, string> parameters, string endpointUrl)
        {
            var apiUrl = _configuration["Api:Url"];
            RestClient restClient = new RestClient(apiUrl);
            RestRequest restRequest = new RestRequest(endpointUrl, Method.Post);
            restRequest.AddHeader("content-type", "application/x-www-form-urlencoded");
            restRequest.AddHeader("Accept", "application/json");
            //Modelden gelen bilgiler isteğe key value şeklinde aktarılıyor
            AddFormParametersToRequest(restRequest, parameters);
            var response = await restClient.ExecuteAsync<TResponse>(restRequest);
            return response;
        }
        public async Task<RestResponse<TResponse>> PutAsync<TRequest, TResponse>(TRequest requestModel, string endpointUrl)
        {
            var apiUrl = _configuration["Api:Url"];
            var jsonModel = JsonConvert.SerializeObject(requestModel);
            RestClient restClient = new RestClient(apiUrl);
            RestRequest restRequest = new RestRequest(endpointUrl, Method.Put);
            restRequest.AddParameter("application/json", jsonModel, ParameterType.RequestBody);
            restRequest.AddHeader("Accept", "application/json");
            var response = await restClient.ExecuteAsync<TResponse>(restRequest);
            return response;
        }

        private void AddFormParametersToRequest(RestRequest request, Dictionary<string, string> parameters)
        {
            foreach (var key in parameters.Keys)
            {
                request.AddParameter(key, parameters[key]);
            }
        }
    }
    
}
