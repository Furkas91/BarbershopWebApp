using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BarbershopWebApp.BLL.Contracts;
using BarbershopWebApp.Client.DTO;
using BarbershopWebApp.Client.DTO.Create;
using BarbershopWebApp.Client.DTO.Read;
using BarbershopWebApp.Client.DTO.Update;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/consumer")]
    public class ConsumerApiController : ControllerBase
    {
        private IConsumerService ConsumerService{ get;}
        private ILogger<ConsumerApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public ConsumerApiController(ILogger<ConsumerApiController> logger, IMapper mapper, IConsumerService consumerService)
        {
            this.Logger = logger;
            this.ConsumerService = consumerService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ConsumerDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<ConsumerDTO>>(await this.ConsumerService.GetAsync());
        }
        
        [HttpGet("{consumerId}")]
        public async Task<ConsumerDTO> GetAsync(int consumerId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {consumerId}");
            return this.Mapper.Map<ConsumerDTO>(await this.ConsumerService.GetAsync(new ConsumerIdentityModel(consumerId)));
        }
        
        [HttpPatch]
        public async Task<ConsumerDTO> PatchAsync(ConsumerUpdateDto consumer)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.ConsumerService.UpdateAsync(this.Mapper.Map<ConsumerUpdateModel>(consumer));
            return this.Mapper.Map<ConsumerDTO>(result);
        }
        
        [HttpPut]
        public async Task<ConsumerDTO> PutAsync(ConsumerCreateDTO consumer)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.ConsumerService.CreateAsync(this.Mapper.Map<ConsumerUpdateModel>(consumer));
            return this.Mapper.Map<ConsumerDTO>(result);
        }
    }
}