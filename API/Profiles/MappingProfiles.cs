using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Dominio.Entities;
using API.Dtos;
namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles(){
        CreateMap<Pais,PaisDto>().ReverseMap();
        CreateMap<Departamento, DepartamentoDto>().ReverseMap();
        CreateMap<Ciudad, CiudadDto>().ReverseMap();
    }
}
