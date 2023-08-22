using RestSharp;

namespace GokalpLogistics.UI.Service.Absract
{
    /// <summary>
    /// => Api ile aradaki köprüyü oluşturacak rest methodlarının gövdesi.
    /// </summary>
    public interface IRestService
    {
        Task<RestResponse<TResponse>> PostAsync<TRequest, TResponse>(TRequest requestModel, string endpointUrl);

        Task<RestResponse<TResponse>> PostAsync<TResponse>(string endpointUrl);

        Task<RestResponse<TResponse>> PostFormAsync<TResponse>(Dictionary<string, string> parameters, string endpointUrl);

        Task<RestResponse<TResponse>> GetAsync<TResponse>(string endpointUrl);

        Task<RestResponse<TResponse>> DeleteAsync<TResponse>(string endpointUrl);

        Task<RestResponse<TResponse>> PutAsync<TRequest, TResponse>(TRequest requestModel, string endpointUrl);
    }
}
