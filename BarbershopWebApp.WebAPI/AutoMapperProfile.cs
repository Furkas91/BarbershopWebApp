using AutoMapper;
using BarbershopWebApp.Client.DTO;
using BarbershopWebApp.Client.DTO.Create;
using BarbershopWebApp.Client.DTO.Read;
using BarbershopWebApp.Client.DTO.Update;
using BarbershopWebApp.Domain.Models;

namespace BarbershopWebApp.WebAPI
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DAL.Entity.Consumer, Domain.Consumer>();
            this.CreateMap<Domain.Consumer, ConsumerDTO>();
            this.CreateMap<ConsumerCreateDTO, ConsumerUpdateModel>();
            this.CreateMap<ConsumerUpdateDto, ConsumerUpdateModel>();
            this.CreateMap<ConsumerUpdateModel, DAL.Entity.Consumer>();
            
            this.CreateMap<DAL.Entity.Loyalty, Domain.Loyalty>();
            this.CreateMap<Domain.Loyalty, LoyaltyDTO>();
            this.CreateMap<LoyaltyCreateDTO, LoyaltyUpdateModel>();
            this.CreateMap<LoyaltyUpdateDto, LoyaltyUpdateModel>();
            this.CreateMap<LoyaltyUpdateModel, DAL.Entity.Loyalty>();
            
            this.CreateMap<DAL.Entity.Haircut, Domain.Haircut>();
            this.CreateMap<Domain.Haircut, HaircutDTO>();
            this.CreateMap<HaircutCreateDTO, HaircutUpdateModel>();
            this.CreateMap<HaircutUpdateDto, HaircutUpdateModel>();
            this.CreateMap<HaircutUpdateModel, DAL.Entity.Haircut>();
            
            this.CreateMap<DAL.Entity.Barber, Domain.Barber>();
            this.CreateMap<Domain.Barber, BarberDTO>();
            this.CreateMap<BarberCreateDTO, BarberUpdateModel>();
            this.CreateMap<BarberUpdateDto, BarberUpdateModel>();
            this.CreateMap<BarberUpdateModel, DAL.Entity.Barber>();
            
            this.CreateMap<DAL.Entity.Note, Domain.Note>();
            this.CreateMap<Domain.Note, NoteDTO>();
            this.CreateMap<NoteCreateDTO, NoteUpdateModel>();
            this.CreateMap<NoteUpdateDTO, NoteUpdateModel>();
            this.CreateMap<NoteUpdateModel, DAL.Entity.Note>();
        }
    }
}