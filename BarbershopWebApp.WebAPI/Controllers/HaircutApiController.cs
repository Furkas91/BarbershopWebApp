using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BarbershopWebApp.BLL.Contracts;
using BarbershopWebApp.Client.DTO.Create;
using BarbershopWebApp.Client.DTO.Read;
using BarbershopWebApp.Client.DTO.Update;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/haircut")]
    public class HaircutApiController: ControllerBase
    {
        private IHaircutService HaircutService{ get;}
        private ILogger<HaircutApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public HaircutApiController(ILogger<HaircutApiController> logger, IMapper mapper, IHaircutService haircutService)
        {
            this.Logger = logger;
            this.HaircutService = haircutService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<HaircutDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<HaircutDTO>>(await this.HaircutService.GetAsync());
        }
        
        [HttpGet("{haircutId}")]
        public async Task<HaircutDTO> GetAsync(int haircutId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {haircutId}");
            return this.Mapper.Map<HaircutDTO>(await this.HaircutService.GetAsync(new HaircutIdentityModel(haircutId)));
        }
        
        [HttpPatch]
        public async Task<HaircutDTO> PatchAsync(HaircutUpdateDto haircut)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.HaircutService.UpdateAsync(this.Mapper.Map<HaircutUpdateModel>(haircut));
            return this.Mapper.Map<HaircutDTO>(result);
        }
        
        [HttpPut]
        public async Task<HaircutDTO> PutAsync(HaircutCreateDTO haircut)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.HaircutService.CreateAsync(this.Mapper.Map<HaircutUpdateModel>(haircut));
            return this.Mapper.Map<HaircutDTO>(result);
        }
    }
}