using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BarbershopWebApp.BLL.Contracts;
using BarbershopWebApp.Client.DTO.Create;
using BarbershopWebApp.Client.DTO.Read;
using BarbershopWebApp.Client.DTO.Update;
using BarbershopWebApp.DAL;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/barber")]
    public class BarberApiController : ControllerBase
    {
        private IBarberService BarberService{ get;}
        private ILogger<BarberApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public BarberApiController(ILogger<BarberApiController> logger, IMapper mapper, IBarberService barberService)
        {
            this.Logger = logger;
            this.BarberService = barberService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<BarberDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for ");
            return this.Mapper.Map<IEnumerable<BarberDTO>>(await this.BarberService.GetAsync());
        }
        
        [HttpGet("{barberId}")]
        public async Task<BarberDTO> GetAsync(int barberId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");
            return this.Mapper.Map<BarberDTO>(await this.BarberService.GetAsync(new BarberIdentityModel(barberId)));
        }
        
        [HttpPatch]
        public async Task<BarberDTO> PatchAsync(BarberUpdateDto barber)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.BarberService.UpdateAsync(this.Mapper.Map<BarberUpdateModel>(barber));
            return this.Mapper.Map<BarberDTO>(result);
        }
        
        [HttpPut]
        public async Task<BarberDTO> PutAsync(BarberCreateDTO barber)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.BarberService.CreateAsync(this.Mapper.Map<BarberUpdateModel>(barber));
            return this.Mapper.Map<BarberDTO>(result);
        }
    }
}