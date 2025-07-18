﻿using AutoMapper;
using Challenge.Application.DTO;
using Challenge.Domain.Entity;
using System;

namespace Challenge.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile() 
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Alerta, AlertaDto>().ReverseMap();

        }
    }
}
