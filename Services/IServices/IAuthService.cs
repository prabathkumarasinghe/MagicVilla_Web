using MagicVilla_Web.Model.Dto;
using MagicVilla_Web.Models.Dto;

namespace MagicVilla_Web.Services.IServices
{
	public interface IAuthService
	{
		Task<T> LoginAsync<T>(LoginRequestDto loginRequestDto);
		Task<T> RegisterAsync<T>(RegisterationRequestDto registerationRequestDto);
	}
}
