using AutoMapper;
using InterviewLists.Application.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using InterviewLists.Domain.Entities;
namespace InterviewLists.Application.Models.Car
{
    public class CarDto : IHaveCustomMapping
    {
        public int Id { get; set; }
        public int CarMakeId { get; set; }
        public int CarModelId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfProduction { get; set; }
        public string Country { get; set; }
        public string CarMakeTitle { get; set; }
        public string CarModelTitle { get; set; }
        public string UserId { get; set; }
        public bool AllowModifications { get; set; } = false;

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.Car, CarDto>()
                .ForMember(pDTO => pDTO.CarModelTitle, opt => opt.MapFrom(p => p.CarModel != null ? p.CarModel.Title : string.Empty))
                .ForMember(pDTO => pDTO.CarMakeTitle, opt => opt.MapFrom(p => p.CarMake != null ? p.CarMake.Title : string.Empty));
        }
    }
}
