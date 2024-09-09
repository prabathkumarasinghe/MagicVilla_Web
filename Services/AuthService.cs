using MagicVilla_Utility;
using MagicVilla_Web.Model.Dto;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
	public class AuthService : BaseService, IAuthService
	{
		private readonly IHttpClientFactory _clientFactory;
		private string villaUrl;

		public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
		{
			_clientFactory = clientFactory;
			villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");

		}
		public Task<T> LoginAsync<T>(LoginRequestDto loginRequestDto)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = loginRequestDto,
				Url = villaUrl + "/api/V1/UsersAuth/login"

            });
		}

		public Task<T> RegisterAsync<T>(RegisterationRequestDto registerationRequestDto)
		{
			return SendAsync<T>(new APIRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = registerationRequestDto,
				Url = villaUrl + "/api/V1/UsersAuth/register"

            });
		}
	}
}
