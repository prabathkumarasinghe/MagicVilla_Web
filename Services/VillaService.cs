﻿
using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaUrl;

        public VillaService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");

        }

        public Task<T> CreateAsync<T>(VillaCreateDto dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = villaUrl + "/api/V1/VillaAPI",
                Token = token
            });
        }

        //public Task<T> DeleteAsync<T>(int id)
        //{
        //    return SendAsync<T>(new APIRequest()
        //    {
        //        ApiType = SD.ApiType.DELETE,
        //        Url = villaUrl + "/api/VillaAPI" + id
               
        //    });
        //}
        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = villaUrl + "/api/V1/VillaAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl+ "/api/V1/VillaAPI",
              //  Url = villaUrl + "/api/VillaAPI"
               Token = token
            });
        }

        
        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl + "/api/V1/VillaAPI/" + id,
                Token = token
            });
        }

        //public Task<T> UpdateAsync<T>(VillaUpdateDto dto)
        //{
        //    return SendAsync<T>(new APIRequest()
        //    {
        //        ApiType = SD.ApiType.PUT,
        //        Data = dto,
        //        Url = villaUrl + "/api/VillaAPI" + dto.Id
                
        //    });
        //}
        public Task<T> UpdateAsync<T>(VillaUpdateDto dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = villaUrl + "/api/V1/VillaAPI/" + dto.Id,
                Token = token

            });
        }
    }
}
