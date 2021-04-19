using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BarbershopWebApp.BLL.Contracts;
using BarbershopWebApp.Client.DTO.Create;
using BarbershopWebApp.Client.DTO.Update;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/loyalty")]
    public class LoyaltyApiController: ControllerBase
    {
        private ILoyaltyService LoyaltyService{ get;}
        private ILogger<LoyaltyApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public LoyaltyApiController(ILogger<LoyaltyApiController> logger, IMapper mapper, ILoyaltyService loyaltyService)
        {
            this.Logger = logger;
            this.LoyaltyService = loyaltyService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<LoyaltyDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<LoyaltyDTO>>(await this.LoyaltyService.GetAsync());
        }
        
        [HttpGet("{loyaltyId}")]
        public async Task<LoyaltyDTO> GetAsync(int loyaltyId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {loyaltyId}");
            return this.Mapper.Map<LoyaltyDTO>(await this.LoyaltyService.GetAsync(new LoyaltyIdentityModel(loyaltyId)));
        }
        
        [HttpPatch]
        public async Task<LoyaltyDTO> PatchAsync(LoyaltyUpdateDto loyalty)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.LoyaltyService.UpdateAsync(this.Mapper.Map<LoyaltyUpdateModel>(loyalty));
            return this.Mapper.Map<LoyaltyDTO>(result);
        }
        
        [HttpPut]
        public async Task<LoyaltyDTO> PutAsync(LoyaltyCreateDTO loyalty)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.LoyaltyService.CreateAsync(this.Mapper.Map<LoyaltyUpdateModel>(loyalty));
            return this.Mapper.Map<LoyaltyDTO>(result);
        }
    }
}